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

        private void UserForm_Load(object sender, EventArgs e)
        {
            
        }
    }
}
