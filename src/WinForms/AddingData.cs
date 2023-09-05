using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms
{
    public partial class AddingData : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\vuduc\OneDrive\Documents\BX.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;

        public AddingData(Library lib)
        {
            this.library = lib;
            InitializeComponent();
        }

        public async void Push() //Get the list of ratings information of all users
        {
            try
            {
                string[] sqlCommands = File.ReadAllLines("../../../sql/Books.sql");
                con.Open();
                int j = 0;
                int k = 0;
                foreach (string sqlCommand in sqlCommands)
                {
                    // Thực hiện từng câu lệnh SQL
                    using (SqlCommand command = new SqlCommand(sqlCommand, con))
                    {
                        try
                        {
                            command.ExecuteNonQuery();

                            j++;

                        }
                        catch (Exception ex)
                        {
                        }
                        Console.WriteLine(j);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Push exception: " + ex.Message);

            }
            finally
            {
                if (dr != null) dr.Close();
                if (con != null) con.Close();
            }
        }

        public Stream LoaderFromURL(string url)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/93.0.4577.63 Safari/537.36");
                HttpResponseMessage response = client.GetAsync(url).Result;
                response.EnsureSuccessStatusCode();

                return response.Content.ReadAsStreamAsync().Result;
            }
            catch
            {
                return null;
            }
        }

        public void GetBookImage(Book book)
        {
            if (book == null) return;
            string imgPath = "../../../../../assets/LImgs/" + book.isbn + ".jpg";
            try
            {
                // if the image does not exist, then get it
                if (!File.Exists(imgPath))
                {
                    using (Stream stream = LoaderFromURL(book.lURL))
                    {
                        Image image = Image.FromStream(stream);
                        if (image.Height <= 300)
                        {
                            image = Image.FromStream(LoaderFromURL(book.mURL));
                            if (image.Height <= 100)
                            {
                                image = Image.FromStream(LoaderFromURL(book.sURL));
                            }
                        }
                        image.Save(imgPath);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Get book image error: {ex.Message}");
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {

            // Run operation in another thread
            //Push();

            // TODO: Do something after all calculations
            int cnt = 0;
            List<Book> books = library.bookSelves;
            foreach (Book book in books) {
                GetBookImage(book);
                button1.Text = cnt++.ToString();
            }


        }
    }
}
