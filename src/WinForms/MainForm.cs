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
using WinForms.Properties;
using System.Resources;
using System.Diagnostics.CodeAnalysis;

namespace WinForms
{
    public partial class MainForm : Form
    {
        public string EscapeSingleQuotes(string str)
        {
            string result = str;
            int pos = result.IndexOf("'");
            while (pos != -1)
            {
                result = result.Substring(0, pos) + "''" + result.Substring(pos + 1);
                pos = result.IndexOf("'", pos + 2);
            }
            return result;
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
                MessageBox.Show("Double buffer exception: "+ex.Message);
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

        public static Image SetWidth(Image imgToResize, int width)
        {
            int w = imgToResize.Width;
            int h = imgToResize.Height;
            int height = (width * h / w);
            Size size = new Size(width, height);
            return (Image)(new Bitmap(imgToResize, size));
        }

        //private Stream LoaderFromURL(string url)
        //{
        //    try
        //    {
        //        HttpClient client = new HttpClient();
        //        client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/93.0.4577.63 Safari/537.36");
        //        HttpResponseMessage responseString = client.GetAsync(url).Result;
        //        responseString.EnsureSuccessStatusCode();

        //        return responseString.Content.ReadAsStreamAsync().Result;
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}

        //private Image GetBookImage(int index)
        //{
        //    Image img = Image.FromFile("../../../../../assets/icons/image_L.png");
        //    string imgPath = "../../../../../assets/LImgs/temp" + index + ".jpg";
        //    try
        //    {
        //        Book book = GetBookInformation(index);
        //        // if the image does not exist, then get it
        //        if (!File.Exists(imgPath))
        //        {
        //            using (Stream stream = LoaderFromURL(book.lURL))
        //            {
        //                Image image = Image.FromStream(stream);
        //                if (image.Height <= 20)
        //                {
        //                    image = Image.FromStream(LoaderFromURL(book.mURL));
        //                }
        //                image.Save(imgPath);
        //            }
        //        }

        //        //load image to tha label

        //        if (Image.FromFile(imgPath).Height >= 70)
        //            return img = Image.FromFile(imgPath);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error: {ex.Message}");
        //    }
        //    return img;
        //}


        //
        //Gather color of image border by pixels
        //
        //private Color[] GetBorderColors(Bitmap image, Size size)
        //{
        //    int width = image.Width;
        //    int height = image.Height;

        //    Color[] borderColors = new Color[(size.Width * 2) + (size.Height * 2)]; // 4 edges

        //    for (int i = 0; i < size.Height; i++)
        //    {
        //        borderColors[i] = image.GetPixel(0, i); // left edge
        //        borderColors[i + size.Height] = image.GetPixel(width - 1, i); // right edge
        //    }
        //    for (int i = 0; i < size.Width; i++)
        //    {
        //        borderColors[i + size.Height * 2] = image.GetPixel(i, 0); // top edge
        //        borderColors[i + size.Height * 2 + size.Width] = image.GetPixel(i, height - 1); // bottom edge
        //    }

        //    return borderColors;
        //}

        ////
        ////Analyze color
        ////
        //private Color CalculateAverageColor(Color[] colors)
        //{
        //    int totalR = 0, totalG = 0, totalB = 0;

        //    foreach (Color color in colors)
        //    {
        //        totalR += color.R;
        //        totalG += color.G;
        //        totalB += color.B;
        //    }

        //    int averageR = totalR / colors.Length;
        //    int averageG = totalG / colors.Length;
        //    int averageB = totalB / colors.Length;

        //    return Color.FromArgb(averageR, averageG, averageB);
        //}

        #endregion

        #region update favorite list 
        public void AddFavBook(Book newBook, int bookIndex, int bookScore)
        {
            TableLayoutPanel newBookTable1 = new TableLayoutPanel();
            TableLayoutPanel newBookTable2 = new TableLayoutPanel();
            System.Windows.Forms.Label newBookLabel1 = new System.Windows.Forms.Label();
            System.Windows.Forms.Label newBookLabel2 = new System.Windows.Forms.Label();
            System.Windows.Forms.Label newBookLabel3 = new System.Windows.Forms.Label();
            System.Windows.Forms.Label newBookLabel4 = new System.Windows.Forms.Label();
            System.Windows.Forms.Label newBookLabel5 = new System.Windows.Forms.Label();
            System.Windows.Forms.Label newBookLabel6 = new System.Windows.Forms.Label();
            System.Windows.Forms.Label newBookLabel7 = new System.Windows.Forms.Label();
            GradientPanel newBookPanel1 = new GradientPanel();
            GradientPanel newBookPanel2 = new GradientPanel();
            FlowLayoutPanel newBookFlowPanel1 = new FlowLayoutPanel();
            FlowLayoutPanel newBookFlowPanel2 = new FlowLayoutPanel();

            SetDoubleBuffer(favFlowPanel, true);
            SetDoubleBuffer(newBookTable1, true);
            SetDoubleBuffer(newBookTable2, true);
            SetDoubleBuffer(newBookLabel1, true);
            SetDoubleBuffer(newBookLabel2, true);
            SetDoubleBuffer(newBookLabel3, true);
            SetDoubleBuffer(newBookLabel4, true);
            SetDoubleBuffer(newBookLabel5, true);
            SetDoubleBuffer(newBookLabel6, true);
            SetDoubleBuffer(newBookLabel7, true);
            SetDoubleBuffer(newBookPanel1, true);
            SetDoubleBuffer(newBookPanel2, true);
            SetDoubleBuffer(newBookFlowPanel1, true);
            SetDoubleBuffer(newBookFlowPanel2, true);


            favFlowPanel.Controls.Add(newBookTable1);
            favoritePanel.SetFlowBreak(newBookTable1, true);


            // 
            // newBookTable1
            // 
            newBookTable1.ColumnCount = 4;
            newBookTable1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            newBookTable1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            newBookTable1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            newBookTable1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            newBookTable1.Controls.Add(newBookLabel3, 0, 0);
            newBookTable1.Controls.Add(newBookLabel4, 3, 0);
            newBookTable1.Controls.Add(newBookPanel1, 1, 0);
            newBookTable1.Controls.Add(newBookPanel2, 2, 0);
            newBookTable1.Location = new Point(0, 132);
            newBookTable1.Margin = new Padding(0);
            newBookTable1.Name = "newBook" + newBook.isbn;
            newBookTable1.AccessibleName = newBook.title;
            newBookTable1.AccessibleDescription = newBook.publisher;
            newBookTable1.RowCount = 1;
            newBookTable1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            newBookTable1.Size = new Size(732, 80);
            newBookTable1.TabIndex = 15;
            newBookTable1.Click += NewBook_Click;
            // 
            // newBookLabel3
            // 
            newBookLabel3.Font = new Font("Exo ExtraBold", bookIndex == 1 ? 16.2F : 11F, FontStyle.Bold, GraphicsUnit.Point);
            newBookLabel3.ForeColor = SystemColors.ButtonHighlight;
            newBookLabel3.Location = new Point(0, 0);
            newBookLabel3.Margin = new Padding(0);
            newBookLabel3.Name = "newBookRank" + newBook.isbn;
            newBookLabel3.Size = new Size(50, 80);
            newBookLabel3.TabIndex = 11;
            newBookLabel3.Text = bookIndex.ToString();
            newBookLabel3.AccessibleName = newBook.title;
            newBookLabel3.AccessibleDescription = newBook.publisher;
            newBookLabel3.TextAlign = ContentAlignment.MiddleCenter;
            newBookLabel3.Click += NewBook_Click;
            // 
            // newBookLabel4
            // 
            newBookLabel4.Font = new Font("Exo ExtraBold", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            newBookLabel4.ForeColor = SystemColors.ButtonHighlight;
            newBookLabel4.Location = new Point(681, 0);
            newBookLabel4.Margin = new Padding(0);
            newBookLabel4.Name = "newBookScore" + newBook.isbn;
            newBookLabel4.Size = new Size(50, 80);
            newBookLabel4.TabIndex = 14;
            newBookLabel4.Text = bookScore.ToString();
            newBookLabel4.TextAlign = ContentAlignment.MiddleCenter;
            newBookLabel4.AccessibleName = newBook.title;
            newBookLabel4.AccessibleDescription = newBook.publisher;
            newBookLabel4.Click += NewBook_Click;
            // 
            // newBookPanel1
            // 
            newBookPanel1.Controls.Add(newBookTable2);
            newBookPanel1.GradientAngle = 60F;
            newBookPanel1.GradientPrimaryColor = Color.Transparent;
            newBookPanel1.GradientSecondaryColor = Color.White;
            newBookPanel1.Location = new Point(50, 0);
            newBookPanel1.Margin = new Padding(0);
            newBookPanel1.Name = "newBookfavBook" + newBook.isbn;
            newBookPanel1.Size = new Size(379, 80);
            newBookPanel1.TabIndex = 12;
            newBookPanel1.AccessibleName = newBook.title;
            newBookPanel1.AccessibleDescription = newBook.publisher;
            newBookPanel1.Click += NewBook_Click;
            // 
            // newBookTable2
            // 
            newBookTable2.AutoSize = true;
            newBookTable2.ColumnCount = 2;
            newBookTable2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            newBookTable2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            newBookTable2.Controls.Add(newBookLabel5, 0, 0);
            newBookTable2.Controls.Add(newBookFlowPanel2, 1, 0);
            newBookTable2.Dock = DockStyle.Fill;
            newBookTable2.Location = new Point(0, 0);
            newBookTable2.Name = "newBookfavBookTable" + newBook.isbn;
            newBookTable2.RowCount = 1;
            newBookTable2.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
            newBookTable2.Size = new Size(379, 80);
            newBookTable2.TabIndex = 0;
            newBookTable2.AccessibleName = newBook.title;
            newBookTable2.AccessibleDescription = newBook.publisher;
            newBookTable2.Click += NewBook_Click;
            // 
            // newBookLabel5
            // 
            newBookLabel5.BackColor = Color.Transparent;
            newBookLabel5.Image = SetHeight(new BookCover(newBook).image, 82);
            newBookLabel5.Location = new Point(3, 0);
            newBookLabel5.Name = "newBookImg" + newBook.isbn;
            newBookLabel5.Size = new Size(82, 88);
            newBookLabel5.TabIndex = 0;
            newBookLabel5.AccessibleName = newBook.title;
            newBookLabel5.AccessibleDescription = newBook.publisher;
            newBookLabel5.Click += NewBook_Click;
            // 
            // newBookFlowPanel2
            // 
            newBookFlowPanel2.Controls.Add(newBookLabel6);
            newBookFlowPanel2.Controls.Add(newBookLabel7);
            newBookFlowPanel2.Dock = DockStyle.Fill;
            newBookFlowPanel2.Location = new Point(91, 3);
            newBookFlowPanel2.Name = "newBookTitlePanel" + newBook.isbn;
            newBookFlowPanel2.Size = new Size(285, 82);
            newBookFlowPanel2.TabIndex = 1;
            newBookFlowPanel2.AccessibleName = newBook.title;
            newBookFlowPanel2.AccessibleDescription = newBook.publisher;
            newBookFlowPanel2.Click += NewBook_Click;
            // 
            // newBookLabel6
            // 
            newBookLabel6.AutoSize = true;
            newBookLabel6.BackColor = Color.Transparent;
            newBookFlowPanel2.SetFlowBreak(newBookLabel6, true);
            newBookLabel6.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            newBookLabel6.ForeColor = SystemColors.ControlLight;
            newBookLabel6.Location = new Point(3, 0);
            newBookLabel6.Name = "newBookTitle" + newBook.isbn;
            newBookLabel6.Size = new Size(50, 28);
            newBookLabel6.TabIndex = 1;
            newBookLabel6.Text = newBook.title;
            newBookLabel6.AccessibleName = newBook.title;
            newBookLabel6.AccessibleDescription = newBook.publisher;
            newBookLabel6.Click += NewBook_Click;
            // 
            // newBookLabel7
            // 
            newBookLabel7.AutoSize = true;
            newBookLabel7.BackColor = Color.Transparent;
            newBookFlowPanel2.SetFlowBreak(newBookLabel7, true);
            newBookLabel7.Font = new Font("Exo ExtraBold", 7.799999F, FontStyle.Bold, GraphicsUnit.Point);
            newBookLabel7.ForeColor = SystemColors.ControlLight;
            newBookLabel7.Location = new Point(3, 28);
            newBookLabel7.Name = "newBookAuthor" + newBook.isbn;
            newBookLabel7.Size = new Size(50, 19);
            newBookLabel7.TabIndex = 3;
            newBookLabel7.Text = "author";
            newBookLabel7.AccessibleName = newBook.title;
            newBookLabel7.AccessibleDescription = newBook.publisher;
            newBookLabel7.Click += NewBook_Click;
            // 
            // newBookPanel2
            // 
            newBookPanel2.Controls.Add(newBookFlowPanel1);
            newBookPanel2.Dock = DockStyle.Fill;
            newBookPanel2.GradientAngle = 60F;
            newBookPanel2.GradientPrimaryColor = Color.Transparent;
            newBookPanel2.GradientSecondaryColor = Color.White;
            newBookPanel2.Location = new Point(429, 0);
            newBookPanel2.Margin = new Padding(0);
            newBookPanel2.Name = "newBookCategoryPanel" + newBook.isbn;
            newBookPanel2.Size = new Size(252, 80);
            newBookPanel2.TabIndex = 13;
            newBookPanel2.AccessibleName = newBook.title;
            newBookPanel2.AccessibleDescription = newBook.publisher;
            newBookPanel2.Click += NewBook_Click;
            // 
            // newBookFlowPanel1
            // 
            newBookFlowPanel1.Controls.Add(newBookLabel1);
            newBookFlowPanel1.Controls.Add(newBookLabel2);
            newBookFlowPanel1.Dock = DockStyle.Fill;
            newBookFlowPanel1.Location = new Point(0, 0);
            newBookFlowPanel1.Margin = new Padding(0);
            newBookFlowPanel1.Name = "newBookCategoryFlowPanel" + newBook.isbn;
            newBookFlowPanel1.Size = new Size(252, 80);
            newBookFlowPanel1.TabIndex = 2;
            newBookFlowPanel1.AccessibleName = newBook.title;
            newBookFlowPanel1.AccessibleDescription = newBook.publisher;
            newBookFlowPanel1.Click += NewBook_Click;
            // 
            // newBookLabel1
            // 
            newBookLabel1.AutoSize = true;
            newBookLabel1.BackColor = Color.Transparent;
            newBookFlowPanel1.SetFlowBreak(newBookLabel1, true);
            newBookLabel1.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            newBookLabel1.ForeColor = SystemColors.ControlLight;
            newBookLabel1.Location = new Point(3, 0);
            newBookLabel1.Name = "newBookPublisher" + newBook.isbn;
            newBookLabel1.Size = new Size(50, 28);
            newBookLabel1.TabIndex = 1;
            newBookLabel1.Text = newBook.publisher;
            newBookLabel1.AccessibleName = newBook.title;
            newBookLabel1.AccessibleDescription = newBook.publisher;
            newBookLabel1.Click += NewBook_Click;
            // 
            // newBookLabel2
            // 
            newBookLabel2.AutoSize = true;
            newBookLabel2.BackColor = Color.Transparent;
            newBookFlowPanel1.SetFlowBreak(newBookLabel2, true);
            newBookLabel2.Font = new Font("Exo ExtraBold", 7.799999F, FontStyle.Bold, GraphicsUnit.Point);
            newBookLabel2.ForeColor = SystemColors.ControlLight;
            newBookLabel2.Location = new Point(3, 28);
            newBookLabel2.Name = "newBookYear" + newBook.isbn;
            newBookLabel2.Size = new Size(50, 19);
            newBookLabel2.TabIndex = 3;
            newBookLabel2.Text = newBook.year.ToString();
            newBookLabel2.AccessibleName = newBook.title;
            newBookLabel2.AccessibleDescription = newBook.publisher;
            newBookLabel2.Click += NewBook_Click;
        }

        private void NewBook_Click(object sender, EventArgs e)
        {
            Control a = sender as Control;
            updateCurrentBook(bookPicking(a.AccessibleName));
        }

        private void NewCategory_Click(object sender, EventArgs e)
        {
            Control a = sender as Control;
            updateCurrentBook(bookPicking(a.AccessibleName));
        }
        #endregion

        #region clear list
        public void ClearList(Control parentControl, string elemKey)
        {
            foreach (Control elem in parentControl.Controls.OfType<Control>().ToList())
            {
                if (elem.Name == elemKey)
                {
                    parentControl.Controls.Remove(elem);
                }
            }
        }
        #endregion

        #region resize list
        public void ResizeList(Control parentControl, string elemKey)
        {
            foreach (Control elem in parentControl.Controls.OfType<Control>().ToList())
            {
                if (elem.Name == elemKey)
                {
                    elem.Size = new Size((mainCategoryPanel.Width) / 2 - 12, 88);
                }
            }
        }
        #endregion

        #region update category list

        public void AddCategryBook(Book newBook, string categoryName)
        {
            GradientPanel newCategoryBook = new GradientPanel();
            TableLayoutPanel newCategoryBookTable = new TableLayoutPanel();
            System.Windows.Forms.Label newCategoryBookImg = new System.Windows.Forms.Label();
            System.Windows.Forms.Label newCategoryBookTitle = new System.Windows.Forms.Label();
            System.Windows.Forms.Label newCategoryBookAuthor = new System.Windows.Forms.Label();
            FlowLayoutPanel newCategoryBookTitlePanel = new FlowLayoutPanel();

            SetDoubleBuffer(newCategoryBook, true);
            SetDoubleBuffer(newCategoryBookTable, true);
            SetDoubleBuffer(newCategoryBookImg, true);
            SetDoubleBuffer(newCategoryBookTitle, true);
            SetDoubleBuffer(newCategoryBookAuthor, true);
            SetDoubleBuffer(newCategoryBookTitlePanel, true);

            mainCategoryPanel.Controls.Add(newCategoryBook);
            // 
            // categoryMainLabel
            // 
            mainCategoryPanel.SetFlowBreak(categoryMainLabel, true);
            categoryMainLabel.Font = new Font("Exo ExtraBold", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point);
            categoryMainLabel.ForeColor = SystemColors.ControlLightLight;
            categoryMainLabel.Location = new Point(3, 0);
            categoryMainLabel.Name = "categoryMainLabel";
            categoryMainLabel.Size = new Size(categoriesPanel.Width, 82);
            categoryMainLabel.TabIndex = 0;
            categoryMainLabel.Text = "Category of " + categoryName;
            // 
            // newCategoryBook
            // 
            newCategoryBook.AccessibleName = newBook.title;
            newCategoryBook.Click += NewCategoryBook_Click;
            newCategoryBook.BackColor = Color.Transparent;
            newCategoryBook.Controls.Add(newCategoryBookTable);
            newCategoryBook.GradientAngle = 60F;
            newCategoryBook.GradientPrimaryColor = Color.Transparent;
            newCategoryBook.GradientSecondaryColor = Color.White;
            newCategoryBook.Location = new Point(3, 85);
            newCategoryBook.Margin = new Padding(0);
            newCategoryBook.Name = "newCategoryBook";
            newCategoryBook.Size = new Size((mainCategoryPanel.Width) / 2 - 12, 88);
            newCategoryBook.TabIndex = 4;
            // 
            // newCategoryBookTable
            // 
            newCategoryBookTable.AccessibleName = newBook.title;
            newCategoryBookTable.Click += NewCategoryBook_Click;
            newCategoryBookTable.AutoSize = true;
            newCategoryBookTable.ColumnCount = 2;
            newCategoryBookTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            newCategoryBookTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            newCategoryBookTable.Controls.Add(newCategoryBookImg, 0, 0);
            newCategoryBookTable.Controls.Add(newCategoryBookTitlePanel, 1, 0);
            newCategoryBookTable.Dock = DockStyle.Fill;
            newCategoryBookTable.Location = new Point(0, 0);
            newCategoryBookTable.Name = "newCategoryBookTable";
            newCategoryBookTable.RowCount = 1;
            newCategoryBookTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
            newCategoryBookTable.Size = new Size(349, 88);
            newCategoryBookTable.TabIndex = 0;
            // 
            // newCategoryBookImg
            // 
            newCategoryBookImg.AccessibleName = newBook.title;
            newCategoryBookImg.Click += NewCategoryBook_Click;
            newCategoryBookImg.BackColor = Color.Transparent;
            newCategoryBookImg.Image = SetHeight(new BookCover(newBook).image, 82);
            newCategoryBookImg.Location = new Point(3, 0);
            newCategoryBookImg.Name = "newCategoryBookImg";
            newCategoryBookImg.Size = new Size(82, 88);
            newCategoryBookImg.TabIndex = 0;
            // 
            // newCategoryBookTitlePanel
            // 
            newCategoryBookTitlePanel.AutoSize = true;
            newCategoryBookTitlePanel.AccessibleName = newBook.title;
            newCategoryBookTitlePanel.Click += NewCategoryBook_Click;
            newCategoryBookTitlePanel.Controls.Add(newCategoryBookTitle);
            newCategoryBookTitlePanel.Controls.Add(newCategoryBookAuthor);
            newCategoryBookTitlePanel.Dock = DockStyle.Fill;
            newCategoryBookTitlePanel.Location = new Point(91, 3);
            newCategoryBookTitlePanel.Name = "newCategoryBookTitlePanel";
            newCategoryBookTitlePanel.Size = new Size(255, 82);
            newCategoryBookTitlePanel.TabIndex = 1;
            // 
            // newCategoryBookTitle
            // 
            newCategoryBookTitle.AccessibleName = newBook.title;
            newCategoryBookTitle.Click += NewCategoryBook_Click;
            newCategoryBookTitle.AutoSize = true;
            newCategoryBookTitle.BackColor = Color.Transparent;
            newCategoryBookTitlePanel.SetFlowBreak(newCategoryBookTitle, true);
            newCategoryBookTitle.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            newCategoryBookTitle.ForeColor = SystemColors.ControlLight;
            newCategoryBookTitle.Location = new Point(3, 0);
            newCategoryBookTitle.Name = "newCategoryBookTitle";
            newCategoryBookTitle.Size = new Size(50, 28);
            newCategoryBookTitle.TabIndex = 1;
            newCategoryBookTitle.Text = newBook.title;
            // 
            // newCategoryBookAuthor
            // 
            newCategoryBookAuthor.AccessibleName = newBook.title;
            newCategoryBookAuthor.Click += NewCategoryBook_Click;
            newCategoryBookAuthor.AutoSize = true;
            newCategoryBookAuthor.BackColor = Color.Transparent;
            newCategoryBookTitlePanel.SetFlowBreak(newCategoryBookAuthor, true);
            newCategoryBookAuthor.Font = new Font("Exo ExtraBold", 7.799999F, FontStyle.Bold, GraphicsUnit.Point);
            newCategoryBookAuthor.ForeColor = SystemColors.ControlLight;
            newCategoryBookAuthor.Location = new Point(3, 28);
            newCategoryBookAuthor.Name = "newCategoryBookAuthor";
            newCategoryBookAuthor.Size = new Size(50, 19);
            newCategoryBookAuthor.TabIndex = 2;
            newCategoryBookAuthor.Text = newBook.author;
        }

        public void NewCategoryBook_Click(object sender, EventArgs e)
        {
            Control a = sender as Control;
            updateCurrentBook(bookPicking(a.AccessibleName));
        }
        #endregion

        #region update author book list

        public void AddAuthorBook(Book newBook)
        {
            GradientPanel authorBook = new GradientPanel();
            TableLayoutPanel authorBookTable = new TableLayoutPanel();
            System.Windows.Forms.Label authorBookImg = new System.Windows.Forms.Label();
            System.Windows.Forms.Label authorBookTitle = new System.Windows.Forms.Label();
            System.Windows.Forms.Label authorBookAuthor = new System.Windows.Forms.Label();
            FlowLayoutPanel authorBookTitlePanel = new FlowLayoutPanel();

            SetDoubleBuffer(authorBook, true);
            SetDoubleBuffer(authorBookTable, true);
            SetDoubleBuffer(authorBookImg, true);
            SetDoubleBuffer(authorBookTitle, true);
            SetDoubleBuffer(authorBookAuthor, true);
            SetDoubleBuffer(authorBookTitlePanel, true);

            authormainFlowPanel.Controls.Add(authorBook);
            // 
            // authorMainLabel
            // 
            authormainFlowPanel.SetFlowBreak(authorMainLabel, true);
            authorMainLabel.Font = new Font("Exo ExtraBold", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point);
            authorMainLabel.ForeColor = SystemColors.ControlLightLight;
            authorMainLabel.Location = new Point(3, 0);
            authorMainLabel.Name = "authorMainLabel";
            authorMainLabel.Size = new Size(categoriesPanel.Width, 82);
            authorMainLabel.TabIndex = 0;
            authorMainLabel.Text = "Writen by " + newBook.author;
            // 
            // authorBook
            // 
            authorBook.AccessibleName = newBook.title;
            authorBook.Click += AuthorBook_Click;
            authorBook.BackColor = Color.Transparent;
            authorBook.Controls.Add(authorBookTable);
            authorBook.GradientAngle = 60F;
            authorBook.GradientPrimaryColor = Color.Transparent;
            authorBook.GradientSecondaryColor = Color.White;
            authorBook.Location = new Point(3, 85);
            authorBook.Margin = new Padding(0);
            authorBook.Name = "authorBook";
            authorBook.Size = new Size((mainCategoryPanel.Width) / 2 - 12, 88);
            authorBook.TabIndex = 4;
            // 
            // authorBookTable
            // 
            authorBookTable.AccessibleName = newBook.title;
            authorBookTable.Click += AuthorBook_Click;
            authorBookTable.AutoSize = true;
            authorBookTable.ColumnCount = 2;
            authorBookTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            authorBookTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            authorBookTable.Controls.Add(authorBookImg, 0, 0);
            authorBookTable.Controls.Add(authorBookTitlePanel, 1, 0);
            authorBookTable.Dock = DockStyle.Fill;
            authorBookTable.Location = new Point(0, 0);
            authorBookTable.Name = "authorBookTable";
            authorBookTable.RowCount = 1;
            authorBookTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
            authorBookTable.Size = new Size(349, 88);
            authorBookTable.TabIndex = 0;
            // 
            // authorBookImg
            // 
            authorBookImg.AccessibleName = newBook.title;
            authorBookImg.Click += AuthorBook_Click;
            authorBookImg.BackColor = Color.Transparent;
            authorBookImg.Location = new Point(3, 0);
            authorBookImg.Image = SetHeight(new BookCover(newBook).image, 82);
            authorBookImg.Name = "authorBookImg";
            authorBookImg.Size = new Size(82, 88);
            authorBookImg.TabIndex = 0;
            // 
            // authorBookTitlePanel
            // 
            authorBookTitlePanel.AutoSize = true;
            authorBookTitlePanel.Controls.Add(authorBookTitle);
            authorBookTitlePanel.Controls.Add(authorBookAuthor);
            authorBookTitlePanel.Dock = DockStyle.Fill;
            authorBookTitlePanel.Location = new Point(91, 3);
            authorBookTitlePanel.Name = "authorBookTitlePanel";
            authorBookTitlePanel.Size = new Size(255, 82);
            authorBookTitlePanel.TabIndex = 1;
            // 
            // authorBookTitle
            // 
            authorBookTitle.AccessibleName = newBook.title;
            authorBookTitle.Click += AuthorBook_Click;
            authorBookTitle.AutoSize = true;
            authorBookTitle.BackColor = Color.Transparent;
            authorBookTitlePanel.SetFlowBreak(authorBookTitle, true);
            authorBookTitle.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            authorBookTitle.ForeColor = SystemColors.ControlLight;
            authorBookTitle.Location = new Point(3, 0);
            authorBookTitle.Name = "authorBookTitle";
            authorBookTitle.Size = new Size(50, 28);
            authorBookTitle.TabIndex = 1;
            authorBookTitle.Text = newBook.title;
            // 
            // authorBookAuthor
            // 
            authorBookAuthor.AccessibleName = newBook.title;
            authorBookAuthor.Click += AuthorBook_Click;
            authorBookAuthor.AutoSize = true;
            authorBookAuthor.BackColor = Color.Transparent;
            authorBookTitlePanel.SetFlowBreak(authorBookAuthor, true);
            authorBookAuthor.Font = new Font("Exo ExtraBold", 7.799999F, FontStyle.Bold, GraphicsUnit.Point);
            authorBookAuthor.ForeColor = SystemColors.ControlLight;
            authorBookAuthor.Location = new Point(3, 28);
            authorBookAuthor.Name = "authorBookAuthor";
            authorBookAuthor.Size = new Size(50, 19);
            authorBookAuthor.TabIndex = 2;
            authorBookAuthor.Text = newBook.author;

        }

        public void AuthorBook_Click(object sender, EventArgs e)
        {
            Control a = sender as Control;
            updateCurrentBook(bookPicking(a.AccessibleName));
        }

        #endregion

        #region update other category List
        public void AddOtherCategoryBook(Book newBook)
        {
            GradientPanel otherCategory = new GradientPanel();
            GradientPanel otherCategoryNamePanel = new GradientPanel();
            FlowLayoutPanel otherCategoryNameFlowPanel = new FlowLayoutPanel();
            System.Windows.Forms.Label otherCategoryName = new System.Windows.Forms.Label();

            SetDoubleBuffer(otherCategory, true);
            SetDoubleBuffer(otherCategoryNamePanel, true);
            SetDoubleBuffer(otherCategoryNameFlowPanel, true);
            SetDoubleBuffer(otherCategoryName, true);

            otherCategoriesPanel.Controls.Add(otherCategory);
            // 
            // otherCategoryLabel
            // 
            otherCategoriesPanel.SetFlowBreak(otherCategoryLabel, true);
            otherCategoryLabel.Font = new Font("Exo ExtraBold", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point);
            otherCategoryLabel.ForeColor = SystemColors.ControlLightLight;
            otherCategoryLabel.Location = new Point(3, 0);
            otherCategoryLabel.Name = "otherCategoryLabel";
            otherCategoryLabel.Size = new Size(735, 82);
            otherCategoryLabel.TabIndex = 0;
            otherCategoryLabel.Text = "Other categories";
            // 
            // otherCategory
            // 
            otherCategory.AccessibleName = newBook.publisher;
            otherCategory.AccessibleDescription = newBook.title;
            otherCategory.Click += OtherCategory_Click;
            otherCategory.Click += CategoryBook_Click;
            otherCategory.BackColor = Color.Transparent;
            //otherCategory.BackgroundImage = SetWidth(GetBookImage(newBook.index), 349);
            otherCategory.BackgroundImage = SetHeight(new BookCover(newBook).image, 349);
            otherCategory.BackgroundImageLayout = ImageLayout.Stretch;
            otherCategory.Controls.Add(otherCategoryNamePanel);
            otherCategory.GradientAngle = 60F;
            otherCategory.GradientPrimaryColor = Color.Transparent;
            otherCategory.GradientSecondaryColor = Color.Transparent;
            otherCategory.Location = new Point(3, 85);
            otherCategory.Name = "otherCategory";
            otherCategory.Size = new Size(349, 349);
            otherCategory.TabIndex = 4;
            // 
            // otherCategoryNamePanel
            // 
            otherCategoryNamePanel.BackColor = Color.Transparent;
            otherCategoryNamePanel.Controls.Add(otherCategoryNameFlowPanel);
            otherCategoryNamePanel.Dock = DockStyle.Bottom;
            otherCategoryNamePanel.GradientAngle = 90F;
            otherCategoryNamePanel.GradientPrimaryColor = Color.Transparent;
            otherCategoryNamePanel.GradientSecondaryColor = Color.Black;
            otherCategoryNamePanel.Location = new Point(0, 173);
            otherCategoryNamePanel.Name = "otherCategoryNamePanel";
            otherCategoryNamePanel.Size = new Size(349, 176);
            otherCategoryNamePanel.TabIndex = 5;
            // 
            // otherCategoryNameFlowPanel
            // 
            otherCategoryNameFlowPanel.AccessibleName = newBook.publisher;
            otherCategoryNameFlowPanel.AccessibleDescription = newBook.title;
            otherCategoryNameFlowPanel.Click += OtherCategory_Click;
            otherCategoryNameFlowPanel.Click += CategoryBook_Click;
            otherCategoryNameFlowPanel.Controls.Add(otherCategoryName);
            otherCategoryNameFlowPanel.Dock = DockStyle.Fill;
            otherCategoryNameFlowPanel.FlowDirection = FlowDirection.BottomUp;
            otherCategoryNameFlowPanel.Font = new Font("Exo ExtraBold", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            otherCategoryNameFlowPanel.Location = new Point(0, 0);
            otherCategoryNameFlowPanel.Name = "otherCategoryNameFlowPanel";
            otherCategoryNameFlowPanel.Size = new Size(349, 176);
            otherCategoryNameFlowPanel.TabIndex = 0;
            // 
            // otherCategoryName
            // 
            otherCategoryName.AccessibleName = newBook.publisher;
            otherCategoryName.AccessibleDescription = newBook.title;
            otherCategoryName.Click += OtherCategory_Click;
            otherCategoryName.Click += CategoryBook_Click;
            otherCategoryName.AutoSize = true;
            otherCategoryNameFlowPanel.SetFlowBreak(otherCategoryName, true);
            otherCategoryName.Font = new Font("Exo ExtraBold", 18F, FontStyle.Bold, GraphicsUnit.Point);
            otherCategoryName.ForeColor = SystemColors.ControlLightLight;
            otherCategoryName.Location = new Point(3, 134);
            otherCategoryName.Name = "otherCategoryName";
            otherCategoryName.Size = new Size(231, 42);
            otherCategoryName.TabIndex = 1;
            otherCategoryName.Text = newBook.publisher;
        }

        public void OtherCategory_Click(object sender, EventArgs e)
        {
            Control a = sender as Control;
            //updateCurrentBook(bookPicking(a.AccessibleName));
        }

        public void CategoryBook_Click(object sender, EventArgs e)
        {
            Control a = sender as Control;
            updateCurrentBook(bookPicking(a.AccessibleDescription));
        }
        #endregion

        #region update history list
        public void AddHistoryNewBook(Book newBook)
        {
            Panel historyNewBook = new Panel();
            GradientPanel historyNewBookGrad = new GradientPanel();
            System.Windows.Forms.Label historyNewBookAuthor = new System.Windows.Forms.Label();
            System.Windows.Forms.Label historyNewBookTitle = new System.Windows.Forms.Label();

            SetDoubleBuffer(historyNewBook, true);
            SetDoubleBuffer(historyNewBookGrad, true);
            SetDoubleBuffer(historyNewBookAuthor, true);
            SetDoubleBuffer(historyNewBookTitle, true);

            historyFlowPanel.Controls.Add(historyNewBook);
            // 
            // historyNewBook
            // 
            historyNewBook.Controls.Add(historyNewBookGrad);
            historyNewBook.AccessibleName = newBook.title;
            historyNewBook.Click += NewBook_Click;
            historyNewBook.Location = new Point(0, 82);
            historyNewBook.Margin = new Padding(8);
            historyNewBook.Name = "historyNewBook";
            historyNewBook.Size = new Size(199, 240);
            historyNewBook.BackgroundImage = SetHeight(new BookCover(newBook).image, 240);
            historyNewBook.BackgroundImageLayout = ImageLayout.Stretch;
            historyNewBook.TabIndex = 6;
            // 
            // historyNewBookGrad
            // 
            historyNewBookGrad.BackColor = Color.Transparent;
            historyNewBookGrad.AccessibleName = newBook.title;
            historyNewBookGrad.Click += NewBook_Click;
            historyNewBookGrad.Controls.Add(historyNewBookAuthor);
            historyNewBookGrad.Controls.Add(historyNewBookTitle);
            historyNewBookGrad.Dock = DockStyle.Bottom;
            historyNewBookGrad.GradientAngle = 90F;
            historyNewBookGrad.GradientPrimaryColor = Color.Transparent;
            historyNewBookGrad.GradientSecondaryColor = Color.Black;
            historyNewBookGrad.Location = new Point(0, 119);
            historyNewBookGrad.Margin = new Padding(0);
            historyNewBookGrad.Name = "historyNewBookGrad";
            historyNewBookGrad.Size = new Size(199, 200);
            historyNewBookGrad.TabIndex = 4;
            // 
            // historyNewBookAuthor
            // 
            historyNewBookAuthor.AutoSize = true;
            historyNewBookAuthor.AccessibleName = newBook.title;
            historyNewBookAuthor.Click += NewBook_Click;
            historyNewBookAuthor.BackColor = Color.Transparent;
            historyNewBookAuthor.Dock = DockStyle.Bottom;
            historyNewBookAuthor.Font = new Font("Exo ExtraBold", 7.799999F, FontStyle.Bold, GraphicsUnit.Point);
            historyNewBookAuthor.ForeColor = SystemColors.ControlLight;
            historyNewBookAuthor.Location = new Point(0, 180);
            historyNewBookAuthor.Margin = new Padding(0);
            historyNewBookAuthor.Name = "historyNewBookAuthor";
            historyNewBookAuthor.Size = new Size(50, 19);
            historyNewBookAuthor.TabIndex = 3;
            historyNewBookAuthor.Text = newBook.author;
            // 
            // historyNewBookTitle
            // 
            historyNewBookTitle.AutoSize = true;
            historyNewBookTitle.AutoEllipsis = true;
            historyNewBookTitle.BackColor = Color.Transparent;
            historyNewBookTitle.AccessibleName = newBook.title;
            historyNewBookTitle.Click += NewBook_Click;
            historyNewBookTitle.Font = new Font("Exo ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            historyNewBookTitle.ForeColor = SystemColors.ControlLight;
            historyNewBookTitle.Location = new Point(0, 152);
            historyNewBookTitle.Margin = new Padding(0);
            historyNewBookTitle.Name = "historyNewBookTitle";
            historyNewBookTitle.Size = new Size(50, 28);
            historyNewBookTitle.TabIndex = 2;
            historyNewBookTitle.Text = newBook.title;
        }
        #endregion

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
            foreach (Book b in books)
            {
                if (b.title.Equals(EscapeSingleQuotes(name))) return b;
            }
            return book;
        }

        private void updateCurrentBook(Book book)
        {
            if (book == null || book.index < 1||!books.Contains(book)) { return; }

            //remove the recent book leftover
            ClearList(mainCategoryPanel, "newCategoryBook");
            ClearList(authormainFlowPanel, "authorBook");
            //get book cover image
            BookCover bookCover = new BookCover(book, true);
            Image currentImg = bookCover.image;
            //get related books
            List<Book> categoryBooks = books.Where(item => item.publisher == book.publisher).ToList();
            List<Book> authorBooks = books.Where(item => item.author == book.author).ToList();

            //update the vertical content region
            contentImg.Image = SetHeight(currentImg, contentImg.Height);
            contentTitle.Text = book.title;
            authorLabel.Text = book.author;
            publisherLabel.Text = book.publisher;
            contentYear.Text = book.year.ToString();
            //update the horizontal bottom bar
            currentLabel.Image = SetHeight(currentImg, currentLabel.Height);
            currentBookTitle.Text = book.title;
            currentBookAuthor.Text = book.author;
            currentPublisher.Text = book.publisher;
            yearOfPublication.Text = book.year.ToString();
            int score = 0;
            int count = 0;
            score = library.CalculateScore(book).avgScore;
            count = library.CalculateScore(book).totalRate;
            currentBookRate.Text = score.ToString()+"("+count+")";
            if(score > 9)
            {
                currentBookRate.Image = Image.FromFile("../../../../../assets/icons/E_heart100.png");
            }
            else if (score > 8)
            {
                currentBookRate.Image = Image.FromFile("../../../../../assets/icons/E_heart80.png");
            }
            else if (score > 5)
            {
                currentBookRate.Image = Image.FromFile("../../../../../assets/icons/E_heart50.png");
            }
            else if (score > 3)
            {
                currentBookRate.Image = Image.FromFile("../../../../../assets/icons/E_heart30.png");
            }
            else if (score > 0)
            {
                currentBookRate.Image = Image.FromFile("../../../../../assets/icons/E_heart.png");
            }
            if (categoryBooks.Count<1)
            {
                categoryFlowPanel0.Visible = false;
            }
            else
            {
                Book book1 = categoryBooks.ElementAt(0);

                if (book.Equals(book1) && categoryBooks.Count > 1) book1 = categoryBooks.ElementAt(1);
                if (categoryBooks.Count > 1)
                {
                    int offset = 10;
                    for (int i = 0; i < categoryBooks.Count; i++)
                    {
                        if (offset == 0) break;
                        AddCategryBook(categoryBooks.ElementAt(i), book.publisher);
                        offset--;
                    }
                }
                if (authorBooks.Count > 1)
                {
                    int offset = 10;
                    for (int i = 0; i < authorBooks.Count; i++)
                    {
                        if (offset == 0) break;
                        AddAuthorBook(authorBooks.ElementAt(i));
                        offset--;
                    }
                }

                categoryImg0.Image = SetHeight(new BookCover(book1).image, categoryImg0.Height);
                categoryTitle0.Text = book1.title;
                categoryAuthor0.Text = book1.author;
            }


            Color borderColor = bookCover.borderColor;

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
            //content resize
            contentContainer.Height = mainFlowPanel.Height + difH + 15;
            //homeFlowPanel resize
            homeFlowPanel.Height = mainFlowPanel.Height + difH + 10;
            homeFlowPanel.Width = mainFlowPanel.Width + difW + 12;

            helloPanel.Width = homeFlowPanel.Width;
            helloElement0.Width = (homeFlowPanel.Width) / 2 - 12;
            helloElement1.Width = (homeFlowPanel.Width) / 2 - 12;
            helloElement2.Width = (homeFlowPanel.Width) / 2 - 12;
            helloElement3.Width = (homeFlowPanel.Width) / 2 - 12;

            recommentPanel.Width = homeFlowPanel.Width;
            recommentElement0.Width = (homeFlowPanel.Width) / 2 - 12;
            recommentElement1.Width = (homeFlowPanel.Width) / 2 - 12;
            recommentElement2.Width = (homeFlowPanel.Width) / 2 - 12;
            recommentElement3.Width = (homeFlowPanel.Width) / 2 - 12;

            //searchFlowPanel resize
            searchFlowPanel.Height = mainFlowPanel.Height + difH + 10;
            searchFlowPanel.Width = mainFlowPanel.Width + difW + 12;

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
            bestBookFlowPanel.Height = mainFlowPanel.Height + difH + 10;
            bestBookFlowPanel.Width = mainFlowPanel.Width + difW + 12;

            bestBookPanel.Width = mainFlowPanel.Width + difW;
            bestBookElement0.Width = (mainFlowPanel.Width + difW) / 2 - 12;
            bestBookElement1.Width = (mainFlowPanel.Width + difW) / 2 - 12;
            bestBookElement2.Width = (mainFlowPanel.Width + difW) / 2 - 12;
            bestBookElement3.Width = (mainFlowPanel.Width + difW) / 2 - 12;
            //favorite resize
            favoritePanel.Width = mainFlowPanel.Width + difW + 12;
            favoritePanel.Height = mainFlowPanel.Height + difW + 12;
            //category resize
            categoriesPanel.Width = mainFlowPanel.Width + difW + 12;
            categoriesPanel.Height = mainFlowPanel.Height + difW + 12;
            ResizeList(mainCategoryPanel, "newCategoryBook");
            ResizeList(authormainFlowPanel, "authorBook");
            //history resize 
            historyPanel.Width = mainFlowPanel.Width + difW + 12;
            historyPanel.Height = mainFlowPanel.Height + difW + 12;
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
        private List<Book> SearchBookInformation(string searchKey)
        {
            List<Book> matchedBooks = new List<Book>();

            Book isbnMatched = books.Find(item => item.isbn == searchKey);
            if (isbnMatched != null)
            {
                matchedBooks.Add(isbnMatched);
            }
            else
            {
                int offset = 10;
                foreach(Book item in books)
                {
                    if (offset == 0) break;
                    if(item.title.Contains(searchKey)) matchedBooks.Add(item);
                    offset--;
                }
            }

            return matchedBooks;
        }

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

                List<Book> matchedBooks = SearchBookInformation(searchKey);
                if (matchedBooks.Count == 0) bestMatchLabel.Text = "Not found!";
                if (matchedBooks.Count >= 1)
                {
                    topSearchImg.Image = SetHeight(new BookCover(matchedBooks.ElementAt(0)).image, topSearchImg.Height);
                    topSearchTitle.Text = matchedBooks.ElementAt(0).title;
                    topSearchAuthor.Text = matchedBooks.ElementAt(0).author;
                    topSearchPanel.Visible = true;
                }
                if (matchedBooks.Count >= 2)
                {
                    otherImg0.Image = SetHeight(new BookCover(matchedBooks.ElementAt(1)).image, otherImg0.Height);
                    otherTitle0.Text = matchedBooks.ElementAt(1).title;
                    toolTip1.SetToolTip(otherTitle0, "by " + matchedBooks.ElementAt(1).author);
                    otherResult0.Visible = true;
                }
                if (matchedBooks.Count >= 3)
                {
                    otherImg1.Image = SetHeight(new BookCover(matchedBooks.ElementAt(2)).image, otherImg1.Height);
                    otherTitle1.Text = matchedBooks.ElementAt(2).title;
                    toolTip1.SetToolTip(otherTitle1, "by " + matchedBooks.ElementAt(2).author);
                    otherResult1.Visible = true;
                }
                if (matchedBooks.Count >= 4)
                {
                    otherImg2.Image = SetHeight(new BookCover(matchedBooks.ElementAt(3)).image, otherImg2.Height);
                    otherTitle2.Text = matchedBooks.ElementAt(3).title;
                    toolTip1.SetToolTip(otherTitle2, "by " + matchedBooks.ElementAt(3).author);
                    otherResult2.Visible = true;
                }
                if (matchedBooks.Count >= 5)
                {
                    otherImg3.Image = SetHeight(new BookCover(matchedBooks.ElementAt(4)).image, otherImg3.Height);
                    otherTitle3.Text = matchedBooks.ElementAt(4).title;
                    toolTip1.SetToolTip(otherTitle3, "by " + matchedBooks.ElementAt(4).author);
                    otherResult3.Visible = true;
                }
                if (matchedBooks.Count >= 6)
                {
                    otherImg4.Image = SetHeight(new BookCover(matchedBooks.ElementAt(5)).image, otherImg4.Height);
                    otherTitle4.Text = matchedBooks.ElementAt(5).title;
                    toolTip1.SetToolTip(otherTitle4, "by " + matchedBooks.ElementAt(5).author);
                    otherResult4.Visible = true;
                }
                if (matchedBooks.Count >= 7)
                {
                    otherImg5.Image = SetHeight(new BookCover(matchedBooks.ElementAt(6)).image, otherImg5.Height);
                    otherTitle5.Text = matchedBooks.ElementAt(6).title;
                    toolTip1.SetToolTip(otherTitle5, "by " + matchedBooks.ElementAt(6).author);
                    otherResult5.Visible = true;
                }
                if (matchedBooks.Count >= 8)
                {
                    otherImg6.Image = SetHeight(new BookCover(matchedBooks.ElementAt(7)).image, otherImg6.Height);
                    otherTitle6.Text = matchedBooks.ElementAt(7).title;
                    toolTip1.SetToolTip(otherTitle6, "by " + matchedBooks.ElementAt(7).author);
                    otherResult6.Visible = true;
                }
                if (matchedBooks.Count >= 9)
                {
                    otherImg7.Image = SetHeight(new BookCover(matchedBooks.ElementAt(8)).image, otherImg7.Height);
                    otherTitle7.Text = matchedBooks.ElementAt(8).title;
                    toolTip1.SetToolTip(otherTitle7, "by " + matchedBooks.ElementAt(8).author);
                    otherResult7.Visible = true;
                }
                if (matchedBooks.Count >= 10)
                {
                    otherImg8.Image = SetHeight(new BookCover(matchedBooks.ElementAt(9)).image, otherImg8.Height);
                    otherTitle8.Text = matchedBooks.ElementAt(9).title;
                    toolTip1.SetToolTip(otherTitle8, "by " + matchedBooks.ElementAt(9).author);
                    otherResult8.Visible = true;
                }
                if (matchedBooks.Count >= 11)
                {
                    otherImg9.Image = SetHeight(new BookCover(matchedBooks.ElementAt(10)).image, otherImg9.Height);
                    otherTitle9.Text = matchedBooks.ElementAt(10).title;
                    toolTip1.SetToolTip(otherTitle9, "by " + matchedBooks.ElementAt(10).author);
                    otherResult9.Visible = true;
                }
                bestMatchPanel.Visible = true;
            }
        }
        #endregion

        //MainForm only work went user login successfully

        public MainForm(Library library, List<string> recommendations)
        {
            this.library = library;
            this.reader = library.reader;
            this.books = library.bookSelves;
            this.ratings = library.bookRatings;
            this.recommendations = recommendations;

            this.FormBorderStyle = FormBorderStyle.None;
            InitializeComponent();
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }

        //
        // MainForm on load event handler
        //
        private async void MainForm_Load(object sender, EventArgs e)
        {
            #region resize 
            difH = homeFlowPanel.Height - mainFlowPanel.Height;
            difW = homeFlowPanel.Width - mainFlowPanel.Width;
            //content resize
            contentContainer.Height = mainFlowPanel.Height + difH + 15;
            //homeFlowPanel resize
            homeFlowPanel.Height = mainFlowPanel.Height + difH + 10;
            homeFlowPanel.Width = mainFlowPanel.Width + difW + 12;

            helloPanel.Width = homeFlowPanel.Width;
            helloElement0.Width = (homeFlowPanel.Width) / 2 - 12;
            helloElement1.Width = (homeFlowPanel.Width) / 2 - 12;
            helloElement2.Width = (homeFlowPanel.Width) / 2 - 12;
            helloElement3.Width = (homeFlowPanel.Width) / 2 - 12;

            recommentPanel.Width = homeFlowPanel.Width;
            recommentElement0.Width = (homeFlowPanel.Width) / 2 - 12;
            recommentElement1.Width = (homeFlowPanel.Width) / 2 - 12;
            recommentElement2.Width = (homeFlowPanel.Width) / 2 - 12;
            recommentElement3.Width = (homeFlowPanel.Width) / 2 - 12;

            //searchFlowPanel resize
            searchFlowPanel.Height = mainFlowPanel.Height + difH + 10;
            searchFlowPanel.Width = mainFlowPanel.Width + difW + 12;

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
            bestBookFlowPanel.Height = mainFlowPanel.Height + difH + 10;
            bestBookFlowPanel.Width = mainFlowPanel.Width + difW + 12;

            bestBookPanel.Width = mainFlowPanel.Width + difW;
            bestBookElement0.Width = (mainFlowPanel.Width + difW) / 2 - 12;
            bestBookElement1.Width = (mainFlowPanel.Width + difW) / 2 - 12;
            bestBookElement2.Width = (mainFlowPanel.Width + difW) / 2 - 12;
            bestBookElement3.Width = (mainFlowPanel.Width + difW) / 2 - 12;
            //favorite resize
            favoritePanel.Width = mainFlowPanel.Width + difW + 12;
            favoritePanel.Height = mainFlowPanel.Height + difW + 12;
            //category resize
            categoriesPanel.Width = mainFlowPanel.Width + difW + 12;
            categoriesPanel.Height = mainFlowPanel.Height + difW + 12;
            ResizeList(mainCategoryPanel, "newCategoryBook");
            ResizeList(authormainFlowPanel, "authorBook");
            //history resize 
            historyPanel.Width = mainFlowPanel.Width + difW + 12;
            historyPanel.Height = mainFlowPanel.Height + difW + 12;
            #endregion
            // get history list
            List<UserRating> userHistory = new List<UserRating>();
            foreach (UserRating rating in this.ratings)
            {
                if(rating.userId == reader.userId) userHistory.Add(rating);
            }

            List<UserRating> userFavorite = new List<UserRating>();
            foreach (UserRating rating in userHistory)
            {
                if (rating.rate > 0) userFavorite.Add(rating);
            }

            #region Set controls double buffered 

            SetDoubleBuffer(containerMainTableLayout, true);
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
            SetDoubleBuffer(categoryTable0, true);
            SetDoubleBuffer(categoryImg0, true);
            SetDoubleBuffer(categoryFlowPanel0, true);
            SetDoubleBuffer(categoryTitle0, true);
            SetDoubleBuffer(categoryAuthor0, true);
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
            SetDoubleBuffer(otherResult0, true);
            SetDoubleBuffer(otherTable0, true);
            SetDoubleBuffer(otherTitle0, true);
            SetDoubleBuffer(otherImg0, true);
            SetDoubleBuffer(otherResult1, true);
            SetDoubleBuffer(otherTable1, true);
            SetDoubleBuffer(otherTitle1, true);
            SetDoubleBuffer(otherImg1, true);
            SetDoubleBuffer(otherResult2, true);
            SetDoubleBuffer(otherTable2, true);
            SetDoubleBuffer(otherTitle2, true);
            SetDoubleBuffer(otherImg2, true);
            SetDoubleBuffer(otherResult3, true);
            SetDoubleBuffer(otherTable3, true);
            SetDoubleBuffer(otherTitle3, true);
            SetDoubleBuffer(otherImg3, true);
            SetDoubleBuffer(otherResult4, true);
            SetDoubleBuffer(otherTable4, true);
            SetDoubleBuffer(otherTitle4, true);
            SetDoubleBuffer(otherImg4, true);
            SetDoubleBuffer(otherResult5, true);
            SetDoubleBuffer(otherTable5, true);
            SetDoubleBuffer(otherTitle5, true);
            SetDoubleBuffer(otherImg5, true);
            SetDoubleBuffer(otherResult6, true);
            SetDoubleBuffer(otherTable6, true);
            SetDoubleBuffer(otherTitle6, true);
            SetDoubleBuffer(otherImg6, true);
            SetDoubleBuffer(otherResult7, true);
            SetDoubleBuffer(otherTable7, true);
            SetDoubleBuffer(otherTitle7, true);
            SetDoubleBuffer(otherImg7, true);
            SetDoubleBuffer(otherResult8, true);
            SetDoubleBuffer(otherTable8, true);
            SetDoubleBuffer(otherTitle8, true);
            SetDoubleBuffer(otherImg8, true);
            SetDoubleBuffer(otherResult9, true);
            SetDoubleBuffer(otherTable9, true);
            SetDoubleBuffer(otherTitle9, true);
            SetDoubleBuffer(otherImg9, true);
            SetDoubleBuffer(flowLayoutPanel61, true);
            SetDoubleBuffer(favoritePanel, true);
            SetDoubleBuffer(favFlowPanel, true);
            SetDoubleBuffer(favoriteLabel, true);
            SetDoubleBuffer(favTableHead, true);
            SetDoubleBuffer(favBookLabel, true);
            SetDoubleBuffer(favRankLabel, true);
            SetDoubleBuffer(scoreLabel, true);
            SetDoubleBuffer(favPublisherLabel, true);
            SetDoubleBuffer(categoriesPanel, true);
            SetDoubleBuffer(mainCategoryPanel, true);
            SetDoubleBuffer(categoryMainLabel, true);
            SetDoubleBuffer(authormainFlowPanel, true);
            SetDoubleBuffer(authorMainLabel, true);
            SetDoubleBuffer(otherCategoriesPanel, true);
            SetDoubleBuffer(otherCategoryLabel, true);
            SetDoubleBuffer(historyPanel, true);
            SetDoubleBuffer(historyFlowPanel, true);
            SetDoubleBuffer(historyLabel, true);
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

            #endregion

            #region test application graphic by getting random index of books
            Random rand = new Random();
            int randC = rand.Next(1, 10);
            
            Book book = books.Find(item => item.index==randC);
            Image currentImg = new BookCover(book).image;

            updateCurrentBook(book);

            if (recommendations.Count < 10 )
            {
                //helloPanel
                int randH0 = rand.Next(1, 100000);
                int randH1 = rand.Next(1, 100000);
                int randH2 = rand.Next(1, 100000);
                int randH3 = rand.Next(1, 100000);
                Book helloBook0 = books.ElementAt(randH0);
                Book helloBook1 = books.ElementAt(randH1);
                Book helloBook2 = books.ElementAt(randH2);
                Book helloBook3 = books.ElementAt(randH3);
                helloElementImg0.Image = SetHeight(new BookCover(helloBook0).image, helloElementImg0.Height);
                helloElementImg1.Image = SetHeight(new BookCover(helloBook1).image, helloElementImg1.Height);
                helloElementImg2.Image = SetHeight(new BookCover(helloBook2).image, helloElementImg2.Height);
                helloElementImg3.Image = SetHeight(new BookCover(helloBook3).image, helloElementImg3.Height);

                helloElementTitle0.Text = helloBook0.title;
                helloAuthor0.Text = helloBook0.author;
                helloElementTitle1.Text = helloBook1.title;
                helloAuthor1.Text = helloBook1.author;
                helloElementTitle2.Text = helloBook2.title;
                helloAuthor2.Text = helloBook2.author;
                helloElementTitle3.Text = helloBook3.title;
                helloAuthor3.Text = helloBook3.author;

                //recommentPanel 
                int randC0 = rand.Next(1, 100000);
                int randC1 = rand.Next(1, 100000);
                int randC2 = rand.Next(1, 100000);
                int randC3 = rand.Next(1, 100000);

                Book recommentBook0 = books.ElementAt(randC0);
                Book recommentBook1 = books.ElementAt(randC1);
                Book recommentBook2 = books.ElementAt(randC2);
                Book recommentBook3 = books.ElementAt(randC3);

                recommentImg0.Image = SetHeight(new BookCover(recommentBook0).image, recommentImg0.Height);
                recommentImg1.Image = SetHeight(new BookCover(recommentBook1).image, recommentImg1.Height);
                recommentImg2.Image = SetHeight(new BookCover(recommentBook2).image, recommentImg2.Height);
                recommentImg3.Image = SetHeight(new BookCover(recommentBook3).image, recommentImg3.Height);



                recommentTitle0.Text = recommentBook0.title;
                recommentAuthor0.Text = recommentBook0.author;
                recommentTitle1.Text = recommentBook1.title;
                recommentAuthor1.Text = recommentBook1.author;
                recommentTitle2.Text = recommentBook2.title;
                recommentAuthor2.Text = recommentBook2.author;
                recommentTitle3.Text = recommentBook3.title;
                recommentAuthor3.Text = recommentBook3.author;

                //bestBook Panel
                int randB0 = rand.Next(1, 100000);
                int randB1 = rand.Next(1, 100000);
                int randB2 = rand.Next(1, 100000);
                int randB3 = rand.Next(1, 100000);

                Book bestBook0 = books.ElementAt(randB0);
                Book bestBook1 = books.ElementAt(randB1);
                Book bestBook2 = books.ElementAt(randB2);
                Book bestBook3 = books.ElementAt(randB3);

                bestBookImg0.Image = SetHeight(new BookCover(bestBook0).image, bestBookImg0.Height);
                bestBookImg1.Image = SetHeight(new BookCover(bestBook1).image, bestBookImg1.Height);
                bestBookImg2.Image = SetHeight(new BookCover(bestBook2).image, bestBookImg2.Height);
                bestBookImg3.Image = SetHeight(new BookCover(bestBook3).image, bestBookImg3.Height);


                bestBookTitle0.Text = bestBook0.title;
                bestBookAuthor0.Text = bestBook0.author;
                bestBookTitle1.Text = bestBook1.title;
                bestBookAuthor1.Text = bestBook1.author;
                bestBookTitle2.Text = bestBook2.title;
                bestBookAuthor2.Text = bestBook2.author;
                bestBookTitle3.Text = bestBook3.title;
                bestBookAuthor3.Text = bestBook3.author;
            }
            else
            {
                //helloPanel
                Book helloBook0 = books.Find(item => item.isbn == recommendations[0]);
                Book helloBook1 = books.Find(item => item.isbn == recommendations[1]);
                Book helloBook2 = books.Find(item => item.isbn == recommendations[2]);
                Book helloBook3 = books.Find(item => item.isbn == recommendations[3]);
                helloElementImg0.Image = SetHeight(new BookCover(helloBook0).image, helloElementImg0.Height);
                helloElementImg1.Image = SetHeight(new BookCover(helloBook1).image, helloElementImg1.Height);
                helloElementImg2.Image = SetHeight(new BookCover(helloBook2).image, helloElementImg2.Height);
                helloElementImg3.Image = SetHeight(new BookCover(helloBook3).image, helloElementImg3.Height);

                helloElementTitle0.Text = helloBook0.title;
                helloAuthor0.Text = helloBook0.author;
                helloElementTitle1.Text = helloBook1.title;
                helloAuthor1.Text = helloBook1.author;
                helloElementTitle2.Text = helloBook2.title;
                helloAuthor2.Text = helloBook2.author;
                helloElementTitle3.Text = helloBook3.title;
                helloAuthor3.Text = helloBook3.author;

                //recommentPanel 

                Book recommentBook0 = books.Find(item => item.isbn == recommendations[4]);
                Book recommentBook1 = books.Find(item => item.isbn == recommendations[5]);
                Book recommentBook2 = books.Find(item => item.isbn == recommendations[6]);
                Book recommentBook3 = books.Find(item => item.isbn == recommendations[7]);

                recommentImg0.Image = SetHeight(new BookCover(recommentBook0).image, recommentImg0.Height);
                recommentImg1.Image = SetHeight(new BookCover(recommentBook1).image, recommentImg1.Height);
                recommentImg2.Image = SetHeight(new BookCover(recommentBook2).image, recommentImg2.Height);
                recommentImg3.Image = SetHeight(new BookCover(recommentBook3).image, recommentImg3.Height);



                recommentTitle0.Text = recommentBook0.title;
                recommentAuthor0.Text = recommentBook0.author;
                recommentTitle1.Text = recommentBook1.title;
                recommentAuthor1.Text = recommentBook1.author;
                recommentTitle2.Text = recommentBook2.title;
                recommentAuthor2.Text = recommentBook2.author;
                recommentTitle3.Text = recommentBook3.title;
                recommentAuthor3.Text = recommentBook3.author;

                //bestBook Panel

                Book bestBook0 = books.Find(item => item.isbn == recommendations[0]);
                Book bestBook1 = books.Find(item => item.isbn == recommendations[1]);
                Book bestBook2 = books.Find(item => item.isbn == recommendations[8]);
                Book bestBook3 = books.Find(item => item.isbn == recommendations[9]);

                bestBookImg0.Image = SetHeight(new BookCover(bestBook0).image, bestBookImg0.Height);
                bestBookImg1.Image = SetHeight(new BookCover(bestBook1).image, bestBookImg1.Height);
                bestBookImg2.Image = SetHeight(new BookCover(bestBook2).image, bestBookImg2.Height);
                bestBookImg3.Image = SetHeight(new BookCover(bestBook3).image, bestBookImg3.Height);


                bestBookTitle0.Text = bestBook0.title;
                bestBookAuthor0.Text = bestBook0.author;
                bestBookTitle1.Text = bestBook1.title;
                bestBookAuthor1.Text = bestBook1.author;
                bestBookTitle2.Text = bestBook2.title;
                bestBookAuthor2.Text = bestBook2.author;
                bestBookTitle3.Text = bestBook3.title;
                bestBookAuthor3.Text = bestBook3.author;
            }

            
            #endregion

            #region update category list
            List<string> publisherList = new List<string>();
            for (int i = 0; i < userHistory.Count; i++)
            {
                Book catBook = books.Find(item => item.isbn == userHistory.ElementAt(i).isbn);
                if (catBook!=null && catBook.title != null)
                {
                    if (!publisherList.Contains(catBook.publisher))
                    {
                        publisherList.Add(catBook.publisher);
                        AddOtherCategoryBook(catBook);
                    }

                }
            }
            #endregion

            #region update favorite list
            userFavorite.Sort();
            int bRank = 1;
            for (int i = 0; i < userFavorite.Count; i++)
            {
                if (userFavorite.ElementAt(i).rate != 0)
                {
                    Book favBook = books.Find(item => item.isbn == userFavorite.ElementAt(i).isbn);
                    if (favBook!=null && favBook.title != null)
                    {
                        AddFavBook(favBook, bRank++, userFavorite.ElementAt(i).rate);
                    }
                }

            }

            #endregion

            #region update history list
            
            for (int i = 0; i < userHistory.Count; i++)
            {
                Book histBook = new Book();
                histBook = books.Find(item => item.isbn == userHistory.ElementAt(i).isbn);
                if (histBook!= null && histBook.index >0 && histBook.title != null)
                {
                    AddHistoryNewBook(histBook);
                    //updateCurrentBook(histBook);
                }
            }
            for (int i = userHistory.Count; i > 0 ; i--)
            {
                Book histBook = new Book();
                histBook = books.Find(item => item.isbn == userHistory.ElementAt(i-1).isbn);
                if (histBook != null && histBook.index > 0 && histBook.title != null)
                {                    
                    updateCurrentBook(histBook);
                    break;
                }
            }
            #endregion

            //update userlabel
            toolTip1.SetToolTip(user, reader.username + " #" + reader.userId);
            
            user.Image = SetWidth(Image.FromFile("../../../../../assets/LImgs/" + books.ElementAt(0).isbn + ".jpg"/*Image.FromStream(LoaderFromURL(reader.profileImage) == null ? LoaderFromURL(bookList.ElementAt(0).lURL) : LoaderFromURL(reader.profileImage)*/), user.Width);

            homeFlowPanel.Controls.Add(bestBookFlowPanel);
            bestBookFlowPanel.Visible = true;
        }

        //unneccessary!
        private void contentContainer_Paint(object sender, PaintEventArgs e)
        {
            LinearGradientBrush lgb = new LinearGradientBrush(contentContainer.ClientRectangle, ColorTranslator.FromHtml("#300004"), contentContainer.BackColor, 90F);
            Graphics g = e.Graphics;
            g.FillRectangle(lgb, contentContainer.ClientRectangle);
        }

        private void user_Click(object sender, EventArgs e)
        {
            using (UserForm userForm = new UserForm(reader.userId, reader.fname, reader.lname, reader.username,
                reader.password, reader.email, reader.phone, reader.gender, reader.date, reader.profileImage, reader.age,
                reader.location, reader.nation))
            {
                userForm.ShowDialog();
            }
        }
    }
}
