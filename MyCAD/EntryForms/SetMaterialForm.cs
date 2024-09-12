using System;
using System.Windows.Forms;

namespace MyCAD
{
    public partial class SetMaterial : Form
    {
        public SetMaterial()
        {
            InitializeComponent();
        }

        public double TensileStrength_su { get; private set; }

        private void SetMaterial_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'materialsDBDataSet.Materials' table. You can move, or remove it, as needed.
            //this.materialsTableAdapter.Fill(this.materialsDBDataSet.Materials);
        }
        
        private void Ok_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tensileStrengthTextBox.Text))
            {
                MessageBox.Show("Select material, please.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tensileStrengthTextBox.Focus();
                return;
            }
            double.TryParse(tensileStrengthTextBox.Text, out double TensileStrength_su);
            GraphicsForm.instance.TensileStrengthUltimate = TensileStrength_su;
            this.DialogResult = DialogResult.OK;
        }

        private void Cancel_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.materialsBindingSource1.AddNew();
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
                this.materialsBindingSource1.EndEdit();
                //this.materialsTableAdapter.Update(materialsDBDataSet.Materials);
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
            this.materialsBindingSource1.RemoveCurrent();
        }
    }
}
