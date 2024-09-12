using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyCAD.EntryForms
{
    public partial class SetStartPoint : Form
    {
        public Vector3 ResultingStartPointReal { get; private set; } = new Vector3(0.00, 0.00, 0.00);
        public Vector3 ResultingStartPointDrawingCanvas { get; private set; } = new Vector3(0.00, 0.00, 0.00);

        private int _drawingCanvasObjectIndex = GraphicsForm.instance.DrawingCanvasObjectIndex;
        private Entities.Line _drawingCanvasLine = new Entities.Line();
        private Entities.Line _realWeldLine = new Entities.Line();

        public SetStartPoint()
        {
            InitializeComponent();

            _drawingCanvasLine = GraphicsForm.instance.DrawingCanvasObjects[_drawingCanvasObjectIndex] as Entities.Line;
            _realWeldLine = GraphicsForm.instance.RealWeldLines[_drawingCanvasObjectIndex - 1]; //Drawing canvas index is greater by one because it also has a point at the beginning
            AddImportedValuesToTextBoxes();
            linesLengthTextBox.Text = Convert.ToString(_realWeldLine.Length);
        }

        private void StartPoint_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            const int _StartPoint = 0;
            const int _EndPoint = 1;
            switch (StartDrawing_ComboBox.SelectedIndex)
            {
                case _StartPoint:
                    HighlightLineSelectedStartPoint();
                    ResultingStartPointReal = _realWeldLine.StartPoint;
                    ResultingStartPointDrawingCanvas = _drawingCanvasLine.StartPoint;
                    break;
                case _EndPoint:
                    HighlightLineSelectedEndPoint();
                    ResultingStartPointReal = _realWeldLine.EndPoint;
                    ResultingStartPointDrawingCanvas = _drawingCanvasLine.EndPoint;
                    break;
            }
        }

        private void Accept_btn_Click(object sender, EventArgs e)
        {
            if (StartDrawing_ComboBox.SelectedIndex>=0)
            {
                this.DialogResult = DialogResult.OK;
                return;
            }
            MessageBox.Show("Select a starting point in combo box", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddImportedValuesToTextBoxes()
        {
            x1_txtbox.Text = string.Format("{0,0:F3}", _realWeldLine.StartPoint.X);
            y1_txtbox.Text = string.Format("{0,0:F3}", _realWeldLine.StartPoint.Y);
            z1_txtbox.Text = string.Format("{0,0:F3}", _realWeldLine.StartPoint.Z);
            x2_txtbox.Text = string.Format("{0,0:F3}", _realWeldLine.EndPoint.X);
            y2_txtbox.Text = string.Format("{0,0:F3}", _realWeldLine.EndPoint.Y);
            z2_txtbox.Text = string.Format("{0,0:F3}", _realWeldLine.EndPoint.Z);
        }

        private void HighlightLineSelectedEndPoint()
        {
            x1_label.Enabled = false;
            y1_label.Enabled = false;
            z1_label.Enabled = false;
            z2_label.Enabled = true;
            y2_label.Enabled = true;
            x2_label.Enabled = true;
        }

        private void HighlightLineSelectedStartPoint()
        {
            x1_label.Enabled = true;
            y1_label.Enabled = true;
            z1_label.Enabled = true;
            z2_label.Enabled = false;
            y2_label.Enabled = false;
            x2_label.Enabled = false;
        }

    }
}
