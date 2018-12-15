# JupyterSharpParser
[![Build status](https://ci.appveyor.com/api/projects/status/awnpnnvevkj51b8m?svg=true)](https://ci.appveyor.com/project/andy840119/jupytersharpparser) 
[![CodeFactor](https://www.codefactor.io/repository/github/andy840119/jupytersharpparser/badge)](https://www.codefactor.io/repository/github/andy840119/jupytersharpparser)
[![NuGet](https://img.shields.io/nuget/v/JupyterSharpParser.svg)](https://www.nuget.org/packages/JupyterSharpParser)
[![NuGet](https://img.shields.io/nuget/dt/JupyterSharpParser.svg)](https://www.nuget.org/packages/JupyterSharpParser)
[![NuGet](https://img.shields.io/badge/月子我婆-passed-ff69b4.svg)](https://github.com/andy840119/JupyterSharpParser)

Jupyter parser written in C#

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
renderer.Render(document);

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
renderer.Render(document);

// Gets the rendered string
var result = writer.ToString();
```

Convert To Pdf : 
```csharp
//Note : Due to Select.HtmlToPdf.NetCore, PDF limited to most 5 page,
//       And cannot work on other platform such as mac and linux.

// Output
using(var stream = new FileStream("fileName"))
{
    // Create a HTML Renderer and setup it with the pipeline
    var renderer = new PdfRenderer(stream);

    // Renders Jupyter Document to Json (to the writer)
    renderer.Render(document);  
}
```
