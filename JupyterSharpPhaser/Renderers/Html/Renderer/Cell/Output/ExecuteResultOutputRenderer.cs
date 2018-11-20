using JupyterSharpPhaser.Syntax.Cell.Output;
using System;
using System.Collections.Generic;
using System.Text;

namespace JupyterSharpPhaser.Renderers.Html.Renderer.Cell.Output
{
    public class ExecuteResultOutputRenderer : HtmlObjectRenderer<ExecuteResultOutput>
    {
        protected override void Write(HtmlRenderer renderer, ExecuteResultOutput obj)
        {
            renderer.WriteLine(@"<div class=""output_wrapper"">");
            renderer.WriteLine(@"   <div class=""output"">");
            renderer.WriteLine(@"       <div class=""output_area"">");
            renderer.WriteLine(@"           <div class=""prompt output_prompt"">Out[" + obj.ExecutionCount + "]:</div>");
            renderer.WriteLine(@"           <div class=""output_text output_subarea output_execute_result"">");

            //Renderer lines
            renderer.Render(obj.Data.TextPlain);

            renderer.WriteLine(@"           </div>");
            renderer.WriteLine(@"       </div>");
            renderer.WriteLine(@"   </div>");
            renderer.WriteLine(@"</div>");
        }
    }
}
