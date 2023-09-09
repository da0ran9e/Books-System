using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinForms
{
    public partial class LoadingForm : Form
    {


        public int value;
        public int totalValue;
        public string readerName;
        public class responseString
        {
            [JsonPropertyName("recommended_isbns")]
            public List<string> isbn { get; set; }
        }

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

        private async Task<string> MakeRequest(string url)
        {
            HttpClient client = new HttpClient();
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return content;
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                return null;
            }
        }

        private List<string> ReadRequest(string jsonString)
        {
            List<string> result = new List<string>();
            try
            {
                var response = JsonSerializer.Deserialize<responseString>(jsonString);

                // Access the recommended ISBNs
                var recommendedIsbns = response.isbn;

                foreach (var isbn in recommendedIsbns)
                {
                    result.Add(isbn.ToString());
                }
            }
            catch (Exception ex)
            {
                
            }
            return result;
        }

        private async void LoadingForm_LoadAsync2(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.ColorTranslator.FromHtml("#010000");
            progressBar.BackColor = System.Drawing.ColorTranslator.FromHtml("#010000");
            EnableBlur();

            Library library = new Library();

            progressLabel.Text = "Getting data!";

            library.GetReaderInformation(readerName);
            progressBar.Value = 10;
            progressLabel.Text = "Getting books data!";
            library.GetBooks();
            progressBar.Value = 40;
            progressLabel.Text = "Getting rating data!";
            library.GetRatings();
            progressBar.Value = 70;

            progressLabel.Text = "Making request!";
            int uid = library.reader.userId;
            string apiUrl = "http://127.0.0.1:8000/recommendations/" + uid.ToString();
            string response = await MakeRequest(apiUrl);
            progressLabel.Text = "Processing request!";
            List<string> result = ReadRequest(response);
            foreach (string item in result)
            {
                progressLabel.Text = item;
            }
            

            progressBar.Value = 95;
            //progressLabel.Text = response;
            MainForm mainForm = new MainForm(library, result);
            this.Visible = false;
            progressBar.Value = 100;


            mainForm.ShowDialog();

        }




    }
}
