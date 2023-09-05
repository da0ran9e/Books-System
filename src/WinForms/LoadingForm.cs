using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinForms
{
    public partial class LoadingForm : Form
    {
        

        public int value;
        public int totalValue;
        public string readerName;

        public LoadingForm(string readerName)
        {
            this.readerName = readerName;
            this.totalValue = 100;
            this.value = 0;
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        static void SetDoubleBuffer(Control ctl, bool DoubleBuffered)
        {
            try
            {
                typeof(Control).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
                    BindingFlags.Instance |
                    BindingFlags.SetProperty,
                null, ctl, new object[] { DoubleBuffered });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private async void LoadingForm_LoadAsync(object sender, EventArgs e)
        {
            SetDoubleBuffer(tableLayoutPanel1, true);
            SetDoubleBuffer(grad0, true);
            this.BackColor = System.Drawing.ColorTranslator.FromHtml("#010000");
            progressBar.BackColor = System.Drawing.ColorTranslator.FromHtml("#010000");
            EnableBlur();

            int colorR = 245;
            int colorB = 162;
            int colorG = 162;
            while (this.Visible)
            {
                for (int i = 162; i <= 245; i++)
                {
                    colorG = i;
                    grad0.GradientAngle++;
                    grad0.GradientPrimaryColor = Color.FromArgb(colorR, colorG, colorB);
                    loadingLabel.ForeColor = Color.FromArgb(colorR, colorG, colorB);
                    progressBar.Value = (value / totalValue) * 100;
                    grad0.Invalidate();
                    await Task.Delay(20);
                }
                for (int i = 245; i >= 162; i--)
                {
                    colorR = i;
                    grad0.GradientAngle++;
                    grad0.GradientPrimaryColor = Color.FromArgb(colorR, colorG, colorB);
                    loadingLabel.ForeColor = Color.FromArgb(colorR, colorG, colorB);
                    progressBar.Value = (value / totalValue) * 100;
                    grad0.Invalidate();
                    await Task.Delay(20);
                }
                for (int i = 162; i <= 245; i++)
                {
                    colorB = i;
                    grad0.GradientAngle++;
                    grad0.GradientPrimaryColor = Color.FromArgb(colorR, colorG, colorB);
                    loadingLabel.ForeColor = Color.FromArgb(colorR, colorG, colorB);
                    progressBar.Value = (value / totalValue) * 100;
                    grad0.Invalidate();
                    await Task.Delay(20);
                }
                for (int i = 245; i >= 162; i--)
                {
                    colorG = i;
                    grad0.GradientAngle++;
                    grad0.GradientPrimaryColor = Color.FromArgb(colorR, colorG, colorB);
                    loadingLabel.ForeColor = Color.FromArgb(colorR, colorG, colorB);
                    progressBar.Value = (value / totalValue) * 100;
                    grad0.Invalidate();
                    await Task.Delay(20);
                }
                for (int i = 162; i <= 245; i++)
                {
                    colorR = i;
                    grad0.GradientAngle++;
                    grad0.GradientPrimaryColor = Color.FromArgb(colorR, colorG, colorB);
                    loadingLabel.ForeColor = Color.FromArgb(colorR, colorG, colorB);
                    progressBar.Value = (value / totalValue) * 100;
                    grad0.Invalidate();
                    await Task.Delay(20);
                }
                for (int i = 245; i >= 162; i--)
                {
                    colorB = i;
                    grad0.GradientAngle++;
                    grad0.GradientPrimaryColor = Color.FromArgb(colorR, colorG, colorB);
                    loadingLabel.ForeColor = Color.FromArgb(colorR, colorG, colorB);
                    progressBar.Value = (value / totalValue) * 100;
                    grad0.Invalidate();
                    await Task.Delay(20);
                }
            }
        }
        private async void LoadingForm_LoadAsync2(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.ColorTranslator.FromHtml("#010000");
            progressBar.BackColor = System.Drawing.ColorTranslator.FromHtml("#010000");
            EnableBlur();

            Library library = new Library();
            library.GetReaderInformation(readerName);
            progressBar.Value = 10;
            library.GetBooks();
            progressBar.Value = 50;
            library.GetRatings();
            progressBar.Value = 80;

            MainForm mainForm = new MainForm(library);
            progressBar.Value = 100;
            mainForm.ShowDialog();
            this.Visible = false;
        }


        

    }
}
