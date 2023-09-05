using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.ApplicationServices;

namespace WinForms
{
    public class Library
    {
        private SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\vuduc\OneDrive\Documents\BX.mdf;Integrated Security=True;Connect Timeout=30");
        private SqlCommand cmd = new SqlCommand();
        private SqlDataReader dr;

        public List<Book> bookSelves = new List<Book>();
        public List<UserRating> bookRatings = new List<UserRating>();
        public User reader = new User();

        //the average score of books
        public struct Score
        {
            public int avgScore { get; set; }
            public int totalRate { get; set; }

            public Score(int score, int count)
            {
                this.avgScore = score;
                this.totalRate = count;
            }
        }
        public Dictionary<Book, Score> bookScores = new Dictionary<Book, Score>();

        //
        // Method
        //
        public void GetBooks() // Get list of informations of all books in database containing: id, isbn, title, author,...
        {   
            try
            {
                cmd = new SqlCommand("select * from books", con);
                con.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Book book = new Book();

                    book.index = dr.GetFieldValue<int>(0);
                    book.isbn = dr.GetFieldValue<string>(1);
                    book.title = dr.GetFieldValue<string>(2);
                    book.author = dr.GetFieldValue<string>(3);
                    book.year = dr.GetFieldValue<int>(4);
                    book.publisher = dr.GetFieldValue<string>(5);
                    book.sURL = dr.GetFieldValue<string>(6);
                    book.mURL = dr.GetFieldValue<string>(7);
                    book.lURL = dr.GetFieldValue<string>(8);

                    this.bookSelves.Add(book);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Get Book exception: " + ex.Message);
            }
            finally
            {
                if (dr != null) dr.Close();
                if (con != null) con.Close();
            }
        }

        public void GetRatings() //Get the list of ratings information of all users
        {
            try
            {
                cmd = new SqlCommand("select * from ratings", con);
                con.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    UserRating rating = new UserRating();

                    rating.userId = dr.GetFieldValue<int>(0);
                    rating.isbn = dr.GetFieldValue<string>(1);
                    rating.rate = dr.GetFieldValue<byte>(2);

                    this.bookRatings.Add(rating);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Get Ratings exception: " + ex.Message);
            }
            finally
            {
                if (dr != null) dr.Close();
                if (con != null) con.Close();
            }
        }

        public void GetReaderInformation(string name) //Get user information containing: uid, username, firstname, lastname, ...
        {
            try
            {
                cmd = new SqlCommand("select * from users where [username] = '" + name + "'", con);
                con.Open();
                dr = cmd.ExecuteReader();
                dr.Read();

                User user = new User();

                user.userId = dr.GetFieldValue<int>(0);
                user.fname = dr.IsDBNull("firstName") ? null : dr.GetFieldValue<string>("firstName");
                user.lname = dr.IsDBNull("lastName") ? null : dr.GetFieldValue<string>("lastName");
                user.username = dr.GetFieldValue<string>("username");
                user.password = dr.GetFieldValue<string>(4);
                user.email = dr.IsDBNull("email") ? null : dr.GetFieldValue<string>("email");
                user.phone = dr.IsDBNull("phone") ? null : dr.GetFieldValue<string>("phone");
                user.gender = dr.IsDBNull("gender") ? (byte)0 : dr.GetFieldValue<byte>(7);
                user.date = dr.IsDBNull("birthDate") ? new DateTime(1800, 01, 01) : dr.GetFieldValue<DateTime>("birthDate");
                user.profileImage = dr.IsDBNull("profileImage") ? null : dr.GetFieldValue<string>("profileImage");
                user.age = dr.IsDBNull("age") ? 0 : dr.GetFieldValue<int>("age");
                user.location = dr.IsDBNull("location") ? null : dr.GetFieldValue<string>("location");
                user.nation = dr.IsDBNull("nation") ? null : dr.GetFieldValue<string>("nation");

                this.reader = user;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Get Reader exception: " + ex.Message);
            }
            finally
            {
                if (dr != null) dr.Close();
                if (con != null) con.Close();
            }
        } 

        public void CalculateScore(Book b) //calculate the average score of books
        {
            int score = 0; int total = 0; int count = 0;
            List<UserRating> filter = bookRatings.Where(item => item.isbn == b.isbn).ToList();
            foreach (UserRating r in filter)
            {
                if (r.rate > 0)
                {
                    total += r.rate;
                    count++;
                }
            }
            if (count > 0)
            {
                score = total / count;
                this.bookScores.Add(b, new Score(score, count));
            }
            else
                this.bookScores.Add(b, new Score(0, 0));
        }
    }
}
