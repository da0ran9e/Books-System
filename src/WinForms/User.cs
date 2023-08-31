using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms
{
    public class User
    {
        public int userId { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public byte gender { get; set; }
        public DateTime date { get; set; }
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
            this.date = new DateTime(1800, 01, 01);
            this.profileImage = null;
            this.age = 0;
            this.location = null;
            this.nation = null;
        }

        public User(int userId, string fname, string lname, string username, string password, string email, string phone, byte gender, DateTime date, string profileImage, int age, string location, string nation)
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
}
