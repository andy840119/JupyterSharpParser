﻿using System.Collections.Generic;
using JupyterSharpParser.Syntax.Cell;
using Newtonsoft.Json;

namespace JupyterSharpParser.Syntax
{
    /// <summary>
    /// See : 
    /// https://nbformat.readthedocs.io/en/latest/format_description.html#cell-types
    /// </summary>
    public class JupyterDocument : IJupyterObject
    {
        public JupyterDocument()
        {
            Metadata = new Metadata.Metadata();
            Cells = new List<ICell>();
        }

        [JsonProperty("metadata")] public Metadata.Metadata Metadata { get; set; }

        [JsonProperty("nbformat")] public int NbFormat { get; set; }

        [JsonProperty("nbformat_minor")] public int NbFormatMinor { get; set; }

        [JsonProperty("cells")] public IList<ICell> Cells { get; set; }
    }
}