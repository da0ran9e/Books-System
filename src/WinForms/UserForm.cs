using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinForms
{
    public partial class UserForm : Form
    {
        public int id;
        public string firstname;
        public string lastname;
        public string username;
        public string password;
        public string email;
        public string phone;
        public byte gender;
        public DateTime birthDate;
        public string profileImage;
        public int age;
        public string location;
        public string nation;
        public UserForm()
        {

            InitializeComponent();
        }

        public UserForm(int id, string firstname, string lastname, string username, string password, string email, string phone, byte gender, DateTime birthDate, string profileImage, int age, string location, string nation)
        {
            this.id = id;
            this.firstname = firstname;
            this.lastname = lastname;
            this.username = username;
            this.password = password;
            this.email = email;
            this.phone = phone;
            this.gender = gender;
            this.birthDate = birthDate;
            this.profileImage = profileImage;
            this.age = age;
            this.location = location;
            this.nation = nation;

            InitializeComponent();
            this.DoubleBuffered = true;
        }

        private async void roundedUsername_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 15; i++)
            {
                roundedUsername.Width += 20;
                await Task.Delay(1);
            }
            usernameTextBox.Text = "";
            usernameTextBox.Enabled = true;
            usernameTextBox.Visible = true;
            usernameTextBox.Focus();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void UserForm_LoadAsync(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.ColorTranslator.FromHtml("#010000");
            EnableBlur();

            userIdLabel.Text = "User ID: " + id;
            //username

            for (int i = 0; i < 21; i++)
            {
                roundedUsername.Width += 20;
                await Task.Delay(1);
            }
            roundedUsername.BorderColor = Color.Cyan;
            roundedUsername.Text = "  ✔️";
            roundedUsername.ForeColor = Color.Lime;

            usernameTextBox.Text = username;
            usernameTextBox.Enabled = true;
            usernameTextBox.Visible = true;

            //firstName 
            if (firstname != null)
            {
                for (int i = 0; i < 8; i++)
                {
                    roundedFirstName.Width += 20;
                    await Task.Delay(1);
                }
                roundedFirstName.BorderColor = Color.Cyan;
                roundedFirstName.Text = "  ✔️";
                roundedFirstName.ForeColor = Color.Lime;

                firstNameTextBox.Text = firstname;
                firstNameTextBox.Enabled = true;
                firstNameTextBox.Visible = true;
            }

            //lastName
            if (lastname != null)
            {
                for (int i = 0; i < 8; i++)
                {
                    roundedLastName.Width += 20;
                    await Task.Delay(1);
                }
                roundedLastName.BorderColor = Color.Cyan;
                roundedLastName.Text = "  ✔️";
                roundedLastName.ForeColor = Color.Lime;

                lastNameTextbox.Text = lastname;
                lastNameTextbox.Enabled = true;
                lastNameTextbox.Visible = true;
            }

            //gender
            if (gender != 0)
            {
                for (int i = 0; i < 8; i++)
                {
                    roundedGender.Width += 20;
                    await Task.Delay(1);
                }
                roundedGender.BorderColor = Color.Cyan;
                roundedGender.Text = "  ✔️";
                roundedGender.ForeColor = Color.Lime;

                if (gender == 1)
                    genderValue.Text = "Male";
                else if (gender == 2)
                    genderValue.Text = "Female";
                else if (gender == 3)
                    genderValue.Text = "Other";
                genderValue.Enabled = true;
                genderValue.Visible = true;
            }

            //birthDate
            if (birthDate != null)
            {
                for (int i = 0; i < 8; i++)
                {
                    roundedBirthDate.Width += 20;
                    await Task.Delay(1);
                }
                roundedBirthDate.BorderColor = Color.Cyan;
                roundedBirthDate.Text = "  ✔️";
                roundedBirthDate.ForeColor = Color.Lime;

                birthDay.Text = birthDate.ToString("dd") + "/" + birthDate.ToString("MM") + "/" + birthDate.ToString("yyyy");
                birthDay.Enabled = true;
                birthDay.Visible = true;
            }

            //nation
            if (nation != null)
            {
                for (int i = 0; i < 8; i++)
                {
                    roundedNation.Width += 20;
                    await Task.Delay(1);
                }
                roundedNation.BorderColor = Color.Cyan;
                roundedNation.Text = "  ✔️";
                roundedNation.ForeColor = Color.Lime;

                nationValue.Text = nation;
                nationValue.Enabled = true;
                nationValue.Visible = true;
            }

            //location
            if (location != null)
            {
                for (int i = 0; i < 8; i++)
                {
                    roundedLocation.Width += 20;
                    await Task.Delay(1);
                }
                roundedLocation.BorderColor = Color.Cyan;
                roundedLocation.Text = "  ✔️";
                roundedLocation.ForeColor = Color.Lime;

                locationTextBox.Text = location;
                locationTextBox.Enabled = true;
                locationTextBox.Visible = true;
            }

            //phone
            if (phone != null)
            {
                for (int i = 0; i < 10; i++)
                {
                    roundedPhone.Width += 20;
                    await Task.Delay(1);
                }
                roundedPhone.BorderColor = Color.Cyan;
                roundedPhone.Text = "  ✔️";
                roundedPhone.ForeColor = Color.Lime;

                phoneTextBox.Text = phone;
                phoneTextBox.Enabled = true;
                phoneTextBox.Visible = true;
            }

            //email
            if (email != null)
            {
                for (int i = 0; i < 21; i++)
                {
                    roundedEmail.Width += 20;
                    await Task.Delay(1);
                }
                roundedEmail.BorderColor = Color.Cyan;
                roundedEmail.Text = "  ✔️";
                roundedEmail.ForeColor = Color.Lime;

                emailTextBox.Text = email;
                emailTextBox.Enabled = true;
                emailTextBox.Visible = true;
            }

            //profilePictureLink
            if (profileImage != null)
            {
                for (int i = 0; i < 21; i++)
                {
                    roundedProfilePictureLink.Width += 20;
                    await Task.Delay(1);
                }
                roundedProfilePictureLink.BorderColor = Color.Cyan;
                roundedProfilePictureLink.Text = "  ✔️";
                roundedProfilePictureLink.ForeColor = Color.Lime;

                profilePictureLinkTextBox.Text = profileImage;
                profilePictureLinkTextBox.Enabled = true;
                profilePictureLinkTextBox.Visible = true;
            }
        }
    }
}
