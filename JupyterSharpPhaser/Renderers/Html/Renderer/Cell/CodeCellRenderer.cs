using System;
using JupyterSharpPhaser.Syntax.Cell;

namespace JupyterSharpPhaser.Renderers.Html.Renderer.Cell
{
    public class CodeCellRenderer : HtmlObjectRenderer<CodeCell>
    {
        protected override void Write(HtmlRenderer renderer, CodeCell obj)
        {
            renderer.WriteLine(@"<div class=""cell border-box-sizing code_cell rendered"">");

            //renderer input
            RendererInput(renderer, obj);

            //renderer outputs
            foreach (var output in obj.Outputs)
            {
                //renderer.Render(output);
            }

            renderer.WriteLine(@"</div>");
        }

        protected void RendererInput(HtmlRenderer renderer,CodeCell codeCell)
        {
            renderer.WriteLine(@"<div class=""input"">");
            renderer.WriteLine(@"   <div class=""prompt input_prompt"">In&nbsp;[" + codeCell.ExecutionCount + @"]:</div>");
            renderer.WriteLine(@"   <div class=""inner_cell"">");
            renderer.WriteLine(@"       <div class=""input_area"">");
            renderer.WriteLine(@"           <div class="" highlight hl-ipython3"">");
            renderer.WriteLine(@"               <pre>");
            renderer.WriteLine(@"                   <span></span>");

            //TODO : renderer language style
            renderer.WriteLine(@"                   <span class=""mi"">" + codeCell.Source.Text + "</span>");

            renderer.WriteLine(@"               </pre>");
            renderer.WriteLine(@"           </div>");
            renderer.WriteLine(@"       </div>");
            renderer.WriteLine(@"   </div>");
            renderer.WriteLine(@"</div>");
        }
    }
}
