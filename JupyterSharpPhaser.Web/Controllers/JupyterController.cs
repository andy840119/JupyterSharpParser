using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
        public IActionResult Preview(IFormFile file)
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

                //Html text
                var htmlText = "";
                using (var memoryStream = new MemoryStream())
                {
                    using (var writer = new StreamWriter(memoryStream))
                    {
                        var htmlRenderer = new HtmlRenderer(writer);
                        htmlRenderer.Render(document);
                        writer.Flush();
                    }
                    htmlText = Encoding.UTF8.GetString(memoryStream.ToArray());
                }

                //return view
                return View(new JupyterPreviewModel
                {
                    PreviewHtml = htmlText,
                    PreviewJson = jupyterString
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                ModelState.AddModelError("Error!","Error occurred while pharsing the file");
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult PreviewHtml(JupyterPreviewModel model)
        {
            var jupyterText = model.PreviewJson;
            if (!string.IsNullOrEmpty(jupyterText))
            {
                //convert to document
                var document = Jupyter.Parse(jupyterText);

                string htmlText = null;
                using (var memoryStream = new MemoryStream())
                {
                    using (var writer = new StreamWriter(memoryStream))
                    {
                        var htmlRenderer = new HtmlRenderer(writer)
                        {
                            RendererHeaderAndFooter = true
                        };
                        htmlRenderer.Render(document);
                    }
                    htmlText = Encoding.UTF8.GetString(memoryStream.ToArray());
                }

                //preview
                return  Content(htmlText, "text/html", Encoding.UTF8);;
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DownloadToHtml(JupyterPreviewModel model)
        {
            var jupyterText = model.PreviewJson;
            if (!string.IsNullOrEmpty(jupyterText))
            {
                //convert to document
                var document = Jupyter.Parse(jupyterText);

                //convert to html
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
                        htmlRenderer.Render(document);
                    }
                    fileBytes = memoryStream.ToArray();
                }

                //diwnload
                return File(fileBytes, "application/force-download", fileName);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DownloadToPdf(JupyterPreviewModel model)
        {
            var jupyterText = model.PreviewJson;
            if (!string.IsNullOrEmpty(jupyterText))
            {
                //convert to document
                var document = Jupyter.Parse(jupyterText);

                //convert to html
                string fileName = "jupyterDocument.pdf";
                byte[] fileBytes = null;
                using (var memoryStream = new MemoryStream())
                {
                    var htmlRenderer = new PdfRenderer(memoryStream);
                    htmlRenderer.Render(document);
                    fileBytes = memoryStream.ToArray();
                }

                return File(fileBytes, "application/force-download", fileName);
            }
           
            return RedirectToAction("Index");
        }

        #endregion 
    }
}
