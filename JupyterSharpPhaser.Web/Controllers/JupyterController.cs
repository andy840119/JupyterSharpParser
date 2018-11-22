using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using JupyterSharpPhaser.Renderers.Html;
using JupyterSharpPhaser.Renderers.Json;
using JupyterSharpPhaser.Renderers.Pdf;
using JupyterSharpPhaser.Syntax;
using JupyterSharpPhaser.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace JupyterSharpPhaser.Web.Controllers
{
    public class JupyterController : Controller
    {
        #region Methods

        /// <summary>
        /// Upload file
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Upload file
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(IFormFile file)
        {

            if (file == null)
            {
                ModelState.AddModelError("Error!","File is empty.");
                return StatusCode(400);
            }

            if (!file.FileName.EndsWith(".ipynb"))
            {
                ModelState.AddModelError("Error!","Upload Jupyter document file.");
                return StatusCode(400);
            }

            try
            {
                //get jupyter document raw text
                var jupyterString = string.Empty;
                using (var reader = new StreamReader(file.OpenReadStream()))
                {
                    jupyterString = reader.ReadToEnd();  
                }

                //convert to document
                var document = Jupyter.Parse(jupyterString);

                //pass to preview method
                return RedirectToAction("Preview", document);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                ModelState.AddModelError("Error!","Error occurred while pharsing the file");
                return RedirectToAction("Index");
            }
        }

        public IActionResult Preview(JupyterDocument jupyterDocument)
        {
            //Html text
            var htmlText = "";
            using (var memoryStream = new MemoryStream())
            using (var writer = new StreamWriter(memoryStream))
            {
                var htmlRenderer = new HtmlRenderer(writer);
                htmlRenderer.Render(jupyterDocument);
                htmlText = writer.ToString();
            }

            //Jupyter text
            var jsonText = "";
            using (var memoryStream = new MemoryStream())
            using (var writer = new StreamWriter(memoryStream))
            {
                var jsonRenderer = new JsonRenderer(writer);
                jsonRenderer.Render(jupyterDocument);
                jsonText = writer.ToString();
            }

            //return view
            return View(new JupyterPreviewModel
            {
                PreviewHtml = htmlText,
                PreviewJson = jsonText
            });
        }

        [HttpPost]
        public IActionResult DownloadToHtml(JupyterDocument jupyterDocument)
        {
            string fileName = "jupyterDocument.html";

            byte[] fileBytes = null;
            using (var memoryStream = new MemoryStream())
            {
                using (var writer = new StreamWriter(memoryStream))
                {
                    var htmlRenderer = new HtmlRenderer(writer)
                    {
                        RendererHeaderAndFooter = true
                    };
                    htmlRenderer.Render(jupyterDocument);
                }

                fileBytes = memoryStream.ToArray();
            }

            return File(fileBytes, "application/force-download", fileName);
        }

        [HttpPost]
        public IActionResult DownloadToPdf(JupyterDocument jupyterDocument)
        {
            string fileName = "jupyterDocument.pdf";

            byte[] fileBytes = null;
            using (var memoryStream = new MemoryStream())
            {
                var htmlRenderer = new PdfRenderer(memoryStream);

                htmlRenderer.Render(jupyterDocument);

                fileBytes = memoryStream.ToArray();
            }

            return File(fileBytes, "application/force-download", fileName);
        }

        #endregion 
    }
}
