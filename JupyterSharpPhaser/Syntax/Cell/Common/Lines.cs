using System.Collections.Generic;

namespace JupyterSharpPhaser.Syntax.Cell.Common
{
    public class Lines : List<string>, IJupyterObject
    {
        public bool MultiLine { get; set; }

        public string Text => string.Join("\n", this);
    }
}