# JupyterSharpPhaser
Jupyter phaser written in C#

Samlpe : 
```csharp
var jupyterText = "[Text in jupyer document]";
JupyterDocument document = Jupyter.Parse(jupyterText);

//You can do anything in this document such as add cell
document.Cells.Add(new CodeCell
{
    ExecutionCount = 10,
    Source = new List<string>{"print(3 * 2)"}
});
```

Convert To Json : 
```csharp
// Output
var writer = new StringWriter();

// Create a HTML Renderer and setup it with the pipeline
var renderer = new JsonRenderer(writer);

// Renders Jupyter Document to Json (to the writer)
renderer.Render(markdownDocument);

// Gets the rendered string
var result = writer.ToString();
```

Convert To Html : 
```csharp
// Output
var writer = new StringWriter();

// Create a HTML Renderer and setup it with the pipeline
var renderer = new HtmlRenderer(writer);

// Renders Jupyter Document to Json (to the writer)
renderer.Render(markdownDocument);

// Gets the rendered string
var result = writer.ToString();
```

Convert To Pdf : 
```csharp
//TODO : 
```
