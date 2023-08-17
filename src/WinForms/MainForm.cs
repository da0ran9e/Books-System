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
using System.Reflection.Emit;

namespace WinForms
{
    public partial class MainForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\vuduc\OneDrive\Documents\BX.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;

        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }
        public static Image SetHeight(Image imgToResize, int height)
        {
            int w = imgToResize.Width;
            int h = imgToResize.Height;
            int width = (height * w / h);
            Size size = new Size(width, height);
            return (Image)(new Bitmap(imgToResize, size));
        }

        private Image GetBookImage(int index)
        {
            Image img = Image.FromFile("../../../../../assets/icons/image_L.png");
            try
            {
                cmd = new SqlCommand("select [imageURLL] from books where [index] = " + index, con);
                con.Open();
                dr = cmd.ExecuteReader();
                dr.Read();

                if (dr.HasRows)
                {
                    string url = dr.GetFieldValue<string>(0);
                    string imgPath = "../../../../../assets/LImgs/temp" + index + ".jpg";
                    try
                    {
                        // if the image does not exist, then get it
                        if (!File.Exists(imgPath))
                        {
                            HttpClient client = new HttpClient();
                            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/93.0.4577.63 Safari/537.36");
                            HttpResponseMessage response = client.GetAsync(url).Result;
                            response.EnsureSuccessStatusCode();
                            using (Stream stream = response.Content.ReadAsStreamAsync().Result)
                            {
                                Image image = Image.FromStream(stream);

                                image.Save(imgPath);
                            }
                        }

                        //load image to tha label

                        if (Image.FromFile(imgPath).Height >= 70)
                            img = Image.FromFile(imgPath);

                        return img;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
                else
                {
                    dr.Close();
                    con.Close();
                    return GetBookImage(index + 1);
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
            return img;
        }

        public struct Book
        {
            public string isbn { get; set; }
            public string title { get; set; }
            public string author { get; set; }
            public string publisher { get; set; }
            public int year { get; set; }

            public Book()
            {
                this.isbn = null;
                this.title = null;
                this.author = null;
                this.publisher = null;
                this.year = 0;
            }

            public Book(string isbn, string title, string author, string publisher, int year)
            {
                this.isbn = isbn;
                this.title = title;
                this.author = author;
                this.publisher = publisher;
                this.year = year;
            }
        }
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
                    book.isbn = dr.GetFieldValue<string>(1);
                    book.title = dr.GetFieldValue<string>(2);
                    book.author = dr.GetFieldValue<string>(3);
                    book.year = dr.GetFieldValue<int>(4);
                    book.publisher = dr.GetFieldValue<string>(5);

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
            return book;
        }

        private Color[] GetBorderColors(Bitmap image, Size size)
        {
            int width = image.Width;
            int height = image.Height;

            Color[] borderColors = new Color[(size.Width * 2) + (size.Height * 2)]; // 4 edges

            for (int i = 0; i < size.Height; i++)
            {
                borderColors[i] = image.GetPixel(0, i); // Đỉnh trái
                borderColors[i + size.Height] = image.GetPixel(width - 1, i); // Đỉnh phải
            }
            for (int i = 0; i < size.Width; i++)
            {
                borderColors[i + size.Height * 2] = image.GetPixel(i, 0); // Đỉnh trên
                borderColors[i + size.Height * 2 + size.Width] = image.GetPixel(i, height - 1); // Đỉnh dưới
            }

            return borderColors;
        }

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

        public MainForm(string username)
        {
            this.username = username;
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //EnableBlur();
            toolTip1.SetToolTip(userLabel, username);

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

            currentBookTitle.Text = book.title;
            currentBookAuthor.Text = book.author;
            currentPublisher.Text = book.publisher;
            yearOfPublication.Text = book.year.ToString();


            currentPanel.BackColor = borderColor;
            currentProperties.GradientPrimaryColor = borderColor;
            currentProperties.GradientSecondaryColor = Color.Transparent;
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
            LinearGradientBrush lgb = new LinearGradientBrush(contentContainer.ClientRectangle, ColorTranslator.FromHtml("#300004"), contentContainer.BackColor, 90F);
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

        private void userLabel_MouseHover(object sender, EventArgs e)
        {

        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {

        }

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

            homeFlowPanel.Visible = true;
            searchFlowPanel.Visible = false;
        }

        private void searchLabel_Click(object sender, EventArgs e)
        {
            state = 1;
            verticalMenuBar.Paint += verticalMenuBar_Paint;
            mainFlowPanel.Paint += mainFlowPanel_Paint;
            mainFlowPanel.Invalidate();
            verticalMenuBar.Invalidate();

            homeFlowPanel.Visible = false;
            searchFlowPanel.Visible = true;
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
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void searchBox_Paint(object sender, PaintEventArgs e)
        {

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

        private void helloElementTable0_Paint(object sender, PaintEventArgs e)
        {

        }

        private void helloElementTitle2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
