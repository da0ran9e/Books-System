﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Net;
using System.Security.Policy;
using System.Reflection;
using System.Net.Http;

namespace WinForms
{
    public partial class RegistForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\vuduc\OneDrive\Documents\BX.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;

        public RegistForm()
        {
            InitializeComponent();
        }

        #region image handler for banners
        private int adIndexAutoGen()
        {
            int range = 1000;
            Random rand = new Random();
            int randIndex = rand.Next(1, range);
            return randIndex;
        }


        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }
        public static Image setHeight(Image imgToResize, int height)
        {
            int w = imgToResize.Width;
            int h = imgToResize.Height;
            int width = (height * w / h);
            Size size = new Size(width, height);
            return (Image)(new Bitmap(imgToResize, size));
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
                        Image img = Image.FromFile(imgPath);
                        if (adLabel.Visible)
                        {
                            adLabel.Text = url;
                            img = setHeight(img, adLabel.Height);
                            adLabel.Image = img;
                        }
                        else
                        {
                            smallAdLabel.Text = url;
                            img = setHeight(img, smallAdLabel.Height);
                            smallAdLabel.Image = img;
                        }
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
        #endregion

        #region control buttons handler
        private void Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private async void maximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                maximize.Image = Image.FromFile("../../../../../assets/icons/minimize.png");
                this.WindowState = FormWindowState.Maximized;
                panel1.Location = new Point(763, 331);

                adLabel.Visible = true;

            }
            else
            {
                maximize.Image = Image.FromFile("../../../../../assets/icons/maximize.png");
                this.WindowState = FormWindowState.Normal;
                panel1.Location = new Point(63, 331);
            }

        }

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        private void topBar_MouseDown(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.SizeAll;
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }
        private void registForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void registForm_MouseUp(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Default;
            dragging = false;
        }

        #endregion

        #region handle events when user's data entried
        private void flowLayoutPanel2_Onclick(object sender, EventArgs e)
        {
            username.Enabled = true;
        }

        private string usernameV;
        private string passwordV;
        private string emailV = null;
        private int phoneV = 0;
        private string fnameV = null;
        private string lnameV = null;
        private string imageUrlV = null;
        private int genderV = 0;
        private string locationV = null;
        private string nationV = null;
        private string birthDateV = null;

        private void label1_Click(object sender, EventArgs e)
        {
            Point stepLoc = step.Location;
            if (stepLoc.X == 256)
            {
                fnameV = firstName.Text;
                lnameV = lastName.Text;
                emailV = email.Text;
                if (phone.Text.Length > 0)
                {
                    phoneV = Int32.Parse(phone.Text);
                }
                locationV = location.Text;
                nationV = nation.Text;
                birthDateV = birthDate.Value.ToString("yyyy-MM-dd");
                locationV = location.Text;
                nationV = nation.Text;
                imageUrlV = imgUrl.Text;
                if (gender.Text == "Male") genderV = 1;
                else if (gender.Text == "Female") genderV = 2;
                else if (gender.Text == "Other") genderV = 3;
            }
            else if (stepLoc.X == 372)
            {
                foreach (Label a in confirmNotification.Controls)
                {
                    confirmNotification.Controls.Remove(a);
                }
                Label notification = new Label();
                if (password.Text == null || password.Text.Length <= 0)
                {
                    notification.Text = "Password cannot be empty!";
                    notification.ForeColor = Color.Red;
                    passwordPanel.BackColor = Color.LavenderBlush;
                }
                else if (password.Text.Length <= 6)
                {
                    notification.Text = "Your password must have at least 6 characters!";
                    notification.ForeColor = Color.Red;
                    passwordPanel.BackColor = Color.LavenderBlush;
                }
                else if (password.Text.Contains(" "))
                {
                    notification.Text = "Your password cannot contains space!";
                    notification.ForeColor = Color.Red;
                    passwordPanel.BackColor = Color.LavenderBlush;
                }
                else if (password.Text != confirm.Text)
                {
                    notification.Text = "Passwords do not match!";
                    notification.ForeColor = Color.Red;
                    confirmPanel.BackColor = Color.LavenderBlush;
                }
                else if (password.Text == confirm.Text)
                {
                    passwordV = password.Text;
                    notification.Text = "Password saved!";
                    notification.ForeColor = Color.Green;
                    passwordPanel.BackColor = Color.MintCream;
                    confirmPanel.BackColor = Color.MintCream;
                }
                notification.Size = new Size(600, 32);
                confirmNotification.Controls.Add(notification);
                if (notification.ForeColor == Color.Red)
                    return;
            }

            usernamePanel.Visible = true;
            firstNamePanel.Visible = false;
            lastnamePanel.Visible = false;
            emailPanel.Visible = false;
            phonePanel.Visible = false;
            nationPanel.Visible = false;
            birthDatePanel.Visible = false;
            genderPanel.Visible = false;
            locationPanel.Visible = false;
            imageUrlPanel.Visible = false;
            passwordPanel.Visible = false;
            confirmPanel.Visible = false;

            stepLoc.X = 123;
            step.Text = "Next";
            step.Location = new Point(stepLoc.X, stepLoc.Y);
            label2.Visible = true;
        }

        private void finish_Click(object sender, EventArgs e)
        {
            Point stepLoc = step.Location;
            if (stepLoc.X == 123)
            {
                usernameV = username.Text;
                // check username exsistance 
                foreach (Label a in usernameNotification.Controls)
                {
                    usernameNotification.Controls.Remove(a);
                }
                Label notification = new Label();
                if (username.Text == null || username.Text.Length <= 0)
                {
                    notification.Text = "Please enter a username to sign in!";
                    notification.ForeColor = Color.Red;
                }
                else if (usernameV.Length < 5)
                {
                    notification.Text = "Username must have at least 5 characters!";
                    notification.ForeColor = Color.Red;
                }
                else if (usernameV.Contains(" "))
                {
                    notification.Text = "Your username cannot contains space!";
                    notification.ForeColor = Color.Red;
                }
                else
                {
                    try
                    {
                        cmd = new SqlCommand("select * from users where username=@username", con);
                        cmd.Parameters.AddWithValue("@username", usernameV);
                        con.Open();
                        dr = cmd.ExecuteReader();
                        dr.Read();
                        if (dr.HasRows)
                        {
                            notification.Text = "Username had been taken!";
                            notification.ForeColor = Color.Red;
                        }
                        else
                        {
                            notification.Text = "Username save!";
                            notification.ForeColor = Color.Green;
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
                notification.Size = new Size(600, 32);
                usernameNotification.Controls.Add(notification);
                if (notification.ForeColor == Color.Red)
                    return;
            }
            else if (stepLoc.X == 256)
            {
                fnameV = firstName.Text;
                lnameV = lastName.Text;
                emailV = email.Text;
                if (phone.Text.Length > 0)
                {
                    phoneV = int.Parse(phone.Text);
                }
                locationV = location.Text;
                nationV = nation.Text;
                birthDateV = birthDate.Value.ToString("yyyy-MM-dd");
                locationV = location.Text;
                nationV = nation.Text;
                imageUrlV = imgUrl.Text;
                if (gender.Text == "Male") genderV = 1;
                else if (gender.Text == "Female") genderV = 2;
                else if (gender.Text == "Other") genderV = 3;
            }

            usernamePanel.Visible = false;
            firstNamePanel.Visible = false;
            lastnamePanel.Visible = false;
            emailPanel.Visible = false;
            phonePanel.Visible = false;
            nationPanel.Visible = false;
            birthDatePanel.Visible = false;
            genderPanel.Visible = false;
            locationPanel.Visible = false;
            imageUrlPanel.Visible = false;
            passwordPanel.Visible = true;
            confirmPanel.Visible = true;

            stepLoc.X = 372;
            step.Text = "Finish";
            step.Location = new Point(stepLoc.X, stepLoc.Y);
            label2.Visible = true;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Point stepLoc = step.Location;
            if (stepLoc.X == 123)
            {
                usernameV = username.Text;
                // check username exsistance 
                foreach (Label a in usernameNotification.Controls)
                {
                    usernameNotification.Controls.Remove(a);
                }
                Label notification = new Label();
                if (username.Text == null || username.Text.Length <= 0)
                {
                    notification.Text = "Please enter a username to sign in!";
                    notification.ForeColor = Color.Red;
                }
                else if (usernameV.Length < 5)
                {
                    notification.Text = "Username must have at least 6 characters!";
                    notification.ForeColor = Color.Red;
                }
                else if (usernameV.Contains(" "))
                {
                    notification.Text = "Your username cannot contains space!";
                    notification.ForeColor = Color.Red;
                }
                else
                {
                    try
                    {
                        cmd = new SqlCommand("select * from users where username=@username", con);
                        cmd.Parameters.AddWithValue("@username", usernameV);
                        con.Open();
                        dr = cmd.ExecuteReader();
                        dr.Read();
                        if (dr.HasRows)
                        {
                            notification.Text = "Username had been taken!";
                            notification.ForeColor = Color.Red;
                        }
                        else
                        {
                            notification.Text = "Username save!";
                            notification.ForeColor = Color.Green;
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
                notification.Size = new Size(600, 32);
                usernameNotification.Controls.Add(notification);
                if (notification.ForeColor == Color.Red)
                    return;
            }
            else if (stepLoc.X == 372)
            {
                foreach (Label a in confirmNotification.Controls)
                {
                    confirmNotification.Controls.Remove(a);
                }
                Label notification = new Label();
                if (password.Text == null || password.Text.Length <= 0)
                {
                    notification.Text = "Password cannot be empty!";
                    notification.ForeColor = Color.Red;
                    passwordPanel.BackColor = Color.LavenderBlush;
                }
                else if (password.Text.Length <= 6)
                {
                    notification.Text = "Your password must have at least 6 characters!";
                    notification.ForeColor = Color.Red;
                    passwordPanel.BackColor = Color.LavenderBlush;
                }
                else if (password.Text.Contains(" "))
                {
                    notification.Text = "Your password cannot contains space!";
                    notification.ForeColor = Color.Red;
                    passwordPanel.BackColor = Color.LavenderBlush;
                }
                else if (password.Text != confirm.Text)
                {
                    notification.Text = "Passwords do not match!";
                    notification.ForeColor = Color.Red;
                    confirmPanel.BackColor = Color.LavenderBlush;
                }
                else if (password.Text == confirm.Text)
                {
                    passwordV = password.Text;
                    notification.Text = "Password saved!";
                    notification.ForeColor = Color.Green;
                    passwordPanel.BackColor = Color.MintCream;
                    confirmPanel.BackColor = Color.MintCream;
                }
                notification.Size = new Size(600, 32);
                confirmNotification.Controls.Add(notification);
                if (notification.ForeColor == Color.Red)
                    return;
            }

            label2.Visible = false;
            step.Text = "Next";
            stepLoc.X = 256;
            step.Location = new Point(stepLoc.X, stepLoc.Y);

            usernamePanel.Visible = false;
            firstNamePanel.Visible = true;
            lastnamePanel.Visible = true;
            emailPanel.Visible = true;
            phonePanel.Visible = true;
            nationPanel.Visible = true;
            birthDatePanel.Visible = true;
            genderPanel.Visible = true;
            locationPanel.Visible = true;
            imageUrlPanel.Visible = true;
            passwordPanel.Visible = false;
            confirmPanel.Visible = false;

        }

        private void step_Click(object sender, EventArgs e)
        {
            Point stepLoc = step.Location;
            if (stepLoc.X == 123)
            {
                usernameV = username.Text;
                // check username exsistance 
                foreach (Label a in usernameNotification.Controls)
                {
                    usernameNotification.Controls.Remove(a);
                }
                Label notification = new Label();
                if (username.Text == null || username.Text.Length <= 0)
                {
                    notification.Text = "Please enter a username to sign in!";
                    notification.ForeColor = Color.Red;
                    usernamePanel.BackColor = Color.LavenderBlush;
                }
                else if (usernameV.Length < 5)
                {
                    notification.Text = "Username must have at least 5 characters!";
                    notification.ForeColor = Color.Red;
                    usernamePanel.BackColor = Color.LavenderBlush;
                }
                else if (usernameV.Contains(" "))
                {
                    notification.Text = "Your username cannot contains space!";
                    notification.ForeColor = Color.Red;
                    usernamePanel.BackColor = Color.LavenderBlush;
                }
                else
                {
                    try
                    {
                        cmd = new SqlCommand("select * from users where username=@username", con);
                        cmd.Parameters.AddWithValue("@username", usernameV);
                        con.Open();
                        dr = cmd.ExecuteReader();
                        dr.Read();
                        if (dr.HasRows)
                        {
                            notification.Text = "Username had been taken!";
                            notification.ForeColor = Color.Red;
                            usernamePanel.BackColor = Color.LavenderBlush;
                        }
                        else
                        {
                            notification.Text = "Username save!";
                            notification.ForeColor = Color.Green;
                            usernamePanel.BackColor = Color.MintCream;
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
                notification.Size = new Size(600, 32);
                usernameNotification.Controls.Add(notification);
                if (notification.ForeColor == Color.Red)
                    return;

                // up date mainBody
                usernamePanel.Visible = false;
                firstNamePanel.Visible = true;
                lastnamePanel.Visible = true;
                emailPanel.Visible = true;
                phonePanel.Visible = true;
                nationPanel.Visible = true;
                birthDatePanel.Visible = true;
                genderPanel.Visible = true;
                locationPanel.Visible = true;
                imageUrlPanel.Visible = true;
                passwordPanel.Visible = false;
                confirmPanel.Visible = false;

                label2.Visible = false;
                stepLoc.X = 256;
                step.Location = new Point(stepLoc.X, stepLoc.Y);
            }
            else if (stepLoc.X == 256)
            {
                fnameV = firstName.Text;
                lnameV = lastName.Text;
                emailV = email.Text;
                if (phone.Text.Length > 0)
                {
                    phoneV = int.Parse(phone.Text);
                }
                locationV = location.Text;
                nationV = nation.Text;
                birthDateV = birthDate.Value.ToString("yyyy-MM-dd");
                locationV = location.Text;
                nationV = nation.Text;
                imageUrlV = imgUrl.Text;
                if (gender.Text == "Male") genderV = 1;
                else if (gender.Text == "Female") genderV = 2;
                else if (gender.Text == "Other") genderV = 3;

                usernamePanel.Visible = false;
                firstNamePanel.Visible = false;
                lastnamePanel.Visible = false;
                emailPanel.Visible = false;
                phonePanel.Visible = false;
                nationPanel.Visible = false;
                birthDatePanel.Visible = false;
                genderPanel.Visible = false;
                locationPanel.Visible = false;
                imageUrlPanel.Visible = false;
                passwordPanel.Visible = true;
                confirmPanel.Visible = true;

                stepLoc.X = 372;
                step.Text = "Finish";
                step.Location = new Point(stepLoc.X, stepLoc.Y);
                label2.Visible = true;
            }
            else
            {
                foreach (Label a in confirmNotification.Controls)
                {
                    confirmNotification.Controls.Remove(a);
                }
                Label notification = new Label();
                if (password.Text == null || password.Text.Length <= 0)
                {
                    notification.Text = "Password cannot be empty!";
                    notification.ForeColor = Color.Red;
                    passwordPanel.BackColor = Color.LavenderBlush;
                }
                else if (password.Text.Length <= 6)
                {
                    notification.Text = "Your password must have at least 6 characters!";
                    notification.ForeColor = Color.Red;
                    passwordPanel.BackColor = Color.LavenderBlush;
                }
                else if (password.Text.Contains(" "))
                {
                    notification.Text = "Your password cannot contains space!";
                    notification.ForeColor = Color.Red;
                    passwordPanel.BackColor = Color.LavenderBlush;
                }
                else if (password.Text != confirm.Text)
                {
                    notification.Text = "Passwords do not match!";
                    notification.ForeColor = Color.Red;
                    confirmPanel.BackColor = Color.LavenderBlush;
                }
                else if (password.Text == confirm.Text)
                {
                    passwordV = password.Text;
                    notification.Text = "Password saved!";
                    notification.ForeColor = Color.Green;
                    passwordPanel.BackColor = Color.MintCream;
                    confirmPanel.BackColor = Color.MintCream;
                }
                notification.Size = new Size(600, 32);
                confirmNotification.Controls.Add(notification);
                if (notification.ForeColor == Color.Red)
                    return;

                int rowsAffected = 0;
                try
                {
                    cmd = new SqlCommand("insert into users ([firstName], [lastName], [username], [password], [email], [phone], [gender], [birthDate], [profileImage], [age], [location], [nation]) values (N'" + fnameV + "', N'" + lnameV + "', N'" + usernameV + "', N'" + passwordV + "', N'" + emailV + "', N'" + phoneV + "', " + genderV + ", N'" + birthDateV + "', N'" + imageUrlV + "', " + (2023 - birthDate.Value.Year) + ", N'" + locationV + "', N'" + nationV + "')", con);
                    con.Open();
                    rowsAffected = cmd.ExecuteNonQuery();

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

                    //Register done, return to login.
                    if (rowsAffected > 0)
                    {
                        passwordPanel.Visible = false;
                        confirmPanel.Visible = false;
                        finish.Visible = false;
                        foreach (Label a in panel1.Controls)
                        {
                            panel1.Controls.Remove(a);
                        }
                        foreach (Panel b in mainBody.Controls)
                        {
                            mainBody.Controls.Remove(b);
                        }
                        mainBody.Controls.Add(donePanel);
                        donePanel.Visible = true;
                        step.Visible = false;
                    }
                }
            }
        }

        private void firstName_TextChanged(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                lastName.Focus();
        }

        private void previous_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
        }

        private void username_TextChanged(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                step_Click(sender, e);
        }

        private void lastName_TextChanged(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                email.Focus();
        }

        private void email_TextChanged(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                phone.Focus();
        }

        private void nation_SelectedIndexChanged(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                birthDate.Focus();
        }

        private void phone_TextChanged(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                nation.Focus();
        }

        private void birthDate_ValueChanged(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                location.Focus();
        }

        private void location_TextChanged(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                gender.Focus();
        }

        private void gender_SelectedIndexChanged(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                imgUrl.Focus();
        }

        private void imgUrl_TextChanged(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                step_Click(sender, e);
        }

        private void password_TextChanged(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                confirm.Focus();
        }

        private void confirm_TextChanged(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                step_Click(sender, e);
        }

        private void firstNameLabel_Click(object sender, EventArgs e)
        {

        }

        private void login_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
        }
        #endregion

        #region add picture to banner
        private async void RegistForm_LoadAsync(object sender, EventArgs e)
        {
            while (this.Visible)
            {
                getAdImage(adIndexAutoGen());
                await Task.Delay(1500);
            }
        }

        private void adLabel_Click(object sender, EventArgs e)
        {

            int range = 2000;
            Random rand = new Random();
            int randIndex = rand.Next(1000, range);
            adLabel.Text = randIndex.ToString();
            getAdImage(randIndex);
        }
        #endregion
    }
}
