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
        public DateTime birthDate;
        public string profileImage;
        public int age;
        public string location;
        public UserForm()
        {

            InitializeComponent();
        }

        public UserForm(int id, string firstname, string lastname, string username, string password, string email, string phone, DateTime birthDate, string profileImage, int age, string location)
        {
            this.id = id;
            this.firstname = firstname;
            this.lastname = lastname;
            this.username = username;
            this.password = password;
            this.email = email;
            this.phone = phone;
            this.birthDate = birthDate;
            this.profileImage = profileImage;
            this.age = age;
            this.location = location;

            InitializeComponent();
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

        private void UserForm_Load(object sender, EventArgs e)
        {

        }
    }
}
