using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JupyterSharpPhaser.Web.Models
{
    public class JupyterPreviewModel
    {
        public JupyterPreviewModel()
        {
            StyleSelections = new List<SelectListItem>();
        }

        public string PreviewHtml { get; set; }

        public string PreviewJson { get; set; }

        public IList<SelectListItem> StyleSelections { get; set; }

        public string SelectedItem { get; set; }
    }
}
