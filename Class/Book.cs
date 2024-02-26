using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_desktop.Class
{

    public class RootBook
    {
        public List<Book> data { get; set; }
    }

    public class Book
    {
        public string b_id { get; set; }
        public string b_name { get; set; }
        public string b_writer { get; set; }
        public int b_category { get; set; }
        public int b_price { get; set; }
    }
}
