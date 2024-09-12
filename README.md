# Stress-Analysis-Automation
Desktop application to draw weld profile lines and calculate Factor of Safety.

## About

This desktop application allows the user to draw in a canvas 2D or even 3D weld profiles to calculate its factor of safety.
- It gets inputs from user of the forces and moments, the weld leg size (W) and the material tensile strength.
- Then it calculates the weld centroid, moments of inertia, allowable force per inch of weld and the resultant force.

## ⁠⚠️ Considerations
This app is still in development
- This application uses theory applying for **fillet welds only**.
- Avoid overlapping lines because this will affect the calculations results.
- The weld profile drawing and input forces and moments must coincide with the coordinate system shown in canvas.
- The factor of safety shown is the most critical. Meaning, the application performs iterative calculations through each vertice of the weld profile.
- You can just draw profiles with right angles.
- There is no functionality to zoom in/out the canvas drawing.
- You can not resize lines in the drawing.
- The code was made for a pre-junior dev. So it has a weak structure. Most of the logic is in the mainform and that was a huge mistake. There are no unit tests created for this.

## 🎨  Features
- Saving and opening drawings.
- Add more materials to local data base.
- Export calculation results to an excel file (shows forces calculations and analysis results over each drawing's vertice).

## Demo

https://media.github.build.ge.com/user/121379/files/3352b832-e396-44d2-8cbb-898b6dbee554



## 💾  Installation
1. Go to releases and download the zip installer from the latest version, it is in the *Assets* section.
2. Unzip the folder and run the *setup.exe* file.
3. A shortcut will be created in your desktop.

For more detailed instructions you may find [**this wiki**](https://devcloud.swcoe.ge.com/devspace/x/cM7tiw) useful.

## Tech Stack

- WinForms – Framework
- [C#](https://dotnet.microsoft.com/en-us/languages/csharp) – Language
- [Visual Studio](https://visualstudio.microsoft.com/) - IDE

## Getting Started

### Prerequisites

Here's what you need to be able to run Stress Analysis Automation:

- System Windows Forms Ribbon
- SQL Server 2012 Express LocalDB
- Microsoft Office Interop Excel
- Microsoft .NET Framework 4.6.1 (x86 and x64)

But the installation includes these requierements.

## 📙  Documentation
For more information about this project you may see the [**Confluence wiki**](https://devcloud.swcoe.ge.com/devspace/x/9cSXgg).

📌 **Need help? Have a question, or wish to ask for a missing feature?**
Do not hesitate to ask any questions to [Corella, Luis](mailto:luisisrael.corella@ge.com)
or by opening a [**github issue**](https://github.build.ge.com/223105243/Stress-Analysis-Automation/issues).
