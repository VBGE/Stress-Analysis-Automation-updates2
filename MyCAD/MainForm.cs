using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MyCAD
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private ToolStripMenuItem windowsBtn = new ToolStripMenuItem();
        private GraphicsForm graphics;
        private int counter = 1;
        private string Separator = "---------------------------";

        private void newBtn_Click(object sender, EventArgs e)
        {
            CreateNewWindow();
        }

        private void CreateNewWindow()
        {
            windowsBtn.Name = "windowsBtn";
            windowsBtn.Text = "Windows";
            windowsBtn.Size = new Size(120, 28);
            var item = mainmenu.Items.IndexOf(windowsBtn);
            if (item == -1)
            {
                mainmenu.Items.Add(windowsBtn);
                mainmenu.MdiWindowListItem = windowsBtn;
            }
            graphics = new GraphicsForm();
            graphics.Name = string.Concat("Graphics", counter.ToString());
            graphics.Text = graphics.Name;
            graphics.MdiParent = this;
            graphics.Show();
            graphics.WindowState = FormWindowState.Maximized;
            counter++;
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveBtn.Visible = windowsBtn.HasDropDownItems && (graphics.DrawingCanvasObjects.Count() > 0);
        }

        #region Save button click
        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog1.FileName;
                List<string> outputText = new List<string>();
                AddRealWeldLinesCoordinatesToOutputText(outputText);
                outputText.Add(Separator);
                AddObjectsCoordinatesToOutputText(outputText);
                File.WriteAllLines(filePath, outputText);
            }
        }

        private void AddRealWeldLinesCoordinatesToOutputText(List<string> outputText)
        {
            int i = 0;
            foreach (var line in graphics.RealWeldLines)
            {
                i = AddRealWeldCoordinatesToOutputText(outputText, i, line);
            }
        }

        private int AddObjectsCoordinatesToOutputText(List<string> outputText)
        {
            int i = 0;
            foreach (var entity in graphics.DrawingCanvasObjects)
            {
                if (entity is Entities.Point)
                {
                    Entities.Point point = entity as Entities.Point;
                    if (point.IsCentroid) continue;
                    AddOriginPointToOutputText(outputText, i, point);
                }
                if (entity is Entities.Line)
                {
                    Entities.Line line = entity as Entities.Line;
                    if (line.IsPerpendicularVector || line.IsVector) continue;
                    AddScreenLineToOutputText(outputText, i, line);
                }
                i++;
            }
            return i;
        }

        private static void AddScreenLineToOutputText(List<string> outputText, int i, Entities.Line line)
        {
            string id = Convert.ToString(i);
            string x1 = Convert.ToString(line.StartPoint.X);
            string y1 = Convert.ToString(line.StartPoint.Y);
            string z1 = Convert.ToString(line.StartPoint.Z);
            string x2 = Convert.ToString(line.EndPoint.X);
            string y2 = Convert.ToString(line.EndPoint.Y);
            string z2 = Convert.ToString(line.EndPoint.Z);
            outputText.Add(id + "," + x1 + "," + y1 + "," + z1 + "," + x2 + "," + y2 + "," + z2);
        }

        private static void AddOriginPointToOutputText(List<string> outputText, int i, Entities.Point point)
        {
            string id = Convert.ToString(i);
            string x1 = Convert.ToString(point.Position.X);
            string y1 = Convert.ToString(point.Position.Y);
            string z1 = Convert.ToString(point.Position.Z);
            outputText.Add(id + "," + x1 + "," + y1 + "," + z1);
        }

        private static int AddRealWeldCoordinatesToOutputText(List<string> outputText, int i, Entities.Line line)
        {
            string id = Convert.ToString(i);
            string x1 = Convert.ToString(line.StartPoint.X);
            string y1 = Convert.ToString(line.StartPoint.Y);
            string z1 = Convert.ToString(line.StartPoint.Z);
            string x2 = Convert.ToString(line.EndPoint.X);
            string y2 = Convert.ToString(line.EndPoint.Y);
            string z2 = Convert.ToString(line.EndPoint.Z);
            outputText.Add(id + "," + x1 + "," + y1 + "," + z1 + "," + x2 + "," + y2 + "," + z2);
            i++;
            return i;
        }
        #endregion

        #region Open button click
        private void openBtn_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                List<string> input = File.ReadAllLines(filePath).ToList();
                if (IsDrawingFileCorrect(input))
                {
                    CreateNewWindow();
                    graphics.RealWeldLines.Clear();
                    graphics.DrawingCanvasObjects.Clear();
                    AddValuesFromFileToVariables(input);
                    graphics.IfOpenedFileLoadListsProjectionsViews();
                } else
                {
                    MessageBox.Show("Can not open this file.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private bool IsDrawingFileCorrect(List<string> input)
        {
            bool HasScreenOrigin = false;
            int SeparatorID = -1;
            for (int i = 0; i < input.Count(); i++)
            {
                if (input[i] == Separator) SeparatorID = i;
                else
                {
                    var buffer = input[i].Split(',');
                    if (HasOnlyNumbers(buffer) == false) return false;
                    if (buffer.Count() == 4 && i == (SeparatorID + 1))
                        HasScreenOrigin = true;
                    else if (buffer.Count() == 7)
                        continue;
                    else
                        return false;
                }
            }
            return HasScreenOrigin;
        }

        private bool HasOnlyNumbers(string[] buffer)
        {
            foreach (var item in buffer)
            {
                double number;
                if (Double.TryParse(item, out number))
                    continue;
                else
                    return false;
            }
            return true;
        }

        private void AddValuesFromFileToVariables(List<string> input)
        {
            bool beforeSeparator = true;
            foreach (var row in input)
            {
                if (row == "---------------------------")
                {
                    beforeSeparator = false;
                    continue;
                }
                if (beforeSeparator)
                    AddLineToRealWeldLines(row);
                else
                    AddObjectToScreenObjects(row);
            }
        }

        private void AddObjectToScreenObjects(string row)
        {
            var buffer = row.Split(',');
            if (buffer.Count() == 4)
            {
                AddOriginPointToScreenObjects(buffer);
            }
            else
            {
                AddLineToScreenObjects(buffer);
            }
        }

        private void AddLineToScreenObjects(string[] buffer)
        {
            double x1 = Convert.ToDouble(buffer[1]);
            double y1 = Convert.ToDouble(buffer[2]);
            double z1 = Convert.ToDouble(buffer[3]);
            double x2 = Convert.ToDouble(buffer[4]);
            double y2 = Convert.ToDouble(buffer[5]);
            double z2 = Convert.ToDouble(buffer[6]);
            Vector3 firsPoint = new Vector3(x1, y1, z1);
            Vector3 endPoint = new Vector3(x2, y2, z2);
            Entities.Line line = new Entities.Line(firsPoint, endPoint);
            graphics.DrawingCanvasObjects.Add(line);
        }

        private void AddOriginPointToScreenObjects(string[] buffer)
        {
            double x = Convert.ToDouble(buffer[1]);
            double y = Convert.ToDouble(buffer[2]);
            double z = Convert.ToDouble(buffer[3]);
            Vector3 p = new Vector3(x, y, z);
            Entities.Point point = new Entities.Point(p);
            graphics.DrawingCanvasObjects.Add(point);
            graphics.DrawingCanvasOrigin = p;
        }

        private void AddLineToRealWeldLines(string row)
        {
            var buffer = row.Split(',');
            double x1 = Convert.ToDouble(buffer[1]);
            double y1 = Convert.ToDouble(buffer[2]);
            double z1 = Convert.ToDouble(buffer[3]);
            double x2 = Convert.ToDouble(buffer[4]);
            double y2 = Convert.ToDouble(buffer[5]);
            double z2 = Convert.ToDouble(buffer[6]);
            Vector3 firsPoint = new Vector3(x1, y1, z1);
            Vector3 endPoint = new Vector3(x2, y2, z2);
            Entities.Line line = new Entities.Line(firsPoint, endPoint);
            graphics.RealWeldLines.Add(line);
        }
        #endregion

        private void exitBtn_Click(object sender, EventArgs e)
        {
            if (Application.MessageLoop)
                Application.Exit(); // WinForms app
            else
                Environment.Exit(1); // Console app
        }

    }
}
