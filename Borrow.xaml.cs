using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Library_desktop.Components;
using Library_desktop.Service;

namespace Library_desktop
{
    /// <summary>
    /// Interaction logic for Borrow.xaml
    /// </summary>
    public partial class Borrow : Page
    {
        private readonly BorrowService borrowService = new BorrowService();

        public string search { get; set; }

        public Borrow()
        {
            InitializeComponent();
            Console.WriteLine("Data coming");
            this.Loaded += Borrow_Loaded;
           
        }

        private void Borrow_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
            DataContext = this;
        }

        public async void LoadData()
        {

            var borrowData = await borrowService.FetchBorrowData();

            BorrowsDataGrid.ItemsSource = borrowData;
        }

        private void AddMemberButton_Click(object sender, RoutedEventArgs e)
        {
            var CreateWindow = new CreateBorrow(LoadData);
            CreateWindow.Show();
        }

        private void EditButton_Click(object obj, RoutedEventArgs e) {

            var button = (Button)obj;
            var dataContext = button.DataContext as Library_desktop.Class.BorrowMapping;

            

            var borrowWindow = new EditBorrowPage(dataContext.br_date_br,dataContext.br_date_rt,dataContext.m_user,dataContext.b_id,dataContext.br_fine,LoadData);
            borrowWindow.Show();

        }

        public void ReturnButton_Click(object obj,RoutedEventArgs e)
        {

            var button = (Button)obj;
            var dataContext = button.DataContext as Library_desktop.Class.BorrowMapping;


            var returnWindow = new ReturnBorrow(dataContext.br_date_br,dataContext.m_user,dataContext.b_id,LoadData);
            returnWindow.Show();
        }

        private async void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.search != null)
            {
                var borrowData = await borrowService.SearchBorrowData(this.search);
                MessageBox.Show(borrowData[0].b_id.ToString());
                BorrowsDataGrid.ItemsSource = borrowData;
            }
            else
            {
                LoadData();
            }
        }
    }


}
