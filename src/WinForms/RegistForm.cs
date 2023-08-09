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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void maximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                maximize.Image = Image.FromFile("../../../../../assets/icons/minimize.png");
                this.WindowState = FormWindowState.Maximized;
                panel1.Location = new Point(763, 331);
            }
            else
            {
                maximize.Image = Image.FromFile("../../../../../assets/icons/maximize.png");
                this.WindowState = FormWindowState.Normal;
                panel1.Location = new Point(63, 331);
            }

        }

        private void flowLayoutPanel2_Onclick(object sender, EventArgs e)
        {
            username.Enabled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

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
            mainBody.Controls.Add(usernamePanel);
            mainBody.Controls.Remove(firstNamePanel);
            mainBody.Controls.Remove(lastnamePanel);
            mainBody.Controls.Remove(emailPanel);
            mainBody.Controls.Remove(emailPanel);
            mainBody.Controls.Remove(phonePanel);
            mainBody.Controls.Remove(nationPanel);
            mainBody.Controls.Remove(birthDatePanel);
            mainBody.Controls.Remove(genderPanel);
            mainBody.Controls.Remove(locationPanel);
            mainBody.Controls.Remove(imageUrlPanel);
            mainBody.Controls.Remove(passwordPanel);
            mainBody.Controls.Remove(confirmPanel);
            usernamePanel.Visible = true;
            firstNamePanel.Visible = true;
            lastnamePanel.Visible = true;
            emailPanel.Visible = true;
            phonePanel.Visible = true;
            nationPanel.Visible = true;
            birthDatePanel.Visible = true;
            genderPanel.Visible = true;
            locationPanel.Visible = true;
            imageUrlPanel.Visible = true;
            passwordPanel.Visible = true;
            confirmPanel.Visible = true;


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
                else if (usernameV.Length <= 6)
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

            mainBody.Controls.Remove(usernamePanel);
            mainBody.Controls.Remove(firstNamePanel);
            mainBody.Controls.Remove(lastnamePanel);
            mainBody.Controls.Remove(emailPanel);
            mainBody.Controls.Remove(phonePanel);
            mainBody.Controls.Remove(nationPanel);
            mainBody.Controls.Remove(birthDatePanel);
            mainBody.Controls.Remove(genderPanel);
            mainBody.Controls.Remove(locationPanel);
            mainBody.Controls.Remove(imageUrlPanel);
            mainBody.Controls.Add(passwordPanel);
            mainBody.Controls.Add(confirmPanel);
            usernamePanel.Visible = true;
            firstNamePanel.Visible = true;
            lastnamePanel.Visible = true;
            emailPanel.Visible = true;
            phonePanel.Visible = true;
            nationPanel.Visible = true;
            birthDatePanel.Visible = true;
            genderPanel.Visible = true;
            locationPanel.Visible = true;
            imageUrlPanel.Visible = true;
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
                else if (usernameV.Length <= 6)
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

            mainBody.Controls.Remove(usernamePanel);
            mainBody.Controls.Add(lastnamePanel);
            mainBody.Controls.Add(firstNamePanel);
            mainBody.Controls.Add(emailPanel);
            mainBody.Controls.Add(phonePanel);
            mainBody.Controls.Add(nationPanel);
            mainBody.Controls.Add(birthDatePanel);
            mainBody.Controls.Add(genderPanel);
            mainBody.Controls.Add(locationPanel);
            mainBody.Controls.Add(imageUrlPanel);
            mainBody.Controls.Remove(passwordPanel);
            mainBody.Controls.Remove(confirmPanel);
            usernamePanel.Visible = true;
            firstNamePanel.Visible = true;
            lastnamePanel.Visible = true;
            emailPanel.Visible = true;
            phonePanel.Visible = true;
            nationPanel.Visible = true;
            birthDatePanel.Visible = true;
            genderPanel.Visible = true;
            locationPanel.Visible = true;
            imageUrlPanel.Visible = true;
            passwordPanel.Visible = true;
            confirmPanel.Visible = true;
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
                else if (usernameV.Length <= 6)
                {
                    notification.Text = "Username must have at least 6 characters!";
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
                mainBody.Controls.Remove(usernamePanel);
                mainBody.Controls.Add(lastnamePanel);
                mainBody.Controls.Add(firstNamePanel);
                mainBody.Controls.Add(emailPanel);
                mainBody.Controls.Add(phonePanel);
                mainBody.Controls.Add(nationPanel);
                mainBody.Controls.Add(birthDatePanel);
                mainBody.Controls.Add(genderPanel);
                mainBody.Controls.Add(locationPanel);
                mainBody.Controls.Add(imageUrlPanel);
                mainBody.Controls.Remove(passwordPanel);
                mainBody.Controls.Remove(confirmPanel);
                usernamePanel.Visible = true;
                firstNamePanel.Visible = true;
                lastnamePanel.Visible = true;
                emailPanel.Visible = true;
                phonePanel.Visible = true;
                nationPanel.Visible = true;
                birthDatePanel.Visible = true;
                genderPanel.Visible = true;
                locationPanel.Visible = true;
                imageUrlPanel.Visible = true;
                passwordPanel.Visible = true;
                confirmPanel.Visible = true;

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


                mainBody.Controls.Remove(usernamePanel);
                mainBody.Controls.Remove(firstNamePanel);
                mainBody.Controls.Remove(lastnamePanel);
                mainBody.Controls.Remove(emailPanel);
                mainBody.Controls.Remove(phonePanel);
                mainBody.Controls.Remove(nationPanel);
                mainBody.Controls.Remove(birthDatePanel);
                mainBody.Controls.Remove(genderPanel);
                mainBody.Controls.Remove(locationPanel);
                mainBody.Controls.Remove(imageUrlPanel);
                mainBody.Controls.Add(passwordPanel);
                mainBody.Controls.Add(confirmPanel);
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
                        confirm.Enabled = false;
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
        private void regisForm_MouseMove(object sender, MouseEventArgs e)
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

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

        private void confirm_TextChanged(object sender, EventArgs e)
        {

        }

        private void RegistForm_Load(object sender, EventArgs e)
        {
            mainBody.BackColor = System.Drawing.ColorTranslator.FromHtml("#010000");
            EnableBlur();
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            AppUtils.EnableAcrylic(mainBody, Color.Transparent);
            base.OnHandleCreated(e);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            e.Graphics.Clear(Color.Transparent);
        }
    }
}
