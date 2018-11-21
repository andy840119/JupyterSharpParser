using System;
using System.Collections.Generic;
using System.Text;

namespace JupyterSharpPhaser.Syntax.Cell.Common
{
    public class Lines : List<string>, IJupyterObject
    {
        public bool MultiLine { get; set; }

        public string Text => string.Join("\n", this);
    }
}