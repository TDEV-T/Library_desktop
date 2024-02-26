using System.Security.RightsManagement;

namespace Library_desktop.Class
{


    public class ListBorrow
    {
        public List<BorrowMapping> data { get; set; }
    }

    public class BorrowMapping
    {
        public DateTime br_date_br { get; set; }

        public DateTime? br_date_rt { get; set;}

        public string m_user { get; set;}

        public string b_id { get; set;}

        public int br_fine { get; set;}

        public Member user { get; set; }

        public Book book { get; set; } 

    }

    public class BorrowUpdate
    {
        public DateTime br_date_br { get; set; }

        public DateTime? br_date_rt { get; set; }

        public string m_user { get; set; }

        public string b_id { get; set; }

        public int br_fine { get; set; }

        public DateTime br_date_rt_old { get; set; }

        public  string m_user_old { get;set; }

        public string b_id_old { get; set; }
    }

    public class BorrowReturn
    {
        public DateTime br_date_rt { get; set; }

        public int br_fine { get; set; }

        public DateTime br_date_br_old { get; set; }

        public string m_user_old { get; set; }

        public string b_id_old { get; set; }
    }

    public class BorrowCreate
    {
        public DateTime br_date_br { get; set; }
        public string m_user { get; set; }

        public string b_id { get; set;}
    }

}
