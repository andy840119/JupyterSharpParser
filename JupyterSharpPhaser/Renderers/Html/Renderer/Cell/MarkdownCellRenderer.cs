using System;
using System.IO;
using JupyterSharpPhaser.Syntax.Cell;
using Markdig;
using Markdig.Syntax;

namespace JupyterSharpPhaser.Renderers.Html.Renderer.Cell
{
    public class MarkdownCellRenderer : HtmlObjectRenderer<MarkdownCell>
    {
        protected override void Write(HtmlRenderer renderer, MarkdownCell obj)
        {
            var htmlText = GetMarkdownRendererFromMarkdownDocument(obj.MarkdownDocument);
            renderer.WriteLine(htmlText);
        }

        protected string GetMarkdownRendererFromMarkdownDocument(MarkdownDocument document)
        {
            MarkdownPipeline pipeline = new MarkdownPipelineBuilder().Build();

            var writer = new StringWriter();
            var renderer = new Markdig.Renderers.HtmlRenderer(writer);
            pipeline.Setup(renderer);

            renderer.Render(document);

            writer.Flush();
            return writer.ToString();
        }
    }
}
