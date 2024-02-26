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
    /// Interaction logic for CreateBorrow.xaml
    /// </summary>
    public partial class CreateBorrow : Window
    {
        private readonly MemberService memberService = new MemberService();
        private readonly BookService bookService = new BookService();
        private readonly BorrowService borrowService = new BorrowService();


        public DateTime br_date_br { get; set; }

        public string m_user { get; set; }

        public string b_id {  get; set; }

        public List<Library_desktop.Class.Member> Members { get; set; }

        public List<Library_desktop.Class.Book> Books { get; set; }

        Action FetchData;


        public CreateBorrow(Action FetchData)
        {
            InitializeComponent();
            LoadData();
            this.FetchData = FetchData;
        }

        private async void LoadData()
        {
            Members = await memberService.FetchMemberData();
            Books = await bookService.FetchBookData();

            DataContext = this;
        }

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var DataCreate = new BorrowCreate
            {
                br_date_br = br_date_br,
                b_id = b_id,
                m_user = m_user,
            };

            String message = await borrowService.CreateBorrowData(DataCreate);

            MessageBox.Show(message);

            FetchData();

            this.Close();

        }
    }
}
