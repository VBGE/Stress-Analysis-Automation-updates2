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
    public partial class SetLineLengthForm : Form
    {
        public SetLineLengthForm()
        {
            InitializeComponent();
        }

        public double UserLineLength { get; private set; }

        private void Accept_btn_Click(object sender, EventArgs e)
        {
            if (double.TryParse(LineLengthTextBox.Text, out double _inputLength) && 
                (_inputLength > 0) && 
                !(string.IsNullOrEmpty(LineLengthTextBox.Text)))
            {
                UserLineLength = Convert.ToDouble(LineLengthTextBox.Text);
                this.DialogResult = DialogResult.OK;
                return;
            }
            MessageBox.Show("Please enter a VALID positive number");
        }
        private void cancel_btn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
