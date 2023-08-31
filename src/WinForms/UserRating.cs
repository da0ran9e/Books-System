using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms
{
    public class UserRating : IComparable<UserRating>
    {
        public int userId { get; set; }
        public string isbn { get; set; }
        public byte rate { get; set; }


        public UserRating()
        {
            this.userId = -1;
            this.isbn = null;
            this.rate = 0;
        }

        public UserRating(int userId, string isbn, byte rate)
        {
            this.userId = userId;
            this.isbn = isbn;
            this.rate = rate;
        }

        public UserRating(int userId, string isbn)
        {
            this.userId = userId;
            this.isbn = isbn;
            this.rate = 0;
        }

        public int CompareTo(UserRating ur)
        {
            return -this.rate.CompareTo(ur.rate);
        }
    }
}
