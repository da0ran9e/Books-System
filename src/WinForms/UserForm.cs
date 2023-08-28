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

        private async void roundedFirstName_Click(object sender, EventArgs e)
        {
            if (firstNameTextBox.Visible == false)
            {
                for (int i = 0; i < 8; i++)
                {
                    roundedFirstName.Width += 20;
                    await Task.Delay(1);
                }
                firstNameTextBox.Visible = true;
            }
            firstNameTextBox.Focus();
        }

        private async void roundedLastName_Click(object sender, EventArgs e)
        {
            if (lastNameTextbox.Visible == false)
            {
                for (int i = 0; i < 8; i++)
                {
                    roundedLastName.Width += 20;
                    await Task.Delay(1);
                }
                lastNameTextbox.Visible = true;
            }
            lastNameTextbox.Focus();
        }

        private async void roundedGender_Click(object sender, EventArgs e)
        {
            if (genderValue.Visible == false && genderComboBox.Visible == false)
            {
                for (int i = 0; i < 8; i++)
                {
                    roundedGender.Width += 20;
                    await Task.Delay(1);
                }
                genderComboBox.Visible = true;
            }
            genderValue.Visible = false;
            genderComboBox.Focus();
        }

        private async void roundedBirthDate_Click(object sender, EventArgs e)
        {
            if (birthDay.Visible == false && birthDatePicker.Visible == false)
            {
                for (int i = 0; i < 8; i++)
                {
                    roundedBirthDate.Width += 20;
                    await Task.Delay(1);
                }
                birthDatePicker.Visible = true;
            }
            birthDay.Visible = false;
            birthDatePicker.Focus();
        }

        private async void roundedNation_Click(object sender, EventArgs e)
        {
            if (nationValue.Visible == false && nationComboBox.Visible == false)
            {
                for (int i = 0; i < 8; i++)
                {
                    roundedNation.Width += 20;
                    await Task.Delay(1);
                }
                nationComboBox.Visible = true;
            }
            nationValue.Visible = false;
            nationComboBox.Focus();
        }

        private async void roundedLocation_Click(object sender, EventArgs e)
        {
            if (locationTextBox.Visible == false)
            {
                for (int i = 0; i < 8; i++)
                {
                    roundedLocation.Width += 20;
                    await Task.Delay(1);
                }
                locationTextBox.Visible = true;
            }
            locationTextBox.Focus();
        }

        private async void roundedPhone_Click(object sender, EventArgs e)
        {
            if (phoneTextBox.Visible == false)
            {
                for (int i = 0; i < 8; i++)
                {
                    roundedPhone.Width += 20;
                    await Task.Delay(1);
                }
                phoneTextBox.Visible = true;
            }
            phoneTextBox.Focus();
        }

        private async void roundedEmail_Click(object sender, EventArgs e)
        {
            if (emailTextBox.Visible == false)
            {
                for (int i = 0; i < 8; i++)
                {
                    roundedEmail.Width += 20;
                    await Task.Delay(1);
                }
                emailTextBox.Visible = true;
            }
            emailTextBox.Focus();
        }

        private async void roundedProfilePictureLink_Click(object sender, EventArgs e)
        {
            if (profilePictureLinkTextBox.Visible == false)
            {
                for (int i = 0; i < 8; i++)
                {
                    roundedProfilePictureLink.Width += 20;
                    await Task.Delay(1);
                }
                profilePictureLinkTextBox.Visible = true;
            }
            profilePictureLinkTextBox.Focus();
        }

        private void firstNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (firstNameTextBox.Text.Any(char.IsDigit))
            {
                roundedFirstName.BorderColor = Color.DeepPink;
                roundedFirstName.Text = "  ✖️";
                roundedFirstName.ForeColor = Color.IndianRed;
            }
            else
            {
                roundedFirstName.BorderColor = Color.Cyan;
                roundedFirstName.Text = "  ✔️";
                roundedFirstName.ForeColor = Color.Lime;
            }
        }

        private void lastNameTextbox_TextChanged(object sender, EventArgs e)
        {
            if (lastNameTextbox.Text.Any(char.IsDigit))
            {
                roundedLastName.BorderColor = Color.DeepPink;
                roundedLastName.Text = "  ✖️";
                roundedLastName.ForeColor = Color.IndianRed;
            }
            else
            {
                roundedLastName.BorderColor = Color.Cyan;
                roundedLastName.Text = "  ✔️";
                roundedLastName.ForeColor = Color.Lime;
            }
        }

        private void genderComboBox_TextChanged(object sender, EventArgs e)
        {
            roundedGender.BorderColor = Color.Cyan;
            roundedGender.Text = "  ✔️";
            roundedGender.ForeColor = Color.Lime;
        }

        private void genderComboBox_LostFocus(object sender, EventArgs e)
        {
            genderValue.Text = genderComboBox.Text;
            genderValue.Visible = true;
            genderComboBox.Visible = false;
        }

        private void birthDatePicker_ValueChanged(object sender, EventArgs e)
        {
            roundedBirthDate.BorderColor = Color.Cyan;
            roundedBirthDate.Text = "  ✔️";
            roundedBirthDate.ForeColor = Color.Lime;
        }

        private void birthDatePicker_LostFocus(Object sender, EventArgs e)
        {
            birthDay.Text = birthDatePicker.Value.ToString("dd") + "/" + birthDatePicker.Value.ToString("MM") + "/" + birthDatePicker.Value.ToString("yyyy");
            birthDay.Visible = true;
            birthDatePicker.Visible = false;
        }

        private void nationComboBox_TextChanged(object sender, EventArgs e)
        {
            roundedLastName.BorderColor = Color.Cyan;
            roundedLastName.Text = "  ✔️";
            roundedLastName.ForeColor = Color.Lime;
        }

        private void nationComboBox_LostFocus(object sender, EventArgs e)
        {
            nationValue.Text = nationComboBox.Text;
            nationValue.Visible = true;
            nationComboBox.Visible = false;
        }

        private void locationTextBox_TextChanged(object sender, EventArgs e)
        {
            roundedLocation.BorderColor = Color.Cyan;
            roundedLocation.Text = "  ✔️";
            roundedLocation.ForeColor = Color.Lime;
        }

        private void phoneTextBox_TextChanged(object sender, EventArgs e)
        {
            if (phoneTextBox.Text.Any(c => !char.IsDigit(c)))
            {
                roundedPhone.BorderColor = Color.DeepPink;
                roundedPhone.Text = "  ✖️";
                roundedPhone.ForeColor = Color.IndianRed;
            }
            else
            {
                roundedPhone.BorderColor = Color.Cyan;
                roundedPhone.Text = "  ✔️";
                roundedPhone.ForeColor = Color.Lime;
            }
        }

        private void emailTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!emailTextBox.Text.Contains('@'))
            {
                roundedEmail.BorderColor = Color.DeepPink;
                roundedEmail.Text = "  ✖️";
                roundedEmail.ForeColor = Color.IndianRed;
            }
            else
            {
                roundedEmail.BorderColor = Color.Cyan;
                roundedEmail.Text = "  ✔️";
                roundedEmail.ForeColor = Color.Lime;
            }
        }

        private void profilePictureLinkTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!profilePictureLinkTextBox.Text.Contains("http"))
            {
                roundedProfilePictureLink.BorderColor = Color.DeepPink;
                roundedProfilePictureLink.Text = "  ✖️";
                roundedProfilePictureLink.ForeColor = Color.IndianRed;
            }
            else
            {
                roundedProfilePictureLink.BorderColor = Color.Cyan;
                roundedProfilePictureLink.Text = "  ✔️";
                roundedProfilePictureLink.ForeColor = Color.Lime;
            }
        }
    }
}
