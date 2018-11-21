using JupyterSharpPhaser.Syntax.Cell.Output;

namespace JupyterSharpPhaser.Renderers.Html.Renderer.Cell.Output
{
    public class StreamOutputRenderer : HtmlObjectRenderer<StreamOutput>
    {
        protected override void Write(HtmlRenderer renderer, StreamOutput obj)
        {
            renderer.WriteLine(@"<div class=""output_wrapper"">");
            renderer.WriteLine(@"   <div class=""output"">");
            renderer.WriteLine(@"       <div class=""output_area"">");
            renderer.WriteLine(@"       <div class=""prompt""></div>");
            renderer.WriteLine(@"           <div class=""output_subarea output_stream output_stdout output_text"">");

            //Renderer lines
            renderer.Render(obj.Text);

            renderer.WriteLine(@"           </div>");
            renderer.WriteLine(@"       </div>");
            renderer.WriteLine(@"   </div>");
            renderer.WriteLine(@"</div>");
        }
    }
}