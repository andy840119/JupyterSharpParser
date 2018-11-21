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
            foreach (var output in obj.Outputs) renderer.Render(output);

            renderer.WriteLine(@"</div>");
        }

        protected void RendererInput(HtmlRenderer renderer, CodeCell codeCell)
        {
            renderer.WriteLine(@"<div class=""input"">");
            renderer.WriteLine(@"   <div class=""prompt input_prompt"">In&nbsp;[" + codeCell.ExecutionCount +
                               @"]:</div>");
            renderer.WriteLine(@"   <div class=""inner_cell"">");
            renderer.WriteLine(@"       <div class=""input_area"">");
            renderer.WriteLine(@"           <div class="" highlight hl-ipython3"">");

            //Renderer lines
            renderer.Render(codeCell.Source);

            renderer.WriteLine(@"           </div>");
            renderer.WriteLine(@"       </div>");
            renderer.WriteLine(@"   </div>");
            renderer.WriteLine(@"</div>");
        }
    }
}