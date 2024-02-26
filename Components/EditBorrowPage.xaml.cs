using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Library_desktop.Class;
using Library_desktop.Service;

namespace Library_desktop.Components
{
    /// <summary>
    /// Interaction logic for EditBorrowPage.xaml
    /// </summary>
    public partial class EditBorrowPage : Window
    {
        private readonly BorrowService _borrowService = new BorrowService();
        private readonly MemberService memberService = new MemberService();
        private readonly BookService bookService = new BookService();

        public List<Library_desktop.Class.Member> Members {get;set;}

        public List<Library_desktop.Class.Book> Books { get;set;}
        public string SelectedMember { get; set; }
        public string SelectedBook { get; set; }
        public DateTime BrDateBr { get; set; }
        public DateTime? BrDateRt { get; set; }

        public DateTime BrDateBrOld { get; set; }

        public String mid;

        public String bid;

        public int br_fine;


        Action FetchData;


        public EditBorrowPage(DateTime BrDateBr,DateTime? BrDateRt,String mid,String bid,int fine,Action FetchData)
        {
            InitializeComponent();
            LoadData();
            this.BrDateBrOld = BrDateBr;
            this.BrDateBr = BrDateBr;
            this.BrDateRt = BrDateRt;
            this.bid = bid;
            this.mid = mid;
            this.br_fine = fine;
            this.FetchData = FetchData;
            this.SelectedBook = bid;
            this.SelectedMember = mid;

        }

        private async void LoadData()
        {
            Members = await memberService.FetchMemberData();
            Books = await bookService.FetchBookData();

            DataContext = this;
        }

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(Fine_Borrow.Text, out int fine))
            {
                var DataUpdate = new BorrowUpdate
                {
                    br_date_br = BrDateBr,
                    br_date_rt = BrDateRt,
                    br_date_rt_old = BrDateBrOld,
                    br_fine = fine,
                    m_user_old = mid,
                    b_id_old = bid,
                    m_user = SelectedMember,
                    b_id = SelectedBook,
                };

                String message = await _borrowService.UpdateBorrowData(DataUpdate);

                MessageBox.Show(br_fine.ToString());

                FetchData();

                this.Close();
            }
            else
            {
                MessageBox.Show("กรุณาป้อนค่าจำนวนเต็มที่ถูกต้อง");
            }
        }
    }
}
