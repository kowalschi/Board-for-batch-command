# Board for Batch Command

A Windows desktop app (C#, WinForms, .NET Core 3.1) that I designed and built on my own initiative
at INDG, where I worked as an artwork specialist in a 3D product-visualisation pipeline.

**Nobody asked for it.** I wrote it to speed up my own work, and it became the daily tool of the
whole artwork team for years.

![Board for batch command](https://github.com/user-attachments/assets/f57edca3-3779-49f2-965b-72a46a0eb9ea)

## The problem

Every job meant the same sequence, dozens of times a day: copy the artwork PDFs and their JSON
description from the server to the workstation, compose a long command line for the rendering tool
with the right options for that product, run it, wait for the PNG output to appear, check it and copy
the results back to the server. Each step was manual and easy to get wrong, and everyone on the team
did it the same way. I was the first to automate it.

## What the app does

- **Watches the clipboard** — copying a job path is enough for the app to pick up the job.
- **Scans the job folder**, reads the PDF artwork (pages, form fields, XMP metadata) and the JSON
  mapping, and fills the interface with the faces and parts of the product.
- **Builds the batch command** from checkboxes and drop-downs (DPI, texture size, cache options,
  output text, per-part colours) instead of typing it by hand.
- **Copies files** from the server to the local working folder and back.
- **Runs the command and watches the output folder** with a `FileSystemWatcher`, so the next step
  starts when the result files are created.
- **Keeps a searchable history** of generated commands and jobs.
- Shortcuts to open the job in Explorer, 3ds Max, Photoshop, Illustrator or Acrobat.

## How it was written

I knew JavaScript from scripting Adobe applications. I learned C# for this app from the .NET
documentation and Stack Overflow, in 2021–2022 — before AI coding assistants. The code shows it:
it is one large form that grew feature by feature as I needed them (version 10.6 at the last build).
It is not how I would structure it today, but it worked every day and saved the team hours every week.

## Stack

C# · Windows Forms · .NET Core 3.1 · Newtonsoft.Json · PdfPig · PDFsharp · XmpCore · SharpClipboard · Serilog

## Build

Open `WinFormsApp1.sln` in Visual Studio 2019 or later and build. Paths to the working folders are
set in the app's interface.

© Dan Ichimescu
