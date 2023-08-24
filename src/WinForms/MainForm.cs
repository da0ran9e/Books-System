﻿using System;
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
using System.Reflection.Emit;
using System.Security.Policy;
using static WinForms.MainForm;
using System.ComponentModel.DataAnnotations;

namespace WinForms
{
    public partial class MainForm : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\vuduc\OneDrive\Documents\BX.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;

        #region  Set Control to be double buffered
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
                Console.WriteLine(ex.StackTrace);
            }
        }
        #endregion

        #region Image properties setting and get Image from URL

        //
        // Resize image
        //
        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }

        //
        //This also resize image base on given height
        //
        public static Image SetHeight(Image imgToResize, int height)
        {
            int w = imgToResize.Width;
            int h = imgToResize.Height;
            int width = (height * w / h);
            Size size = new Size(width, height);
            return (Image)(new Bitmap(imgToResize, size));
        }

        private Stream LoaderFromURL(string url)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/93.0.4577.63 Safari/537.36");
            HttpResponseMessage response = client.GetAsync(url).Result;
            response.EnsureSuccessStatusCode();

            return response.Content.ReadAsStreamAsync().Result;
        }

        private Image GetBookImage(int index)
        {
            Image img = Image.FromFile("../../../../../assets/icons/image_L.png");
            string imgPath = "../../../../../assets/LImgs/temp" + index + ".jpg";
            try
            {
                Book book = GetBookInformation(index);
                // if the image does not exist, then get it
                if (!File.Exists(imgPath))
                {
                    using (Stream stream = LoaderFromURL(book.lURL))
                    {
                        Image image = Image.FromStream(stream);
                        if (image.Height <= 20)
                        {
                            image = Image.FromStream(LoaderFromURL(book.mURL));
                        }
                        image.Save(imgPath);
                    }
                }

                //load image to tha label

                if (Image.FromFile(imgPath).Height >= 70)
                    return img = Image.FromFile(imgPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return img;
        }


        //
        //Gather color of image border by pixels
        //
        private Color[] GetBorderColors(Bitmap image, Size size)
        {
            int width = image.Width;
            int height = image.Height;

            Color[] borderColors = new Color[(size.Width * 2) + (size.Height * 2)]; // 4 edges

            for (int i = 0; i < size.Height; i++)
            {
                borderColors[i] = image.GetPixel(0, i); // left edge
                borderColors[i + size.Height] = image.GetPixel(width - 1, i); // right edge
            }
            for (int i = 0; i < size.Width; i++)
            {
                borderColors[i + size.Height * 2] = image.GetPixel(i, 0); // top edge
                borderColors[i + size.Height * 2 + size.Width] = image.GetPixel(i, height - 1); // bottom edge
            }

            return borderColors;
        }

        //
        //Analyze color
        //
        private Color CalculateAverageColor(Color[] colors)
        {
            int totalR = 0, totalG = 0, totalB = 0;

            foreach (Color color in colors)
            {
                totalR += color.R;
                totalG += color.G;
                totalB += color.B;
            }

            int averageR = totalR / colors.Length;
            int averageG = totalG / colors.Length;
            int averageB = totalB / colors.Length;

            return Color.FromArgb(averageR, averageG, averageB);
        }

        #endregion

        #region Book properties
        //
        //This list to store book whenever it's information collected
        //
        private List<Book> bookList = new List<Book>();
        //
        //Book object
        //
        public struct Book
        {
            public int index { get; set; }
            public string isbn { get; set; }
            public string title { get; set; }
            public string author { get; set; }
            public string publisher { get; set; }
            public int year { get; set; }
            public string sURL { get; set; }
            public string mURL { get; set; }
            public string lURL { get; set; }

            public Book()
            {
                this.index = 0;
                this.isbn = null;
                this.title = null;
                this.author = null;
                this.publisher = null;
                this.year = 0;
                this.sURL = null;
                this.mURL = null;
                this.lURL = null;
            }

            public Book(int index, string isbn, string title, string author, string publisher, int year, string sURL, string mURL, string lURL)
            {
                this.index = index;
                this.isbn = isbn;
                this.title = title;
                this.author = author;
                this.publisher = publisher;
                this.year = year;
                this.sURL = sURL;
                this.mURL = mURL;
                this.lURL = lURL;
            }
        }

        //
        //Use Sql query to get book information from Database
        //
        private Book GetBookInformation(int index)
        {
            Book book = new Book();

            try
            {
                cmd = new SqlCommand("select * from books where [index] = " + index, con);
                con.Open();
                dr = cmd.ExecuteReader();
                dr.Read();

                if (dr.HasRows)
                {
                    book.index = index;
                    book.isbn = dr.GetFieldValue<string>(1);
                    book.title = dr.GetFieldValue<string>(2);
                    book.author = dr.GetFieldValue<string>(3);
                    book.year = dr.GetFieldValue<int>(4);
                    book.publisher = dr.GetFieldValue<string>(5);
                    book.sURL = dr.GetFieldValue<string>(6);
                    book.mURL = dr.GetFieldValue<string>(7);
                    book.lURL = dr.GetFieldValue<string>(8);

                    bookList.Add(book);
                    return book;
                }
                else
                {
                    dr.Close();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                if (dr != null) dr.Close();
                if (con != null) con.Close();
            }
            return book;
        }
        private Book GetBookInformation(string isbn)
        {
            Book book = new Book();

            try
            {
                cmd = new SqlCommand("select * from books where [isbn] = " + isbn, con);
                con.Open();
                dr = cmd.ExecuteReader();
                dr.Read();

                if (dr.HasRows)
                {
                    book.index = dr.GetFieldValue<int>(0);
                    book.isbn = dr.GetFieldValue<string>(1);
                    book.title = dr.GetFieldValue<string>(2);
                    book.author = dr.GetFieldValue<string>(3);
                    book.year = dr.GetFieldValue<int>(4);
                    book.publisher = dr.GetFieldValue<string>(5);
                    book.sURL = dr.GetFieldValue<string>(6);
                    book.mURL = dr.GetFieldValue<string>(7);
                    book.lURL = dr.GetFieldValue<string>(8);

                    bookList.Add(book);
                    return book;
                }
                else
                {
                    dr.Close();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                if (dr != null) dr.Close();
                if (con != null) con.Close();
            }
            return book;
        }

        private List<Book> SearchBookInformation(string searchKey)
        {
            List<Book> books = new List<Book>();
            Book book = new Book();
            try
            {
                cmd = new SqlCommand("select * from books where [isbn] = '" + searchKey.ToString() + "'", con);
                con.Open();
                dr = cmd.ExecuteReader();
                dr.Read();

                if (dr.HasRows)
                {
                    book.index = dr.GetFieldValue<int>(0);
                    book.isbn = dr.GetFieldValue<string>(1);
                    book.title = dr.GetFieldValue<string>(2);
                    book.author = dr.GetFieldValue<string>(3);
                    book.year = dr.GetFieldValue<int>(4);
                    book.publisher = dr.GetFieldValue<string>(5);
                    book.sURL = dr.GetFieldValue<string>(6);
                    book.mURL = dr.GetFieldValue<string>(7);
                    book.lURL = dr.GetFieldValue<string>(8);

                    bookList.Add(book);
                    books.Add(book);
                    return books;
                }
                else if (!dr.HasRows)
                {
                    dr.Close();
                    cmd = new SqlCommand("select * from books where [bookTitle] like N'%" + searchKey + "%'", con);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        book.index = dr.GetFieldValue<int>(0);
                        book.isbn = dr.GetFieldValue<string>(1);
                        book.title = dr.GetFieldValue<string>(2);
                        book.author = dr.GetFieldValue<string>(3);
                        book.year = dr.GetFieldValue<int>(4);
                        book.publisher = dr.GetFieldValue<string>(5);
                        book.sURL = dr.GetFieldValue<string>(6);
                        book.mURL = dr.GetFieldValue<string>(7);
                        book.lURL = dr.GetFieldValue<string>(8);

                        bookList.Add(book);
                        books.Add(book);
                    }
                }
                else
                {
                    dr.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                if (dr != null) dr.Close();
                if (con != null) con.Close();
            }
            return books;
        }

        #endregion

        #region Publisher information
        private List<Book> GetBookInCategory(string name)
        {
            List<Book> books = new List<Book>();
            Book book = new Book();
            try
            {
                cmd = new SqlCommand("select * from books where [publisher] = '" + name + "'", con);
                con.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    book.index = dr.GetFieldValue<int>(0);
                    book.isbn = dr.GetFieldValue<string>(1);
                    book.title = dr.GetFieldValue<string>(2);
                    book.author = dr.GetFieldValue<string>(3);
                    book.year = dr.GetFieldValue<int>(4);
                    book.publisher = dr.GetFieldValue<string>(5);
                    book.sURL = dr.GetFieldValue<string>(6);
                    book.mURL = dr.GetFieldValue<string>(7);
                    book.lURL = dr.GetFieldValue<string>(8);

                    bookList.Add(book);
                    books.Add(book);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                if (dr != null) dr.Close();
                if (con != null) con.Close();
            }
            return books;
        }
        #endregion

        #region user reading information
        private List<UserRating> userHistory = new List<UserRating>();
        //
        //Book object
        //
        public struct UserRating
        {
            public int userId { get; set; }
            public string isbn { get; set; }
            public int rate { get; set; }


            public UserRating()
            {
                this.userId = -1;
                this.isbn = null;
                this.rate = 0;
            }

            public UserRating(int userId, string isbn, int rate)
            {
                this.userId = userId;
                this.isbn = isbn;
                this.rate = rate;
            }

            public UserRating(int userId, string isbn)
            {
                this.userId = userId;
                this.isbn = isbn;
                this.rate = 0;
            }
        }

        private List<UserRating> GetUserHistory(int userId)
        {
            List<UserRating> ratings = new List<UserRating>();
            UserRating rating = new UserRating();
            try
            {
                cmd = new SqlCommand("select * from ratings where [userId] = " + userId, con);
                con.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    rating.userId = dr.GetFieldValue<int>(0);
                    rating.isbn = dr.GetFieldValue<string>(1);
                    rating.rate = dr.GetFieldValue<int>(2);

                    userHistory.Add(rating);
                    ratings.Add(rating);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                if (dr != null) dr.Close();
                if (con != null) con.Close();
            }
            return ratings;
        }
        #endregion

        #region user information

        public struct User
        {
            public int userId { get; set; }
            public string fname { get; set; }
            public string lname { get; set; }
            public string username { get; set; }
            public string password { get; set; }
            public string email { get; set; }
            public string phone { get; set; }
            public int gender { get; set; }
            public string date { get; set; }
            public string profileImage { get; set; }
            public int age { get; set; }
            public string location { get; set; }
            public string nation { get; set; }

            public User()
            {
                this.userId = -1;
                this.fname = null;
                this.lname = null;
                this.username = null;
                this.password = null;
                this.email = null;
                this.phone = null;
                this.gender = 0;
                this.date = null;
                this.profileImage = null;
                this.age = 0;
                this.location = null;
                this.nation = null; 
            }

            public User(int userId, string fname, string lname, string username, string password, string email, string phone, int gender, string date, string profileImage, int age, string location, string nation)
            {
                this.userId = userId;
                this.fname = fname;
                this.lname = lname;
                this.username = username;
                this.password = password;
                this.email = email;
                this.phone = phone;
                this.gender = gender;
                this.date = date;
                this.profileImage = profileImage;
                this.age = age;
                this.location = location;
                this.nation = nation;
            }
        }
        User currentUser = new User();
        private User GetUserInformation(string username)
        {
            User user = new User();
            try
            {
                cmd = new SqlCommand("select * from users where [username] = '" + username + "'", con);
                con.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                user.userId = dr.GetFieldValue<int>(0);
                user.fname = dr.IsDBNull("firstName") ? null : dr.GetFieldValue<string>("firstName");
                user.lname = dr.IsDBNull("lastName") ? null : dr.GetFieldValue<string>("lastName");
                user.username = dr.GetFieldValue<string>("username");
                user.password = dr.GetFieldValue<string>(4);
                user.email = dr.IsDBNull("email") ? null : dr.GetFieldValue<string>("email");
                user.phone = dr.IsDBNull("phone") ? null : dr.GetFieldValue<string>("phone");
                user.gender = dr.GetFieldValue<int>(7);
                user.date = dr.IsDBNull("date") ? null : dr.GetFieldValue<string>("date");
                user.profileImage = dr.IsDBNull("profileImage") ? null : dr.GetFieldValue<string>("profileImage");
                user.age = dr.IsDBNull("age") ? 0 : dr.GetFieldValue<int>("age");
                user.location = dr.IsDBNull("location") ? null : dr.GetFieldValue<string>("location");
                user.nation = dr.IsDBNull("nation") ? null : dr.GetFieldValue<string>("nation");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                if (dr != null) dr.Close();
                if (con != null) con.Close();
            }
            return user;
        }
        #endregion
        //
        //MainForm only work went user login successfully
        //
        public MainForm(string username)
        {
            this.username = username;
            this.FormBorderStyle = FormBorderStyle.None;
            InitializeComponent();
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }
        #region add resize angle
        private const int cGrip = 16;      // Grip size
        private const int cCaption = 32;   // Caption bar height;

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rc = new Rectangle(this.ClientSize.Width - cGrip, this.ClientSize.Height - cGrip, cGrip, cGrip);
            ControlPaint.DrawSizeGrip(e.Graphics, this.BackColor, rc);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84)
            {  // Trap WM_NCHITTEST
                Point pos = new Point(m.LParam.ToInt32());
                pos = this.PointToClient(pos);
                if (pos.Y < cCaption)
                {
                    m.Result = (IntPtr)2;  // HTCAPTION
                    return;
                }
                if (pos.X >= this.ClientSize.Width - cGrip && pos.Y >= this.ClientSize.Height - cGrip)
                {
                    m.Result = (IntPtr)17; // HTBOTTOMRIGHT
                    return;
                }
            }
            base.WndProc(ref m);
        }
        #endregion
        //
        // MainForm on load event handler
        //
        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadingForm loading = new LoadingForm(100);
            loading.Show();
            #region Set tables double buffered 
            SetDoubleBuffer(recommentTable3, true);
            SetDoubleBuffer(searchLayoutTable, true);
            SetDoubleBuffer(tableLayoutPanel45, true);

            SetDoubleBuffer(searchTabeLayout, true);
            SetDoubleBuffer(verticalMenuBar, true);
            SetDoubleBuffer(userLabel, true);
            SetDoubleBuffer(verticalTableMenu, true);
            SetDoubleBuffer(bottomBlank, true);
            SetDoubleBuffer(topBlank, true);
            SetDoubleBuffer(user, true);
            SetDoubleBuffer(homeGradientPanel, true);
            SetDoubleBuffer(homeLabel, true);
            SetDoubleBuffer(searchGradientPanel, true);
            SetDoubleBuffer(searchLabel, true);
            SetDoubleBuffer(heartGradientPanel, true);
            SetDoubleBuffer(heartLabel, true);
            SetDoubleBuffer(libraryGradientPanel, true);
            SetDoubleBuffer(librariesLabel, true);
            SetDoubleBuffer(recentGradientPanel, true);
            SetDoubleBuffer(recentLabel, true);
            SetDoubleBuffer(contentPanel, true);
            SetDoubleBuffer(contentContainer, true);
            SetDoubleBuffer(publisherLabel, true);
            SetDoubleBuffer(contentYear, true);
            SetDoubleBuffer(contentImg, true);
            SetDoubleBuffer(contentTitle, true);
            SetDoubleBuffer(authorLabel, true);
            SetDoubleBuffer(aboutAuthor, true);
            SetDoubleBuffer(authorDesLabel, true);
            SetDoubleBuffer(categoryLabel, true);
            SetDoubleBuffer(category0, true);
            SetDoubleBuffer(mainFlowPanel, true);
            SetDoubleBuffer(homeFlowPanel, true);
            SetDoubleBuffer(helloPanel, true);
            SetDoubleBuffer(helloLabel, true);
            SetDoubleBuffer(helloElement0, true);
            SetDoubleBuffer(helloElementTable0, true);
            SetDoubleBuffer(helloElementImg0, true);
            SetDoubleBuffer(helloFlow0, true);
            SetDoubleBuffer(helloElementTitle0, true);
            SetDoubleBuffer(helloAuthor0, true);
            SetDoubleBuffer(helloElement1, true);
            SetDoubleBuffer(helloElementTable1, true);
            SetDoubleBuffer(helloElementImg1, true);
            SetDoubleBuffer(helloFlow1, true);
            SetDoubleBuffer(helloElementTitle1, true);
            SetDoubleBuffer(helloAuthor1, true);
            SetDoubleBuffer(helloElement2, true);
            SetDoubleBuffer(helloElementTable2, true);
            SetDoubleBuffer(helloElementImg2, true);
            SetDoubleBuffer(helloFlow2, true);
            SetDoubleBuffer(helloElementTitle2, true);
            SetDoubleBuffer(helloAuthor2, true);
            SetDoubleBuffer(helloElement3, true);
            SetDoubleBuffer(helloElementTable3, true);
            SetDoubleBuffer(helloElementImg3, true);
            SetDoubleBuffer(helloFlow3, true);
            SetDoubleBuffer(helloElementTitle3, true);
            SetDoubleBuffer(helloAuthor3, true);
            SetDoubleBuffer(recommentPanel, true);
            SetDoubleBuffer(recommentLabel, true);
            SetDoubleBuffer(recommentElement0, true);
            SetDoubleBuffer(recommentTable0, true);
            SetDoubleBuffer(recommentImg0, true);
            SetDoubleBuffer(recommentFlowPanel0, true);
            SetDoubleBuffer(recommentTitle0, true);
            SetDoubleBuffer(recommentAuthor0, true);
            SetDoubleBuffer(recommentElement1, true);
            SetDoubleBuffer(tableLayoutPanel8, true);
            SetDoubleBuffer(recommentImg1, true);
            SetDoubleBuffer(recommentFlowPanel1, true);
            SetDoubleBuffer(recommentTitle1, true);
            SetDoubleBuffer(recommentAuthor1, true);
            SetDoubleBuffer(recommentElement2, true);
            SetDoubleBuffer(recommentTable2, true);
            SetDoubleBuffer(recommentImg2, true);
            SetDoubleBuffer(recommentFlowLabel2, true);
            SetDoubleBuffer(recommentTitle2, true);
            SetDoubleBuffer(recommentAuthor2, true);
            SetDoubleBuffer(recommentElement3, true);
            SetDoubleBuffer(recommentTable3, true);
            SetDoubleBuffer(recommentImg3, true);
            SetDoubleBuffer(recommentFlowLabel3, true);
            SetDoubleBuffer(recommentTitle3, true);
            SetDoubleBuffer(recommentAuthor3, true);
            SetDoubleBuffer(recentPanel, true);
            SetDoubleBuffer(searchFlowPanel, true);
            SetDoubleBuffer(searchPanel, true);
            SetDoubleBuffer(searchLayoutTable, true);
            SetDoubleBuffer(searchBoxContainer, true);
            SetDoubleBuffer(searchBox, true);
            SetDoubleBuffer(searchImg, true);
            SetDoubleBuffer(bestMatchPanel, true);
            SetDoubleBuffer(bestMatchLabel, true);
            SetDoubleBuffer(topSearchPanel, true);
            SetDoubleBuffer(topSeachTable, true);
            SetDoubleBuffer(topSearchImg, true);
            SetDoubleBuffer(topSearchFlowPanel, true);
            SetDoubleBuffer(topSearchTitle, true);
            SetDoubleBuffer(topSearchAuthor, true);
            SetDoubleBuffer(flowLayoutPanel61, true);
            SetDoubleBuffer(favoritePanel, true);
            SetDoubleBuffer(flowLayoutPanel24, true);
            SetDoubleBuffer(label51, true);
            SetDoubleBuffer(gradientPanel8, true);
            SetDoubleBuffer(tableLayoutPanel24, true);
            SetDoubleBuffer(label81, true);
            SetDoubleBuffer(flowLayoutPanel25, true);
            SetDoubleBuffer(label82, true);
            SetDoubleBuffer(label83, true);
            SetDoubleBuffer(gradientPanel9, true);
            SetDoubleBuffer(tableLayoutPanel25, true);
            SetDoubleBuffer(label84, true);
            SetDoubleBuffer(flowLayoutPanel26, true);
            SetDoubleBuffer(label85, true);
            SetDoubleBuffer(label86, true);
            SetDoubleBuffer(gradientPanel10, true);
            SetDoubleBuffer(tableLayoutPanel38, true);
            SetDoubleBuffer(label87, true);
            SetDoubleBuffer(flowLayoutPanel27, true);
            SetDoubleBuffer(label88, true);
            SetDoubleBuffer(label89, true);
            SetDoubleBuffer(gradientPanel11, true);
            SetDoubleBuffer(tableLayoutPanel41, true);
            SetDoubleBuffer(label90, true);
            SetDoubleBuffer(flowLayoutPanel41, true);
            SetDoubleBuffer(label91, true);
            SetDoubleBuffer(label92, true);
            SetDoubleBuffer(categoriesPanel, true);
            SetDoubleBuffer(flowLayoutPanel42, true);
            SetDoubleBuffer(label93, true);
            SetDoubleBuffer(gradientPanel12, true);
            SetDoubleBuffer(tableLayoutPanel42, true);
            SetDoubleBuffer(label94, true);
            SetDoubleBuffer(flowLayoutPanel43, true);
            SetDoubleBuffer(label95, true);
            SetDoubleBuffer(label96, true);
            SetDoubleBuffer(gradientPanel13, true);
            SetDoubleBuffer(tableLayoutPanel43, true);
            SetDoubleBuffer(label97, true);
            SetDoubleBuffer(flowLayoutPanel44, true);
            SetDoubleBuffer(label98, true);
            SetDoubleBuffer(label99, true);
            SetDoubleBuffer(gradientPanel14, true);
            SetDoubleBuffer(tableLayoutPanel44, true);
            SetDoubleBuffer(label100, true);
            SetDoubleBuffer(flowLayoutPanel45, true);
            SetDoubleBuffer(label101, true);
            SetDoubleBuffer(label102, true);
            SetDoubleBuffer(gradientPanel15, true);
            SetDoubleBuffer(tableLayoutPanel45, true);
            SetDoubleBuffer(label103, true);
            SetDoubleBuffer(flowLayoutPanel46, true);
            SetDoubleBuffer(label104, true);
            SetDoubleBuffer(label105, true);
            SetDoubleBuffer(historyPanel, true);
            SetDoubleBuffer(flowLayoutPanel47, true);
            SetDoubleBuffer(label106, true);
            SetDoubleBuffer(gradientPanel16, true);
            SetDoubleBuffer(tableLayoutPanel46, true);
            SetDoubleBuffer(label107, true);
            SetDoubleBuffer(flowLayoutPanel48, true);
            SetDoubleBuffer(label108, true);
            SetDoubleBuffer(label109, true);
            SetDoubleBuffer(gradientPanel17, true);
            SetDoubleBuffer(tableLayoutPanel47, true);
            SetDoubleBuffer(label110, true);
            SetDoubleBuffer(flowLayoutPanel49, true);
            SetDoubleBuffer(label111, true);
            SetDoubleBuffer(label112, true);
            SetDoubleBuffer(gradientPanel18, true);
            SetDoubleBuffer(tableLayoutPanel48, true);
            SetDoubleBuffer(label113, true);
            SetDoubleBuffer(flowLayoutPanel50, true);
            SetDoubleBuffer(label115, true);
            SetDoubleBuffer(label116, true);
            SetDoubleBuffer(gradientPanel19, true);
            SetDoubleBuffer(tableLayoutPanel49, true);
            SetDoubleBuffer(label117, true);
            SetDoubleBuffer(flowLayoutPanel51, true);
            SetDoubleBuffer(label118, true);
            SetDoubleBuffer(label119, true);
            SetDoubleBuffer(bestBookPanel, true);
            SetDoubleBuffer(bestBookFlowPanel, true);
            SetDoubleBuffer(bestBookLabel, true);
            SetDoubleBuffer(bestBookElement0, true);
            SetDoubleBuffer(bestBookTable0, true);
            SetDoubleBuffer(bestBookImg0, true);
            SetDoubleBuffer(bestBookLabel0, true);
            SetDoubleBuffer(bestBookTitle0, true);
            SetDoubleBuffer(bestBookAuthor0, true);
            SetDoubleBuffer(bestBookElement1, true);
            SetDoubleBuffer(bestBookTable1, true);
            SetDoubleBuffer(bestBookImg1, true);
            SetDoubleBuffer(bestBookLabel1, true);
            SetDoubleBuffer(bestBookTitle1, true);
            SetDoubleBuffer(bestBookAuthor1, true);
            SetDoubleBuffer(bestBookElement2, true);
            SetDoubleBuffer(bestBookTable2, true);
            SetDoubleBuffer(bestBookImg2, true);
            SetDoubleBuffer(bestBookLabel2, true);
            SetDoubleBuffer(bestBookTitle2, true);
            SetDoubleBuffer(bestBookAuthor2, true);
            SetDoubleBuffer(bestBookElement3, true);
            SetDoubleBuffer(bestBookTable3, true);
            SetDoubleBuffer(bestBookImg3, true);
            SetDoubleBuffer(bestBookLabel3, true);
            SetDoubleBuffer(bestBookTitle3, true);
            SetDoubleBuffer(bestBookAuthor3, true);
            SetDoubleBuffer(currentPanel, true);
            SetDoubleBuffer(currentLabel, true);
            SetDoubleBuffer(currentProperties, true);
            SetDoubleBuffer(currentPropertiesTable, true);
            SetDoubleBuffer(currentBookPanel, true);
            SetDoubleBuffer(currentBookTitle, true);
            SetDoubleBuffer(currentBookAuthor, true);
            SetDoubleBuffer(currentBookRate, true);
            SetDoubleBuffer(currentPagePanel, true);
            SetDoubleBuffer(totalPage, true);
            SetDoubleBuffer(currentPage, true);
            SetDoubleBuffer(currentPublisherPanel, true);
            SetDoubleBuffer(currentPublisher, true);
            SetDoubleBuffer(yearOfPublication, true);
            SetDoubleBuffer(optionPanel, true);
            SetDoubleBuffer(optionsFlowPanel, true);
            SetDoubleBuffer(heartOption, true);
            SetDoubleBuffer(textToSpeech, true);
            SetDoubleBuffer(brightness, true);
            SetDoubleBuffer(forward, true);
            SetDoubleBuffer(bookmark, true);
            SetDoubleBuffer(flowLayoutPanel2, true);
            SetDoubleBuffer(tableLayoutPanel3, true);
            SetDoubleBuffer(label3, true);
            SetDoubleBuffer(label4, true);
            SetDoubleBuffer(flowLayoutPanel5, true);
            SetDoubleBuffer(tableLayoutPanel6, true);
            SetDoubleBuffer(label9, true);
            SetDoubleBuffer(label10, true);
            SetDoubleBuffer(flowLayoutPanel6, true);
            SetDoubleBuffer(tableLayoutPanel7, true);
            SetDoubleBuffer(label11, true);
            SetDoubleBuffer(label12, true);
            SetDoubleBuffer(flowLayoutPanel3, true);
            SetDoubleBuffer(label5, true);
            SetDoubleBuffer(flowLayoutPanel8, true);
            SetDoubleBuffer(tableLayoutPanel4, true);
            SetDoubleBuffer(label6, true);
            SetDoubleBuffer(label15, true);
            SetDoubleBuffer(flowLayoutPanel9, true);
            SetDoubleBuffer(tableLayoutPanel9, true);
            SetDoubleBuffer(label16, true);
            SetDoubleBuffer(label17, true);
            SetDoubleBuffer(flowLayoutPanel10, true);
            SetDoubleBuffer(tableLayoutPanel10, true);
            SetDoubleBuffer(label18, true);
            SetDoubleBuffer(label19, true);
            SetDoubleBuffer(flowLayoutPanel11, true);
            SetDoubleBuffer(tableLayoutPanel11, true);
            SetDoubleBuffer(label20, true);
            SetDoubleBuffer(label21, true);
            SetDoubleBuffer(flowLayoutPanel12, true);
            SetDoubleBuffer(tableLayoutPanel12, true);
            SetDoubleBuffer(label22, true);
            SetDoubleBuffer(label23, true);
            SetDoubleBuffer(flowLayoutPanel13, true);
            SetDoubleBuffer(tableLayoutPanel13, true);
            SetDoubleBuffer(label24, true);
            SetDoubleBuffer(label25, true);
            SetDoubleBuffer(flowLayoutPanel14, true);
            SetDoubleBuffer(label26, true);
            SetDoubleBuffer(flowLayoutPanel15, true);
            SetDoubleBuffer(tableLayoutPanel14, true);
            SetDoubleBuffer(label27, true);
            SetDoubleBuffer(label28, true);
            SetDoubleBuffer(flowLayoutPanel16, true);
            SetDoubleBuffer(tableLayoutPanel15, true);
            SetDoubleBuffer(label29, true);
            SetDoubleBuffer(label30, true);
            SetDoubleBuffer(flowLayoutPanel17, true);
            SetDoubleBuffer(tableLayoutPanel16, true);
            SetDoubleBuffer(label31, true);
            SetDoubleBuffer(label32, true);
            SetDoubleBuffer(flowLayoutPanel18, true);
            SetDoubleBuffer(tableLayoutPanel17, true);
            SetDoubleBuffer(label33, true);
            SetDoubleBuffer(label34, true);
            SetDoubleBuffer(flowLayoutPanel19, true);
            SetDoubleBuffer(tableLayoutPanel18, true);
            SetDoubleBuffer(label35, true);
            SetDoubleBuffer(label36, true);
            SetDoubleBuffer(flowLayoutPanel20, true);
            SetDoubleBuffer(tableLayoutPanel19, true);
            SetDoubleBuffer(label37, true);
            SetDoubleBuffer(label38, true);
            SetDoubleBuffer(contextMenuStrip1, true);
            SetDoubleBuffer(gradientPanel2, true);
            SetDoubleBuffer(tableLayoutPanel5, true);
            SetDoubleBuffer(label7, true);
            SetDoubleBuffer(label8, true);
            SetDoubleBuffer(gradientPanel4, true);
            SetDoubleBuffer(tableLayoutPanel40, true);
            SetDoubleBuffer(label79, true);
            SetDoubleBuffer(label80, true);
            SetDoubleBuffer(toolStrip1, true);

            SetDoubleBuffer(searchTabeLayout, true);
            SetDoubleBuffer(verticalMenuBar, true);
            SetDoubleBuffer(verticalTableMenu, true);
            SetDoubleBuffer(topBlank, true);
            SetDoubleBuffer(homeGradientPanel, true);
            SetDoubleBuffer(searchGradientPanel, true);
            SetDoubleBuffer(heartGradientPanel, true);
            SetDoubleBuffer(libraryGradientPanel, true);
            SetDoubleBuffer(recentGradientPanel, true);
            SetDoubleBuffer(contentPanel, true);
            SetDoubleBuffer(contentContainer, true);
            SetDoubleBuffer(category0, true);
            SetDoubleBuffer(mainFlowPanel, true);
            SetDoubleBuffer(homeFlowPanel, true);
            SetDoubleBuffer(helloPanel, true);
            SetDoubleBuffer(helloElement0, true);
            SetDoubleBuffer(helloElementTable0, true);
            SetDoubleBuffer(helloFlow0, true);
            SetDoubleBuffer(helloElement1, true);
            SetDoubleBuffer(helloElementTable1, true);
            SetDoubleBuffer(helloFlow1, true);
            SetDoubleBuffer(helloElement2, true);
            SetDoubleBuffer(helloElementTable2, true);
            SetDoubleBuffer(helloFlow2, true);
            SetDoubleBuffer(helloElement3, true);
            SetDoubleBuffer(helloElementTable3, true);
            SetDoubleBuffer(helloFlow3, true);
            SetDoubleBuffer(recommentPanel, true);
            SetDoubleBuffer(recommentElement0, true);
            SetDoubleBuffer(recommentTable0, true);
            SetDoubleBuffer(recommentFlowPanel0, true);
            SetDoubleBuffer(recommentElement1, true);
            SetDoubleBuffer(tableLayoutPanel8, true);
            SetDoubleBuffer(recommentFlowPanel1, true);
            SetDoubleBuffer(recommentElement2, true);
            SetDoubleBuffer(recommentTable2, true);
            SetDoubleBuffer(recommentFlowLabel2, true);
            SetDoubleBuffer(recommentElement3, true);
            SetDoubleBuffer(recommentTable3, true);
            SetDoubleBuffer(recommentFlowLabel3, true);
            SetDoubleBuffer(searchFlowPanel, true);
            SetDoubleBuffer(searchPanel, true);
            SetDoubleBuffer(searchLayoutTable, true);
            SetDoubleBuffer(searchBoxContainer, true);
            SetDoubleBuffer(bestMatchPanel, true);
            SetDoubleBuffer(topSearchPanel, true);
            SetDoubleBuffer(topSeachTable, true);
            SetDoubleBuffer(topSearchFlowPanel, true);
            SetDoubleBuffer(otherResult0, true);
            SetDoubleBuffer(otherTable0, true);
            SetDoubleBuffer(otherResult1, true);
            SetDoubleBuffer(otherTable1, true);
            SetDoubleBuffer(otherResult2, true);
            SetDoubleBuffer(otherTable2, true);
            SetDoubleBuffer(otherResult3, true);
            SetDoubleBuffer(otherTable3, true);
            SetDoubleBuffer(otherResult4, true);
            SetDoubleBuffer(otherTable4, true);
            SetDoubleBuffer(otherResult5, true);
            SetDoubleBuffer(otherTable5, true);
            SetDoubleBuffer(otherResult6, true);
            SetDoubleBuffer(otherTable6, true);
            SetDoubleBuffer(otherResult7, true);
            SetDoubleBuffer(otherTable7, true);
            SetDoubleBuffer(otherResult8, true);
            SetDoubleBuffer(otherTable8, true);
            SetDoubleBuffer(otherResult9, true);
            SetDoubleBuffer(otherTable9, true);
            SetDoubleBuffer(favoritePanel, true);
            SetDoubleBuffer(flowLayoutPanel24, true);
            SetDoubleBuffer(gradientPanel8, true);
            SetDoubleBuffer(tableLayoutPanel24, true);
            SetDoubleBuffer(flowLayoutPanel25, true);
            SetDoubleBuffer(gradientPanel9, true);
            SetDoubleBuffer(tableLayoutPanel25, true);
            SetDoubleBuffer(flowLayoutPanel26, true);
            SetDoubleBuffer(gradientPanel10, true);
            SetDoubleBuffer(tableLayoutPanel38, true);
            SetDoubleBuffer(flowLayoutPanel27, true);
            SetDoubleBuffer(gradientPanel11, true);
            SetDoubleBuffer(tableLayoutPanel41, true);
            SetDoubleBuffer(flowLayoutPanel41, true);
            SetDoubleBuffer(categoriesPanel, true);
            SetDoubleBuffer(flowLayoutPanel42, true);
            SetDoubleBuffer(gradientPanel12, true);
            SetDoubleBuffer(tableLayoutPanel42, true);
            SetDoubleBuffer(flowLayoutPanel43, true);
            SetDoubleBuffer(gradientPanel13, true);
            SetDoubleBuffer(tableLayoutPanel43, true);
            SetDoubleBuffer(flowLayoutPanel44, true);
            SetDoubleBuffer(gradientPanel14, true);
            SetDoubleBuffer(tableLayoutPanel44, true);
            SetDoubleBuffer(flowLayoutPanel45, true);
            SetDoubleBuffer(gradientPanel15, true);
            SetDoubleBuffer(tableLayoutPanel45, true);
            SetDoubleBuffer(flowLayoutPanel46, true);
            SetDoubleBuffer(historyPanel, true);
            SetDoubleBuffer(flowLayoutPanel47, true);
            SetDoubleBuffer(gradientPanel16, true);
            SetDoubleBuffer(tableLayoutPanel46, true);
            SetDoubleBuffer(flowLayoutPanel48, true);
            SetDoubleBuffer(gradientPanel17, true);
            SetDoubleBuffer(tableLayoutPanel47, true);
            SetDoubleBuffer(flowLayoutPanel49, true);
            SetDoubleBuffer(gradientPanel18, true);
            SetDoubleBuffer(tableLayoutPanel48, true);
            SetDoubleBuffer(flowLayoutPanel50, true);
            SetDoubleBuffer(gradientPanel19, true);
            SetDoubleBuffer(tableLayoutPanel49, true);
            SetDoubleBuffer(flowLayoutPanel51, true);
            SetDoubleBuffer(bestBookPanel, true);
            SetDoubleBuffer(bestBookFlowPanel, true);
            SetDoubleBuffer(bestBookElement0, true);
            SetDoubleBuffer(bestBookTable0, true);
            SetDoubleBuffer(bestBookLabel0, true);
            SetDoubleBuffer(bestBookElement1, true);
            SetDoubleBuffer(bestBookTable1, true);
            SetDoubleBuffer(bestBookLabel1, true);
            SetDoubleBuffer(bestBookElement2, true);
            SetDoubleBuffer(bestBookTable2, true);
            SetDoubleBuffer(bestBookLabel2, true);
            SetDoubleBuffer(bestBookElement3, true);
            SetDoubleBuffer(bestBookTable3, true);
            SetDoubleBuffer(bestBookLabel3, true);
            SetDoubleBuffer(currentPanel, true);
            SetDoubleBuffer(currentProperties, true);
            SetDoubleBuffer(currentPropertiesTable, true);
            SetDoubleBuffer(currentBookPanel, true);
            SetDoubleBuffer(currentPagePanel, true);
            SetDoubleBuffer(currentPublisherPanel, true);
            SetDoubleBuffer(optionPanel, true);
            SetDoubleBuffer(optionsFlowPanel, true);
            SetDoubleBuffer(tableLayoutPanel3, true);
            SetDoubleBuffer(flowLayoutPanel5, true);
            SetDoubleBuffer(tableLayoutPanel6, true);
            SetDoubleBuffer(tableLayoutPanel7, true);
            SetDoubleBuffer(flowLayoutPanel3, true);
            SetDoubleBuffer(flowLayoutPanel8, true);
            SetDoubleBuffer(tableLayoutPanel4, true);
            SetDoubleBuffer(flowLayoutPanel9, true);
            SetDoubleBuffer(tableLayoutPanel9, true);
            SetDoubleBuffer(flowLayoutPanel10, true);
            SetDoubleBuffer(tableLayoutPanel10, true);
            SetDoubleBuffer(flowLayoutPanel11, true);
            SetDoubleBuffer(tableLayoutPanel11, true);
            SetDoubleBuffer(flowLayoutPanel12, true);
            SetDoubleBuffer(tableLayoutPanel12, true);
            SetDoubleBuffer(tableLayoutPanel13, true);
            SetDoubleBuffer(flowLayoutPanel14, true);
            SetDoubleBuffer(flowLayoutPanel15, true);
            SetDoubleBuffer(tableLayoutPanel14, true);
            SetDoubleBuffer(flowLayoutPanel16, true);
            SetDoubleBuffer(tableLayoutPanel15, true);
            SetDoubleBuffer(flowLayoutPanel17, true);
            SetDoubleBuffer(tableLayoutPanel16, true);
            SetDoubleBuffer(flowLayoutPanel18, true);
            SetDoubleBuffer(tableLayoutPanel17, true);
            SetDoubleBuffer(flowLayoutPanel19, true);
            SetDoubleBuffer(tableLayoutPanel18, true);
            SetDoubleBuffer(tableLayoutPanel19, true);
            SetDoubleBuffer(contextMenuStrip1, true);
            SetDoubleBuffer(tableLayoutPanel5, true);
            SetDoubleBuffer(tableLayoutPanel40, true);
            SetDoubleBuffer(toolStrip1, true);

            #endregion
            //update userlabel
            currentUser = GetUserInformation(username);
            toolTip1.SetToolTip(user,currentUser.username +" #"+ currentUser.userId);

            #region test application graphic by getting random index of books
            Random rand = new Random();
            int randC = rand.Next(1, 1000);
            Image currentImg = GetBookImage(randC);
            Book book = GetBookInformation(randC);
            Color borderColor = CalculateAverageColor(GetBorderColors(new Bitmap(currentImg), currentImg.Size));

            contentImg.Image = SetHeight(currentImg, contentImg.Height);
            currentLabel.Image = SetHeight(currentImg, currentLabel.Height);

            contentTitle.Text = book.title;
            authorLabel.Text = book.author;
            publisherLabel.Text = book.publisher;
            contentYear.Text = book.year.ToString();

            currentBookTitle.Text = book.title;
            currentBookAuthor.Text = book.author;
            currentPublisher.Text = book.publisher;
            yearOfPublication.Text = book.year.ToString();


            currentPanel.BackColor = borderColor;
            currentProperties.GradientPrimaryColor = borderColor;
            currentProperties.GradientSecondaryColor = Color.Transparent;

            //helloPanel
            int randH0 = rand.Next(1, 1000);
            int randH1 = rand.Next(1, 1000);
            int randH2 = rand.Next(1, 1000);
            int randH3 = rand.Next(1, 1000);
            helloElementImg0.Image = SetHeight(GetBookImage(randH0), helloElementImg0.Height);
            helloElementImg1.Image = SetHeight(GetBookImage(randH1), helloElementImg1.Height);
            helloElementImg2.Image = SetHeight(GetBookImage(randH2), helloElementImg2.Height);
            helloElementImg3.Image = SetHeight(GetBookImage(randH3), helloElementImg3.Height);

            Book helloBook0 = GetBookInformation(randH0);
            Book helloBook1 = GetBookInformation(randH1);
            Book helloBook2 = GetBookInformation(randH2);
            Book helloBook3 = GetBookInformation(randH3);

            helloElementTitle0.Text = helloBook0.title;
            helloAuthor0.Text = helloBook0.author;
            helloElementTitle1.Text = helloBook1.title;
            helloAuthor1.Text = helloBook1.author;
            helloElementTitle2.Text = helloBook2.title;
            helloAuthor2.Text = helloBook2.author;
            helloElementTitle3.Text = helloBook3.title;
            helloAuthor3.Text = helloBook3.author;

            //recommentPanel 
            int randC0 = rand.Next(1, 1000);
            int randC1 = rand.Next(1, 1000);
            int randC2 = rand.Next(1, 1000);
            int randC3 = rand.Next(1, 1000);
            recommentImg0.Image = SetHeight(GetBookImage(randC0), recommentImg0.Height);
            recommentImg1.Image = SetHeight(GetBookImage(randC1), recommentImg1.Height);
            recommentImg2.Image = SetHeight(GetBookImage(randC2), recommentImg2.Height);
            recommentImg3.Image = SetHeight(GetBookImage(randC3), recommentImg3.Height);

            Book recommentBook0 = GetBookInformation(randC0);
            Book recommentBook1 = GetBookInformation(randC1);
            Book recommentBook2 = GetBookInformation(randC2);
            Book recommentBook3 = GetBookInformation(randC3);

            recommentTitle0.Text = recommentBook0.title;
            recommentAuthor0.Text = recommentBook0.author;
            recommentTitle1.Text = recommentBook1.title;
            recommentAuthor1.Text = recommentBook1.author;
            recommentTitle2.Text = recommentBook2.title;
            recommentAuthor2.Text = recommentBook2.author;
            recommentTitle3.Text = recommentBook3.title;
            recommentAuthor3.Text = recommentBook3.author;

            //bestBook Panel
            int randB0 = rand.Next(1, 1000);
            int randB1 = rand.Next(1, 1000);
            int randB2 = rand.Next(1, 1000);
            int randB3 = rand.Next(1, 1000);
            bestBookImg0.Image = SetHeight(GetBookImage(randB0), bestBookImg0.Height);
            bestBookImg1.Image = SetHeight(GetBookImage(randB1), bestBookImg1.Height);
            bestBookImg2.Image = SetHeight(GetBookImage(randB2), bestBookImg2.Height);
            bestBookImg3.Image = SetHeight(GetBookImage(randB3), bestBookImg3.Height);

            Book bestBook0 = GetBookInformation(randB0);
            Book bestBook1 = GetBookInformation(randB1);
            Book bestBook2 = GetBookInformation(randB2);
            Book bestBook3 = GetBookInformation(randB3);

            bestBookTitle0.Text = bestBook0.title;
            bestBookAuthor0.Text = bestBook0.author;
            bestBookTitle1.Text = bestBook1.title;
            bestBookAuthor1.Text = bestBook1.author;
            bestBookTitle2.Text = bestBook2.title;
            bestBookAuthor2.Text = bestBook2.author;
            bestBookTitle3.Text = bestBook3.title;
            bestBookAuthor3.Text = bestBook3.author;
            #endregion

            homeFlowPanel.Controls.Add(bestBookFlowPanel);
            bestBookFlowPanel.Visible = true;

            loading.Visible = false;
        }

        //unneccessary!
        private void contentContainer_Paint(object sender, PaintEventArgs e)
        {
            LinearGradientBrush lgb = new LinearGradientBrush(contentContainer.ClientRectangle, ColorTranslator.FromHtml("#300004"), contentContainer.BackColor, 90F);
            Graphics g = e.Graphics;
            g.FillRectangle(lgb, contentContainer.ClientRectangle);
        }


        #region Update welcome panel by real time detector and change color
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
                helloElement0.GradientSecondaryColor = ColorTranslator.FromHtml("#FFB6C1");
                helloElement1.GradientSecondaryColor = ColorTranslator.FromHtml("#FFB6C1");
                helloElement2.GradientSecondaryColor = ColorTranslator.FromHtml("#FFB6C1");
                helloElement3.GradientSecondaryColor = ColorTranslator.FromHtml("#FFB6C1");

            }
            else if (hour >= 12 && hour < 18)
            {
                timeRange = "afternoon";
                lgb = new LinearGradientBrush(helloPanel.ClientRectangle, ColorTranslator.FromHtml("#FFD700"), ColorTranslator.FromHtml("#87CEEB"), 60F);
                helloElement0.GradientSecondaryColor = ColorTranslator.FromHtml("#FFB6C1");
                helloElement1.GradientSecondaryColor = ColorTranslator.FromHtml("#FFB6C1");
                helloElement2.GradientSecondaryColor = ColorTranslator.FromHtml("#FFB6C1");
                helloElement3.GradientSecondaryColor = ColorTranslator.FromHtml("#FFB6C1");

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
        #endregion

        #region menu bar and main theme handler on menu state
        // state on menu bar
        private int state = 0;


        private void mainFlowPanel_Paint(object sender, PaintEventArgs e)
        {
            LinearGradientBrush lgb = new LinearGradientBrush(mainFlowPanel.ClientRectangle, ColorTranslator.FromHtml("#ffffff"), ColorTranslator.FromHtml("#000000"), 60F);
            if (state == 0)
            {
                lgb = new LinearGradientBrush(mainFlowPanel.ClientRectangle, ColorTranslator.FromHtml("#07e0eb"), ColorTranslator.FromHtml("#262626"), 60F);
            }
            if (state == 1)
            {
                lgb = new LinearGradientBrush(mainFlowPanel.ClientRectangle, ColorTranslator.FromHtml("#6f00e6"), ColorTranslator.FromHtml("#262626"), 60F);
            }
            if (state == 2)
            {
                lgb = new LinearGradientBrush(mainFlowPanel.ClientRectangle, ColorTranslator.FromHtml("#c4293b"), ColorTranslator.FromHtml("#262626"), 60F);
            }
            if (state == 3)
            {
                lgb = new LinearGradientBrush(mainFlowPanel.ClientRectangle, ColorTranslator.FromHtml("#02c92d"), ColorTranslator.FromHtml("#262626"), 60F);
            }
            if (state == 4)
            {
                lgb = new LinearGradientBrush(mainFlowPanel.ClientRectangle, ColorTranslator.FromHtml("#c7c704"), ColorTranslator.FromHtml("#262626"), 60F);
            }

            e.Graphics.FillRectangle(lgb, mainFlowPanel.ClientRectangle);
        }

        private void verticalMenuBar_Paint(object sender, PaintEventArgs e)
        {
            if (state == 0)
            {
                topBlank.GradientSecondaryColor = ColorTranslator.FromHtml("#02c2cc");
                homeGradientPanel.GradientPrimaryColor = ColorTranslator.FromHtml("#07e0eb");
                homeGradientPanel.GradientSecondaryColor = ColorTranslator.FromHtml("#07e0eb");
                searchGradientPanel.GradientPrimaryColor = ColorTranslator.FromHtml("#02a5ad");
                searchGradientPanel.GradientSecondaryColor = ColorTranslator.FromHtml("#017c82");
                heartGradientPanel.GradientPrimaryColor = ColorTranslator.FromHtml("#017c82");
                heartGradientPanel.GradientSecondaryColor = ColorTranslator.FromHtml("#015357");
                libraryGradientPanel.GradientPrimaryColor = ColorTranslator.FromHtml("#015357");
                libraryGradientPanel.GradientSecondaryColor = ColorTranslator.FromHtml("#013f42");
                recentGradientPanel.GradientPrimaryColor = ColorTranslator.FromHtml("#013f42");
                recentGradientPanel.GradientSecondaryColor = ColorTranslator.FromHtml("#002729");
                bottomBlank.GradientPrimaryColor = ColorTranslator.FromHtml("#002729");
            }
            else if (state == 1)
            {
                topBlank.GradientSecondaryColor = ColorTranslator.FromHtml("#3e0180");
                homeGradientPanel.GradientPrimaryColor = ColorTranslator.FromHtml("#3e0180");
                homeGradientPanel.GradientSecondaryColor = ColorTranslator.FromHtml("#5905b3");
                searchGradientPanel.GradientPrimaryColor = ColorTranslator.FromHtml("#6f00e6");
                searchGradientPanel.GradientSecondaryColor = ColorTranslator.FromHtml("#6f00e6");
                heartGradientPanel.GradientPrimaryColor = ColorTranslator.FromHtml("#5905b3");
                heartGradientPanel.GradientSecondaryColor = ColorTranslator.FromHtml("#3e0180");
                libraryGradientPanel.GradientPrimaryColor = ColorTranslator.FromHtml("#3e0180");
                libraryGradientPanel.GradientSecondaryColor = ColorTranslator.FromHtml("#310263");
                recentGradientPanel.GradientPrimaryColor = ColorTranslator.FromHtml("#310263");
                recentGradientPanel.GradientSecondaryColor = ColorTranslator.FromHtml("#1d013b");
                bottomBlank.GradientPrimaryColor = ColorTranslator.FromHtml("#1d013b");
            }
            else if (state == 2)
            {
                topBlank.GradientSecondaryColor = ColorTranslator.FromHtml("#3b0a10");//#3b0a10
                homeGradientPanel.GradientPrimaryColor = ColorTranslator.FromHtml("#3b0a10");//#3b0a10
                homeGradientPanel.GradientSecondaryColor = ColorTranslator.FromHtml("#6b1620");//#6b1620
                searchGradientPanel.GradientPrimaryColor = ColorTranslator.FromHtml("#6b1620");//#6b1620
                searchGradientPanel.GradientSecondaryColor = ColorTranslator.FromHtml("#8c1d2a");//#8c1d2a
                heartGradientPanel.GradientPrimaryColor = ColorTranslator.FromHtml("#c4293b");//#c4293b
                heartGradientPanel.GradientSecondaryColor = ColorTranslator.FromHtml("#c4293b");//#c4293b
                libraryGradientPanel.GradientPrimaryColor = ColorTranslator.FromHtml("#8c1d2a");//#8c1d2a
                libraryGradientPanel.GradientSecondaryColor = ColorTranslator.FromHtml("#6b1620");//#6b1620
                recentGradientPanel.GradientPrimaryColor = ColorTranslator.FromHtml("#6b1620");//#6b1620
                recentGradientPanel.GradientSecondaryColor = ColorTranslator.FromHtml("#3b0a10");//#3b0a10
                bottomBlank.GradientPrimaryColor = ColorTranslator.FromHtml("#3b0a10");//#3b0a10
            }
            else if (state == 3)
            {
                topBlank.GradientSecondaryColor = ColorTranslator.FromHtml("#02360c");//#02360c
                homeGradientPanel.GradientPrimaryColor = ColorTranslator.FromHtml("#02360c");//#02360c
                homeGradientPanel.GradientSecondaryColor = ColorTranslator.FromHtml("#025413");//#025413
                searchGradientPanel.GradientPrimaryColor = ColorTranslator.FromHtml("#025413");//#025413
                searchGradientPanel.GradientSecondaryColor = ColorTranslator.FromHtml("#047a1d");//#047a1d
                heartGradientPanel.GradientPrimaryColor = ColorTranslator.FromHtml("#047a1d");//#047a1d
                heartGradientPanel.GradientSecondaryColor = ColorTranslator.FromHtml("#05a327");//#05a327
                libraryGradientPanel.GradientPrimaryColor = ColorTranslator.FromHtml("#02c92d");//#02c92d
                libraryGradientPanel.GradientSecondaryColor = ColorTranslator.FromHtml("#02c92d");//#02c92d
                recentGradientPanel.GradientPrimaryColor = ColorTranslator.FromHtml("#05a327");//#05a327
                recentGradientPanel.GradientSecondaryColor = ColorTranslator.FromHtml("#025413");//#025413
                bottomBlank.GradientPrimaryColor = ColorTranslator.FromHtml("#025413");//#025413
            }
            else if (state == 4)
            {
                topBlank.GradientSecondaryColor = ColorTranslator.FromHtml("#363601");//#363601
                homeGradientPanel.GradientPrimaryColor = ColorTranslator.FromHtml("#363601");//#363601
                homeGradientPanel.GradientSecondaryColor = ColorTranslator.FromHtml("#4a4a02");//#4a4a02
                searchGradientPanel.GradientPrimaryColor = ColorTranslator.FromHtml("#4a4a02");//#4a4a02
                searchGradientPanel.GradientSecondaryColor = ColorTranslator.FromHtml("#5e5e02");//#5e5e02
                heartGradientPanel.GradientPrimaryColor = ColorTranslator.FromHtml("#5e5e02");//#5e5e02
                heartGradientPanel.GradientSecondaryColor = ColorTranslator.FromHtml("#7d7d02");//#7d7d02
                libraryGradientPanel.GradientPrimaryColor = ColorTranslator.FromHtml("#7d7d02");//#7d7d02
                libraryGradientPanel.GradientSecondaryColor = ColorTranslator.FromHtml("#a1a105");//#a1a105
                recentGradientPanel.GradientPrimaryColor = ColorTranslator.FromHtml("#c7c704");//#c7c704
                recentGradientPanel.GradientSecondaryColor = ColorTranslator.FromHtml("#c7c704");//#c7c704
                bottomBlank.GradientPrimaryColor = ColorTranslator.FromHtml("#5e5e02");//#5e5e02
            }
        }
        private void homeLabel_Click(object sender, EventArgs e)
        {

            state = 0;
            verticalMenuBar.Paint += verticalMenuBar_Paint;
            mainFlowPanel.Paint += mainFlowPanel_Paint;
            mainFlowPanel.Invalidate();
            verticalMenuBar.Invalidate();

            homeFlowPanel.Controls.Add(bestBookFlowPanel);

            homeFlowPanel.Visible = true;
            searchFlowPanel.Visible = false;
            favoritePanel.Visible = false;
            categoriesPanel.Visible = false;
            historyPanel.Visible = false;
        }

        private void searchLabel_Click(object sender, EventArgs e)
        {
            state = 1;
            verticalMenuBar.Paint += verticalMenuBar_Paint;
            mainFlowPanel.Paint += mainFlowPanel_Paint;
            mainFlowPanel.Invalidate();
            verticalMenuBar.Invalidate();

            searchFlowPanel.Controls.Add(bestBookFlowPanel);

            homeFlowPanel.Visible = false;
            searchFlowPanel.Visible = true;
            favoritePanel.Visible = false;
            categoriesPanel.Visible = false;
            historyPanel.Visible = false;
        }

        private void heartLabel_Click(object sender, EventArgs e)
        {
            state = 2;
            verticalMenuBar.Paint += verticalMenuBar_Paint;
            mainFlowPanel.Paint += mainFlowPanel_Paint;
            mainFlowPanel.Invalidate();
            verticalMenuBar.Invalidate();

            homeFlowPanel.Visible = false;
            searchFlowPanel.Visible = false;
            favoritePanel.Visible = true;
            categoriesPanel.Visible = false;
            historyPanel.Visible = false;
        }

        private void librariesLabel_Click(object sender, EventArgs e)
        {
            state = 3;
            verticalMenuBar.Paint += verticalMenuBar_Paint;
            mainFlowPanel.Paint += mainFlowPanel_Paint;
            mainFlowPanel.Invalidate();
            verticalMenuBar.Invalidate();

            homeFlowPanel.Visible = false;
            searchFlowPanel.Visible = false;
            favoritePanel.Visible = false;
            categoriesPanel.Visible = true;
            historyPanel.Visible = false;
        }

        private void recentLabel_Click(object sender, EventArgs e)
        {
            state = 4;
            verticalMenuBar.Paint += verticalMenuBar_Paint;
            mainFlowPanel.Paint += mainFlowPanel_Paint;
            mainFlowPanel.Invalidate();
            verticalMenuBar.Invalidate();

            homeFlowPanel.Visible = false;
            searchFlowPanel.Visible = false;
            favoritePanel.Visible = false;
            categoriesPanel.Visible = false;
            historyPanel.Visible = true;
        }

        private void SearchBox_GotFocus(object sender, EventArgs e)
        {
            searchBoxContainer.GradientAngle = 250;
            searchBox.Text = "";
            searchBoxContainer.Invalidate();
        }

        private void SearchBox_LostFocus(object sender, EventArgs e)
        {
            searchBoxContainer.GradientAngle = 70;
            if (searchBox.Text.Length <= 0)
            {
                searchBox.Text = "What do you want to read?";
            }

            searchBoxContainer.Invalidate();
        }
        private void SearchBox_Hover(object sender, EventArgs e)
        {
            searchBoxContainer.GradientAngle = 160;
            searchBoxContainer.Invalidate();
        }

        private void SearchBox_MouseLeave(object sender, EventArgs e)
        {
            if (searchBox.Focused)
            {
                searchBoxContainer.GradientAngle = 250;
            }
            else searchBoxContainer.GradientAngle = 70;
            searchBoxContainer.Invalidate();
        }
        #endregion

        #region handle events when user picking a book to read
        private Book bookPicking(string name)
        {
            Book book = new Book();
            foreach (Book b in bookList)
            {
                if (b.title.Equals(name)) return b;
            }
            return book;
        }

        private void updateCurrentBook(Book book)
        {
            string imgPath = "../../../../../assets/LImgs/temp" + book.index + ".jpg";
            Image currentImg = Image.FromFile(imgPath);
            List<Book> categoryBooks = GetBookInCategory(book.publisher);

            contentImg.Image = SetHeight(currentImg, contentImg.Height);
            currentLabel.Image = SetHeight(currentImg, currentLabel.Height);

            contentTitle.Text = book.title;
            authorLabel.Text = book.author;
            publisherLabel.Text = book.publisher;
            contentYear.Text = book.year.ToString();

            currentBookTitle.Text = book.title;
            currentBookAuthor.Text = book.author;
            currentPublisher.Text = book.publisher;
            yearOfPublication.Text = book.year.ToString();

            Book book1 = categoryBooks.ElementAt(0);
            if (book.Equals(book1) && categoryBooks.Count > 1) book1 = categoryBooks.ElementAt(1);

            string imgPath1 = "../../../../../assets/LImgs/temp" + book1.index + ".jpg";
            if (!File.Exists(imgPath1)) GetBookImage(book1.index);
            categoryImg0.Image = SetHeight(Image.FromFile(imgPath1), categoryImg0.Height);
            categoryTitle0.Text = book1.title;
            categoryAuthor0.Text = book1.author;

            Color borderColor = CalculateAverageColor(GetBorderColors(new Bitmap(currentImg), currentImg.Size));

            currentPanel.BackColor = borderColor;
            currentProperties.GradientPrimaryColor = borderColor;
            currentProperties.GradientSecondaryColor = Color.Transparent;
            currentProperties.Invalidate();
        }

        private void helloElement0_Click(object sender, EventArgs e)
        {
            updateCurrentBook(bookPicking(helloElementTitle0.Text));
        }

        private void helloElement1_Click(object sender, EventArgs e)
        {
            updateCurrentBook(bookPicking(helloElementTitle1.Text));
        }

        private void helloElement2_Click(object sender, EventArgs e)
        {
            updateCurrentBook(bookPicking(helloElementTitle2.Text));
        }

        private void helloElement3_Click(object sender, EventArgs e)
        {
            updateCurrentBook(bookPicking(helloElementTitle3.Text));
        }

        private void recommentElement0_Click(object sender, EventArgs e)
        {
            updateCurrentBook(bookPicking(recommentTitle0.Text));
        }

        private void recommentElement1_Click(object sender, EventArgs e)
        {
            updateCurrentBook(bookPicking(recommentTitle1.Text));
        }

        private void recommentElement2_Click(object sender, EventArgs e)
        {
            updateCurrentBook(bookPicking(recommentTitle2.Text));
        }

        private void recommentElement3_Click(object sender, EventArgs e)
        {
            updateCurrentBook(bookPicking(recommentTitle3.Text));
        }

        private void bestBookLabel0_Click(object sender, EventArgs e)
        {
            updateCurrentBook(bookPicking(bestBookTitle0.Text));
        }

        private void bestBookLabel1_Click(object sender, EventArgs e)
        {
            updateCurrentBook(bookPicking(bestBookTitle1.Text));
        }

        private void bestBookLabel2_Click(object sender, EventArgs e)
        {
            updateCurrentBook(bookPicking(bestBookTitle2.Text));
        }

        private void bestBookLabel3_Click(object sender, EventArgs e)
        {
            updateCurrentBook(bookPicking(bestBookTitle3.Text));
        }
        private void topSearchFlowPanel_Click(object sender, EventArgs e)
        {
            updateCurrentBook(bookPicking(topSearchTitle.Text));
        }

        private void otherTitle0_Click(object sender, EventArgs e)
        {
            updateCurrentBook(bookPicking(otherTitle0.Text));
        }

        private void otherTitle1_Click(object sender, EventArgs e)
        {
            updateCurrentBook(bookPicking(otherTitle1.Text));
        }

        private void otherTitle2_Click(object sender, EventArgs e)
        {
            updateCurrentBook(bookPicking(otherTitle2.Text));
        }

        private void otherTitle3_Click(object sender, EventArgs e)
        {
            updateCurrentBook(bookPicking(otherTitle3.Text));
        }

        private void otherTitle4_Click(object sender, EventArgs e)
        {
            updateCurrentBook(bookPicking(otherTitle4.Text));
        }

        private void otherTitle5_Click(object sender, EventArgs e)
        {
            updateCurrentBook(bookPicking(otherTitle5.Text));
        }

        private void otherTitle6_Click(object sender, EventArgs e)
        {
            updateCurrentBook(bookPicking(otherTitle6.Text));
        }

        private void otherTitle7_Click(object sender, EventArgs e)
        {
            updateCurrentBook(bookPicking(otherTitle7.Text));
        }

        private void otherTitle8_Click(object sender, EventArgs e)
        {
            updateCurrentBook(bookPicking(otherTitle8.Text));
        }

        private void otherTitle9_Click(object sender, EventArgs e)
        {
            updateCurrentBook(bookPicking(otherTitle9.Text));
        }
        #endregion

        #region resize event handler
        private int difH;
        private int difW;
        private void MainForm_Resize(object sender, EventArgs e)
        {
            //homeFlowPanel resize
            homeFlowPanel.Height = mainFlowPanel.Height + difH;
            homeFlowPanel.Width = mainFlowPanel.Width + difW;

            helloPanel.Width = homeFlowPanel.Width;
            helloElement0.Width = (homeFlowPanel.Width) / 2 - 10;
            helloElement1.Width = (homeFlowPanel.Width) / 2 - 10;
            helloElement2.Width = (homeFlowPanel.Width) / 2 - 10;
            helloElement3.Width = (homeFlowPanel.Width) / 2 - 10;

            recommentPanel.Width = homeFlowPanel.Width;
            recommentElement0.Width = (homeFlowPanel.Width) / 2 - 10;
            recommentElement1.Width = (homeFlowPanel.Width) / 2 - 10;
            recommentElement2.Width = (homeFlowPanel.Width) / 2 - 10;
            recommentElement3.Width = (homeFlowPanel.Width) / 2 - 10;

            //searchFlowPanel resize
            searchFlowPanel.Height = mainFlowPanel.Height + difH;
            searchFlowPanel.Width = mainFlowPanel.Width + difW;

            searchPanel.Width = mainFlowPanel.Width / 3 + 150;
            searchPanel.Margin = new Padding((searchFlowPanel.Width - searchPanel.Width) / 2, 30, 3, 30);

            bestMatchPanel.Width = searchFlowPanel.Width;
            topSearchPanel.Width = searchFlowPanel.Width / 2 - 6;

            otherResult0.Width = searchFlowPanel.Width;
            otherResult1.Width = searchFlowPanel.Width;
            otherResult2.Width = searchFlowPanel.Width;
            otherResult3.Width = searchFlowPanel.Width;
            otherResult4.Width = searchFlowPanel.Width;
            otherResult5.Width = searchFlowPanel.Width;
            otherResult6.Width = searchFlowPanel.Width;
            otherResult7.Width = searchFlowPanel.Width;
            otherResult8.Width = searchFlowPanel.Width;
            otherResult9.Width = searchFlowPanel.Width;
            //bestBook resize
            bestBookFlowPanel.Height = mainFlowPanel.Height + difH;
            bestBookFlowPanel.Width = mainFlowPanel.Width + difW;

            bestBookPanel.Width = mainFlowPanel.Width + difW;
            bestBookElement0.Width = (mainFlowPanel.Width + difW) / 2 - 10;
            bestBookElement1.Width = (mainFlowPanel.Width + difW) / 2 - 10;
            bestBookElement2.Width = (mainFlowPanel.Width + difW) / 2 - 10;
            bestBookElement3.Width = (mainFlowPanel.Width + difW) / 2 - 10;

        }

        private void MainForm_ResizeBegin(object sender, EventArgs e)
        {
            difH = homeFlowPanel.Height - mainFlowPanel.Height;
            difW = homeFlowPanel.Width - mainFlowPanel.Width;
        }
        #endregion

        #region toolStrip handler

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                maximize.Image = Image.FromFile("../../../../../assets/icons/minimize.png");
                this.TopMost = true;
                this.Padding = new Padding(0);
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                maximize.Image = Image.FromFile("../../../../../assets/icons/maximize.png");
                this.Padding = new Padding(0, 0, 0, 20);
                this.WindowState = FormWindowState.Normal;
            }
        }

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        private void toolStrip1_MouseDown(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.SizeAll;
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }
        private void mainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void mainForm_MouseUp(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Default;
            dragging = false;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region searching handler
        private void searchBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bestMatchLabel.Text = "Best match:";
                topSearchPanel.Visible = false;
                otherResult0.Visible = false;
                otherResult1.Visible = false;
                otherResult2.Visible = false;
                otherResult3.Visible = false;
                otherResult4.Visible = false;
                otherResult5.Visible = false;
                otherResult6.Visible = false;
                otherResult7.Visible = false;
                otherResult8.Visible = false;
                otherResult9.Visible = false;

                string searchKey = searchBox.Text.ToString();
                if (searchKey.Length == 0) return;

                List<Book> books = SearchBookInformation(searchKey);
                if (books.Count == 0) bestMatchLabel.Text = "Not found!";
                if (books.Count >= 1)
                {
                    topSearchImg.Image = SetHeight(GetBookImage(books.ElementAt(0).index), topSearchImg.Height);
                    topSearchTitle.Text = books.ElementAt(0).title;
                    topSearchAuthor.Text = books.ElementAt(0).author;
                    topSearchPanel.Visible = true;
                }
                if (books.Count >= 2)
                {
                    otherImg0.Image = SetHeight(GetBookImage(books.ElementAt(1).index), otherImg0.Height);
                    otherTitle0.Text = books.ElementAt(1).title;
                    toolTip1.SetToolTip(otherTitle0, "by "+books.ElementAt(1).author);
                    otherResult0.Visible = true;
                }
                if (books.Count >= 3)
                {
                    otherImg1.Image = SetHeight(GetBookImage(books.ElementAt(2).index), otherImg1.Height);
                    otherTitle1.Text = books.ElementAt(2).title;
                    toolTip1.SetToolTip(otherTitle1, "by "+books.ElementAt(2).author);
                    otherResult1.Visible = true;
                }
                if (books.Count >= 4)
                {
                    otherImg2.Image = SetHeight(GetBookImage(books.ElementAt(3).index), otherImg2.Height);
                    otherTitle2.Text = books.ElementAt(3).title;
                    toolTip1.SetToolTip(otherTitle2, "by "+books.ElementAt(3).author);
                    otherResult2.Visible = true;
                }
                if (books.Count >= 5)
                {
                    otherImg3.Image = SetHeight(GetBookImage(books.ElementAt(4).index), otherImg3.Height);
                    otherTitle3.Text = books.ElementAt(4).title;
                    toolTip1.SetToolTip(otherTitle3, "by "+books.ElementAt(4).author);
                    otherResult3.Visible = true;
                }
                if (books.Count >= 6)
                {
                    otherImg4.Image = SetHeight(GetBookImage(books.ElementAt(5).index), otherImg4.Height);
                    otherTitle4.Text = books.ElementAt(5).title;
                    toolTip1.SetToolTip(otherTitle4, "by "+books.ElementAt(5).author);
                    otherResult4.Visible = true;
                }
                if (books.Count >= 7)
                {
                    otherImg5.Image = SetHeight(GetBookImage(books.ElementAt(6).index), otherImg5.Height);
                    otherTitle5.Text = books.ElementAt(6).title;
                    toolTip1.SetToolTip(otherTitle5, "by "+books.ElementAt(6).author);
                    otherResult5.Visible = true;
                }
                if (books.Count >= 8)
                {
                    otherImg6.Image = SetHeight(GetBookImage(books.ElementAt(7).index), otherImg6.Height);
                    otherTitle6.Text = books.ElementAt(7).title;
                    toolTip1.SetToolTip(otherTitle6, "by "+books.ElementAt(7).author);
                    otherResult6.Visible = true;
                }
                if (books.Count >= 9)
                {
                    otherImg7.Image = SetHeight(GetBookImage(books.ElementAt(8).index), otherImg7.Height);
                    otherTitle7.Text = books.ElementAt(8).title;
                    toolTip1.SetToolTip(otherTitle7, "by "+books.ElementAt(8).author);
                    otherResult7.Visible = true;
                }
                if (books.Count >= 10)
                {
                    otherImg8.Image = SetHeight(GetBookImage(books.ElementAt(9).index), otherImg8.Height);
                    otherTitle8.Text = books.ElementAt(9).title;
                    toolTip1.SetToolTip(otherTitle8, "by "+books.ElementAt(9).author);
                    otherResult8.Visible = true;
                }
                if (books.Count >= 11)
                {
                    otherImg9.Image = SetHeight(GetBookImage(books.ElementAt(10).index), otherImg9.Height);
                    otherTitle9.Text = books.ElementAt(10).title;
                    toolTip1.SetToolTip(otherTitle9, "by "+books.ElementAt(10).author);
                    otherResult9.Visible = true;
                }
                bestMatchPanel.Visible = true;
            }
        }
        #endregion

    }
}
