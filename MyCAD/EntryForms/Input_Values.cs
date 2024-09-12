using System;
using System.Data.SQLite;
using System.Data;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using System.Reflection;

namespace MyCAD.EntryForms
{
    public partial class Input_Values : Form
    {
        static string lConnectionString;
        static string lPath;
        static string lFullPath;
        static string lConnectionParams;

        public Input_Values()
        {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.CellClick += DataGridView1_CellClick;

            AppDomain.CurrentDomain.SetData("DataDirectory", AppDomain.CurrentDomain.BaseDirectory);

            lConnectionString = ConfigurationManager.ConnectionStrings["SQLiteConnection"].ConnectionString;
            lPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            lFullPath = Path.Combine(lPath, lConnectionString);
            lConnectionParams = ConfigurationManager.AppSettings["SQLiteParams"];
            lConnectionString = string.Format(lConnectionParams, lFullPath);
            MessageBox.Show(lConnectionString);
        }


        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                SelectRow(e.RowIndex);

                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                if (selectedRow.Cells[0].Value != null)
                    idTextBox.Text = selectedRow.Cells[0].Value.ToString();
                else
                    idTextBox.Text = string.Empty;

                if (selectedRow.Cells[1].Value != null)
                    materialTextBox.Text = selectedRow.Cells[1].Value.ToString();
                else
                    materialTextBox.Text = string.Empty;

                if (selectedRow.Cells[2].Value != null)
                    tensileStrengthTextBox.Text = selectedRow.Cells[2].Value.ToString();
                else
                    tensileStrengthTextBox.Text = string.Empty;
            }
        }   

        private double _parentMaterialThickness = 0.0;
        private double _weldLegSize = 0.0;
        private void Input_Values_Load(object sender, EventArgs e)
        {
            // Define the connection string (adjust the path to your SQLite database file)
            //string connectionString = "Data Source=C:\\Users\\223139002\\source\\repos\\Stress-Analysis-Automation\\MyCAD\\SQLite\\Files\\AppTables.db;Version=3;";

            using (SQLiteConnection connection = new SQLiteConnection(lConnectionString))
            {
                try
                {
                    // Open the connection
                    connection.Open();

                    // Define the query to retrieve data from the Materials table
                    string query = "SELECT Id, Material, TensileStrength FROM Materials"; // Ensure 'Id' column is included

                    // Create a new SQLite data adapter
                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection))
                    {
                        // Create a new DataTable to hold the data
                        DataTable dataTable = new DataTable();

                        // Fill the DataTable with data from the database
                        adapter.Fill(dataTable);

                        // Bind the DataTable to the DataGridView
                        dataGridView1.DataSource = dataTable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            //string connectionString = "Data Source=C:\\Users\\223139002\\source\\repos\\Stress-Analysis-Automation\\MyCAD\\SQLite\\Files\\AppTables.db;Version=3;";

            this.Validate();
            var tables = SQLiteScript.GetTableNames();

            var TableColumns = SQLiteScript.GetTableColumns(tables[0]);

            string id = idTextBox.Text.ToString();
            string material = materialTextBox.Text.ToString();
            string tensileStrength = tensileStrengthTextBox.Text.ToString();

            string [] values = { id, material, tensileStrength};

            SQLiteScript.AddTableValuesToDB(values);
            string query = "SELECT Id, Material, TensileStrength FROM Materials";

            using (SQLiteConnection connection = new SQLiteConnection(lConnectionString))
            {

                connection.Open();

                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection))
                {
                    DataTable dataTable = new DataTable();

                    adapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;
                }
            }
        }

        private void MaterialsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (!(double.TryParse(tensileStrengthTextBox.Text, out double _tensileStrength) &&
            (_tensileStrength > 0)))
            {
                MessageBox.Show("Incorrect Tensile Strength input.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult result;
            result = MessageBox.Show("Are you sure you want to save changes?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                this.Validate();
                this.dataGridView1.EndEdit();
                //this.dataGridView1.Update(dataGridView1.Materials);
            }
        }

        private void BindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (int.TryParse(idTextBox.Text, out int _idMaterial) &&
            (_idMaterial >= 1) && (_idMaterial <= 14))
            {
                MessageBox.Show("Can not delete a standard material.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.Validate();
            //this.dataGridView1.;
        }

        private void TextBox_Course_Leave(object sender, EventArgs e)
        {
            TextBox AnyTextBox = sender as TextBox;
            if (double.TryParse(AnyTextBox.Text, out double value))
            {
                return;
            }
            MessageBox.Show("Please, enter a VALID number.");
            AnyTextBox.Text = "0";
        }

        private void Ok_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tensileStrengthTextBox.Text))
            {
                MessageBox.Show("Select material, please.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tensileStrengthTextBox.Focus();
                return;
            }
            if (string.IsNullOrEmpty(parent_material_thickness_textBox.Text) || (Convert.ToDouble(parent_material_thickness_textBox.Text) <= 0))
            {
                MessageBox.Show("Parent material thickness is not correct.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (PassInputValuesToGraphicsForm())
            {
                double.TryParse(tensileStrengthTextBox.Text, out double TensileStrength_su);
                GraphicsForm.instance.TensileStrengthUltimate = TensileStrength_su;
                GraphicsForm.instance.ExecuteCalculation();
                AllowableForceLabel.Text = Convert.ToString(GraphicsForm.instance.AllowableForcePerInchOfWeld);
                ResultantForceLabel.Text = Convert.ToString(GraphicsForm.instance.ALLRF);
                FoSLabel.Text = Convert.ToString(GraphicsForm.instance.FoS);
                MessageBox.Show("Calculation completed.");
            }
        }

        private bool PassInputValuesToGraphicsForm()
        {
            try
            {
                GraphicsForm.instance.Fx = Convert.ToDouble(Fx_textBox.Text);
                GraphicsForm.instance.Fy = Convert.ToDouble(Fy_textBox.Text);
                GraphicsForm.instance.Fz = Convert.ToDouble(Fz_textBox.Text);
                GraphicsForm.instance.Mx = Convert.ToDouble(Mx_textBox.Text);
                GraphicsForm.instance.My = Convert.ToDouble(My_textBox.Text);
                GraphicsForm.instance.Mz = Convert.ToDouble(Mz_textBox.Text);
                GraphicsForm.instance.ParentMaterialThickness = Convert.ToDouble(parent_material_thickness_textBox.Text);
                GraphicsForm.instance.WeldLegSize = Convert.ToDouble(weld_size_textBox.Text);
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("Error. Check inputs and try again.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        private void Cancel_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Weld_size_textBox_TextChanged(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(weld_size_textBox.Text)) && double.TryParse(weld_size_textBox.Text, out _weldLegSize))
            {
                _parentMaterialThickness = _weldLegSize * 4 / 3;
                parent_material_thickness_textBox.Text = Convert.ToString(_parentMaterialThickness);
            }
            else
                MessageBox.Show("Parenet material thickness is not correct", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void SelectRow(int rowIndex)
        {
            if (rowIndex >= 0 && rowIndex < dataGridView1.Rows.Count)
            {
                dataGridView1.ClearSelection(); 
                dataGridView1.Rows[rowIndex].Selected = true; 
                dataGridView1.FirstDisplayedScrollingRowIndex = rowIndex;
            }
            else
            {
                MessageBox.Show("Row index out of range.");
            }
        }
    }
}
