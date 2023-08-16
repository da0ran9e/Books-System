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
using System.Data.SqlClient;
using System.Reflection;

namespace WinForms
{
    public partial class MainForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\vuduc\OneDrive\Documents\BX.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;

        public MainForm(string username)
        {
            this.username = username;
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //EnableBlur();
            toolTip1.SetToolTip(userLabel, username);
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

        private void helloPanel_Paint(object sender, PaintEventArgs e)
        {
            DateTime currentTime = DateTime.Now;

            int hour = currentTime.Hour;
            string timeRange;
            LinearGradientBrush lgb = new LinearGradientBrush(helloPanel.ClientRectangle, Color.White, Color.Black, 60F);
            if (hour >= 0 && hour < 6)
            {
                timeRange = "night";
                lgb = new LinearGradientBrush(helloPanel.ClientRectangle, ColorTranslator.FromHtml("#191970"), ColorTranslator.FromHtml("#2F4F4F"), 60F);
                helloElement0.GradientSecondaryColor = ColorTranslator.FromHtml("#001F3F");
                helloElement1.GradientSecondaryColor = ColorTranslator.FromHtml("#001F3F");
                helloElement2.GradientSecondaryColor = ColorTranslator.FromHtml("#001F3F");
                helloElement3.GradientSecondaryColor = ColorTranslator.FromHtml("#001F3F");

            }
            else if (hour >= 6 && hour < 12)
            {
                timeRange = "morning";
                lgb = new LinearGradientBrush(helloPanel.ClientRectangle, ColorTranslator.FromHtml("#87CEFA"), ColorTranslator.FromHtml("#FFFFE0"), 60F);
                helloElement0.GradientSecondaryColor = ColorTranslator.FromHtml("#FDB813");
                helloElement1.GradientSecondaryColor = ColorTranslator.FromHtml("#FDB813");
                helloElement2.GradientSecondaryColor = ColorTranslator.FromHtml("#FDB813");
                helloElement3.GradientSecondaryColor = ColorTranslator.FromHtml("#FDB813");

            }
            else if (hour >= 12 && hour < 18)
            {
                timeRange = "afternoon";
                lgb = new LinearGradientBrush(helloPanel.ClientRectangle, ColorTranslator.FromHtml("#FFD700"), ColorTranslator.FromHtml("#FFB6C1"), 60F);
                helloElement0.GradientSecondaryColor = ColorTranslator.FromHtml("#87CEEB");
                helloElement1.GradientSecondaryColor = ColorTranslator.FromHtml("#87CEEB");
                helloElement2.GradientSecondaryColor = ColorTranslator.FromHtml("#87CEEB");
                helloElement3.GradientSecondaryColor = ColorTranslator.FromHtml("#87CEEB");

            }
            else
            {
                timeRange = "evening";
                lgb = new LinearGradientBrush(helloPanel.ClientRectangle, ColorTranslator.FromHtml("#663399"), ColorTranslator.FromHtml("#00008B"), 60F);
                helloElement0.GradientSecondaryColor = ColorTranslator.FromHtml("#FD5E53");
                helloElement1.GradientSecondaryColor = ColorTranslator.FromHtml("#FD5E53");
                helloElement2.GradientSecondaryColor = ColorTranslator.FromHtml("#FD5E53");
                helloElement3.GradientSecondaryColor = ColorTranslator.FromHtml("#FD5E53");

            }
            helloLabel.Text = $"Good {timeRange}!";
            Graphics g = e.Graphics;
            g.FillRectangle(lgb, helloPanel.ClientRectangle);
        }

        private void userLabel_MouseHover(object sender, EventArgs e)
        {

        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {

        }
    }
}
