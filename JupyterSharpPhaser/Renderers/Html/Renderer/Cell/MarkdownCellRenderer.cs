using System.IO;
using JupyterSharpParser.Syntax.Cell;
using Markdig;
using Markdig.Syntax;

namespace JupyterSharpParser.Renderers.Html.Renderer.Cell
{
    public class MarkdownCellRenderer : HtmlObjectRenderer<MarkdownCell>
    {
        protected override void Write(HtmlRenderer renderer, MarkdownCell obj)
        {
            renderer.WriteLine(@"<div class=""cell border-box-sizing text_cell rendered"">");
            renderer.WriteLine(@"   <div class=""prompt input_prompt""></div>");
            renderer.WriteLine(@"   <div class=""inner_cell"">");

            var htmlText = GetMarkdownRendererFromMarkdownDocument(obj.MarkdownDocument);
            renderer.WriteLine(htmlText);

            renderer.WriteLine(@"   </div>");
            renderer.WriteLine(@"</div>");
        }

        protected string GetMarkdownRendererFromMarkdownDocument(MarkdownDocument document)
        {
            var pipeline = new MarkdownPipelineBuilder().Build();

            var writer = new StringWriter();
            var renderer = new Markdig.Renderers.HtmlRenderer(writer);
            pipeline.Setup(renderer);

            renderer.Render(document);

            writer.Flush();
            return writer.ToString();
        }
    }
}