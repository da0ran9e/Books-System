using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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
            //EnableBlur();


            DateTime currentTime = DateTime.Now;

            int hour = currentTime.Hour;

            // Determine the time range
            string timeRange;

            if (hour >= 0 && hour < 6)
            {
                timeRange = "night";
            }
            else if (hour >= 6 && hour < 12)
            {
                timeRange = "morning";
            }
            else if (hour >= 12 && hour < 18)
            {
                timeRange = "afternoon";
            }
            else
            {
                timeRange = "evening";
            }
            helloLabel.Text = $"Good {timeRange}!";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private Rectangle _displayRect = Rectangle.Empty;
        private void FlowLayoutPanel1_MouseWheel(object sender, MouseEventArgs e)
        {
            Rectangle panelRectangle = verticalMenuBar.ClientRectangle;
            Point cursorPos = Cursor.Position;

            if (true)
            {
                int pos = -_displayRect.Y;
                int maxPos = -(panelRectangle.Height - _displayRect.Height);

                pos = Math.Max(pos - e.Delta, 0);
                pos = Math.Min(pos, maxPos);

                SetDisplayRectLocation(_displayRect.X, -pos);
            }

        }

        private void userLabel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MainForm_MouseWheel(object sender, MouseEventArgs e)
        {

        }


        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void homeLabel_Click(object sender, EventArgs e)
        {

        }

        private void label39_Click(object sender, EventArgs e)
        {
        }


        private void searchFlowPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bestMatchPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void contentContainer_Paint(object sender, PaintEventArgs e)
        {
            LinearGradientBrush lgb = new LinearGradientBrush(contentContainer.ClientRectangle, Color.Red, contentContainer.BackColor, 90F);
            Graphics g = e.Graphics;
            g.FillRectangle(lgb, contentContainer.ClientRectangle);
        }
    }
}
