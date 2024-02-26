using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_desktop.Class
{

    public class ListMember
    {
        public List<Member> data { get; set; }
    }

    public class Member
    {
        public string m_user { get; set; }
        public string m_name { get; set;}
        public string m_pass { get; set; }
        public string m_phone { get; set; }
    }
}
