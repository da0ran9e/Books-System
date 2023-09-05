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

        private async void button1_Click(object sender, EventArgs e)
        {

            // Run operation in another thread
            //Push();

            // TODO: Do something after all calculations
            int cnt = 0;
            List<Book> books = library.bookSelves;
            foreach (Book book in books) {
                BookCover bookCover = new BookCover();
                bookCover.GetBookImage(book);
                button1.Text = cnt++.ToString();
            }


        }
    }
}
