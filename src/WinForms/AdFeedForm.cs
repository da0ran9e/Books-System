using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms
{
    public partial class AdFeedForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\vuduc\OneDrive\Documents\BX.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;

        public AdFeedForm()
        {
            InitializeComponent();
        }

        private void getAdImage(int index)
        {

            try
            {
                cmd = new SqlCommand("select [imageURLL] from books where [index] = " + index, con);
                con.Open();
                dr = cmd.ExecuteReader();
                dr.Read();

                if (dr.HasRows)
                {
                    string url = dr.GetFieldValue<string>(0);
                    label1.Text = url;

                    HttpClient client = new HttpClient();
                    try
                    {
                        client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/93.0.4577.63 Safari/537.36");
                        HttpResponseMessage response = client.GetAsync(url).Result;
                        response.EnsureSuccessStatusCode();

                        using (Stream stream = response.Content.ReadAsStreamAsync().Result)
                        {
                            Image image = Image.FromStream(stream);
                            string imgPath = "../../../../../assets/temps/temp" + index + ".jpg";
                            image.Save(imgPath);
                            label1.Image = Image.FromFile(imgPath);
                        }
                    }
                    catch (Exception ex)
                    {
                        label1.Text = "Error: " + ex.Message;
                    }
                }
                else
                {
                    dr.Close();
                    con.Close();
                    getAdImage(index + 1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // close the reader
                if (dr != null)
                {
                    dr.Close();
                }

                //Close the connection
                if (con != null)
                {
                    con.Close();
                }
            }
        }

        private void AdFeedForm_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.ColorTranslator.FromHtml("#010000");
            EnableBlur();
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            AppUtils.EnableAcrylic(this, Color.Transparent);
            base.OnHandleCreated(e);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            e.Graphics.Clear(Color.Transparent);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            int range = 1000;
            Random rand = new Random();
            int randIndex = rand.Next(1, range);

            getAdImage(randIndex);
        }
    }
}
