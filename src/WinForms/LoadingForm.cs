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

namespace WinForms
{
    public partial class LoadingForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\vuduc\OneDrive\Documents\BX.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;

        private readonly MethodInvoker method;
        public LoadingForm(MethodInvoker action)
        {
            InitializeComponent();
            method = action;
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
            EnableBlur();
            int colorR = 214;
            int colorB = 39;
            int colorG = 39;
            while (this.Visible)
            {
                for (int i = 39; i <= 214; i++)
                {
                    colorG = i;
                    grad0.GradientAngle++;
                    grad0.GradientPrimaryColor = Color.FromArgb(colorR, colorG, colorB);
                    grad0.Invalidate();
                    await Task.Delay(50);
                }
                for (int i = 214; i >= 39; i--)
                {
                    colorR = i;
                    grad0.GradientAngle++;
                    grad0.GradientPrimaryColor = Color.FromArgb(colorR, colorG, colorB);
                    grad0.Invalidate();
                    await Task.Delay(50);
                }
                for (int i = 39; i <= 214; i++)
                {
                    colorB = i;
                    grad0.GradientAngle++;
                    grad0.GradientPrimaryColor = Color.FromArgb(colorR, colorG, colorB);
                    grad0.Invalidate();
                    await Task.Delay(50);
                }
                for (int i = 214; i >= 39; i--)
                {
                    colorG = i;
                    grad0.GradientAngle++;
                    grad0.GradientPrimaryColor = Color.FromArgb(colorR, colorG, colorB);
                    grad0.Invalidate();
                    await Task.Delay(50);
                }
                for (int i = 39; i <= 214; i++)
                {
                    colorR = i;
                    grad0.GradientAngle++;
                    grad0.GradientPrimaryColor = Color.FromArgb(colorR, colorG, colorB);
                    grad0.Invalidate();
                    await Task.Delay(50);
                }
                for (int i = 214; i >= 39; i--)
                {
                    colorB = i;
                    grad0.GradientAngle++;
                    grad0.GradientPrimaryColor = Color.FromArgb(colorR, colorG, colorB);
                    grad0.Invalidate();
                    await Task.Delay(50);
                }
            }
        }


        private void LoadingForm_Load(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                method.Invoke();
                InvokeAction(this, Dispose);
            }).Start();
        }

        public static void InvokeAction(Control control, MethodInvoker action)
        {
            if (control.InvokeRequired)
            {
                control.BeginInvoke(action);
            }
            else
            {
                action();
            }
        }
    }
}
