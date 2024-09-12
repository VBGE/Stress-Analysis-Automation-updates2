using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyCAD.OutputForms
{
    public partial class LinesListForm : Form
    {
        DataTable LinesTable = new DataTable("table1");
        public List<Entities.Line> Lines{ get; set; }

        public LinesListForm()
        {
            InitializeComponent();
        }

        private void LinesListForm_Load(object sender, EventArgs e)
        {
            LinesTable.Columns.Add("ID", Type.GetType("System.Int32"));
            LinesTable.Columns.Add("X1", Type.GetType("System.Double"));
            LinesTable.Columns.Add("Y1", Type.GetType("System.Double"));
            LinesTable.Columns.Add("Z1", Type.GetType("System.Double"));
            LinesTable.Columns.Add("X2", Type.GetType("System.Double"));
            LinesTable.Columns.Add("Y2", Type.GetType("System.Double"));
            LinesTable.Columns.Add("Z2", Type.GetType("System.Double"));
            LinesTable.Columns.Add("Length", Type.GetType("System.Double"));
            dataGridView1.DataSource = LinesTable;
            FillTableImportedLines();
        }

        private void AddLineToTable(int idx, Entities.Line L) //distance to centroid
        {
            LinesTable.Rows.Add(idx, L.StartPoint.X, L.StartPoint.Y, L.StartPoint.Z, L.EndPoint.X, L.EndPoint.Y, L.EndPoint.Z, L.Length);
        }

        private void FillTableImportedLines()
        {
            int i = 0;
            if (Lines.Count > 0)
            {
                foreach (Entities.Line L in Lines)
                {
                    AddLineToTable(i, L);
                    i++;
                }
            }
        }

    }
}
