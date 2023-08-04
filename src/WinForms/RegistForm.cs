using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms
{
    public partial class RegistForm : Form
    {
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
            this.WindowState = FormWindowState.Maximized;
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
                birthDateV = birthDate.Value.ToString("yyyy-mm-dd");
                locationV = location.Text;
                nationV = nation.Text;
                imageUrlV = imgUrl.Text;
                if (gender.Text == "Male") genderV = 1;
                else if (gender.Text == "Female") genderV = 2;
                else if (gender.Text == "Other") genderV = 3;
            }
            else if (stepLoc.X == 372)
            {
                if (password.Text == confirm.Text) passwordV = password.Text;
                else if (password.Text != confirm.Text)
                {
                    Label notification = new Label();
                    notification.Text = "Passwords do not match!";
                    notification.ForeColor = Color.Red;
                    confirmNotification.Controls.Add(notification);
                    return;
                }
                else if (password.Text == null || password.Text == "")
                {
                    Label notification = new Label();
                    notification.Text = "Password cannot be empty!";
                    notification.ForeColor = Color.Red;
                    confirmNotification.Controls.Add(notification);
                    return;
                }
                else if (password.Text.Contains(" "))
                {
                    Label notification = new Label();
                    notification.Text = "Password cannot contains space!";
                    notification.ForeColor = Color.Red;
                    confirmNotification.Controls.Add(notification);
                    return;
                }
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
            step.Location = new Point(stepLoc.X, stepLoc.Y);
            label2.Visible = true;
        }

        private void finish_Click(object sender, EventArgs e)
        {
            Point stepLoc = step.Location;
            if (stepLoc.X == 123)
            {
                usernameV = usernameLabel.Text;
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
                birthDateV = birthDate.Value.ToString("yyyy-mm-dd");
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
            label2.Visible = false;
            Point stepLoc = step.Location;
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
                usernameV = usernameLabel.Text;

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
                birthDateV = birthDate.Value.ToString("yyyy-mm-dd");
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
                if (password.Text == confirm.Text) passwordV = password.Text;
                else if (password.Text != confirm.Text)
                {
                    Label notification = new Label();
                    notification.Text = "Passwords do not match!";
                    notification.ForeColor = Color.Red;
                    notification.Size = new Size(600, 32);
                    confirmNotification.Controls.Add(notification);
                    return;
                }
                else if (password.Text == null || password.Text == "")
                {
                    Label notification = new Label();
                    notification.Text = "Password cannot be empty!";
                    notification.ForeColor = Color.Red;
                    notification.Size = new Size(600, 32);
                    confirmNotification.Controls.Add(notification);
                    return;
                }
                else if (password.Text.Contains(" "))
                {
                    Label notification = new Label();
                    notification.Text = "Password cannot contains space!";
                    notification.ForeColor = Color.Red;
                    notification.Size = new Size(600, 32);
                    confirmNotification.Controls.Add(notification);
                    return;
                }
            }
        }

        private void firstName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
