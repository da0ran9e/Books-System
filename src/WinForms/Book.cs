using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms
{
    public class Book
    {
        public int index { get; set; }
        public string isbn { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public string publisher { get; set; }
        public int year { get; set; }
        public string sURL { get; set; }
        public string mURL { get; set; }
        public string lURL { get; set; }

        public Book()
        {
            this.index = 0;
            this.isbn = null;
            this.title = null;
            this.author = null;
            this.publisher = null;
            this.year = 0;
            this.sURL = null;
            this.mURL = null;
            this.lURL = null;
        }

        public Book(int index, string isbn, string title, string author, string publisher, int year, string sURL, string mURL, string lURL)
        {
            this.index = index;
            this.isbn = isbn;
            this.title = title;
            this.author = author;
            this.publisher = publisher;
            this.year = year;
            this.sURL = sURL;
            this.mURL = mURL;
            this.lURL = lURL;
        }
    }
}
