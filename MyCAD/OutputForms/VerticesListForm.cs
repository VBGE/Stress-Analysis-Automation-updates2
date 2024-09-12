using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MyCAD.OutputForms
{
    public partial class VerticesListForm : Form
    {
        DataTable table = new DataTable("table");
        public List<Entities.Point> Vertices { get; set; }
        public Vector3 ResultingRealCentroid { get; set; }

        public VerticesListForm()
        {
            InitializeComponent();
        }

        private void TableBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tableBindingSource.EndEdit();
        }

        private void VerticesListForm_Load(object sender, EventArgs e)
        {
            table.Columns.Add("ID", Type.GetType("System.Int32"));
            table.Columns.Add("X", Type.GetType("System.Double"));
            table.Columns.Add("Y", Type.GetType("System.Double"));
            table.Columns.Add("Z", Type.GetType("System.Double"));
            table.Columns.Add("Distance to Centroid", Type.GetType("System.Double"));
            dataGridView1.DataSource = table;
            DistanceEachVertexToCentroid();
        }
        private void AddVerticeToTable(int index, Entities.Point vertice, double distanceVerticeToCentroid) //distance to centroid
        {
            table.Rows.Add(index, vertice.Position.X, vertice.Position.Y, vertice.Position.Z, distanceVerticeToCentroid);
        }

        private void DistanceEachVertexToCentroid()
        {
            double distanceVerticeToCentroid = 0.0; //Distance of current point to each vertex.
            int index = 0;
            if (Vertices.Count > 0)
            {
                foreach (Entities.Point vertice in Vertices)
                {
                    distanceVerticeToCentroid = 
                        Math.Sqrt(Math.Pow((ResultingRealCentroid.X - vertice.Position.X), 2) + 
                        Math.Pow((ResultingRealCentroid.Y - vertice.Position.Y), 2) + 
                        Math.Pow((ResultingRealCentroid.Z - vertice.Position.Z), 2));
                    AddVerticeToTable(index, vertice, distanceVerticeToCentroid);
                    index++;
                }
            }
        }
    }
}
