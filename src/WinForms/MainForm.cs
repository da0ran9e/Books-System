using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            EnableBlur();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FlowLayoutPanel1_MouseWheel(object sender, MouseEventArgs e)
        {
            int value = flowLayoutPanel1.VerticalScroll.Value + e.Delta;
            int max = flowLayoutPanel1.HorizontalScroll.Maximum;
            int min = flowLayoutPanel1.HorizontalScroll.Minimum;
            if (value < max && value > min)
            {
                flowLayoutPanel1.VerticalScroll.Value = value;
            }

        }
    }
}
