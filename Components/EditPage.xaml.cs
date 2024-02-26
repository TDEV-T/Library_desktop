using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Library_desktop.Service;

namespace Library_desktop.Components
{
    /// <summary>
    /// Interaction logic for EditPage.xaml
    /// </summary>
    public partial class EditPage : Window
    {
        private Book book;

        private String bid;

        private Action fetchData;

        public EditPage(Library_desktop.Class.Book book,Action FetchData)
        {
            InitializeComponent();
            this.DataContext = book;
            this.bid = book.b_id;
            this.fetchData = FetchData;

        }


        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var book = (Library_desktop.Class.Book)DataContext;

            var bookSer = new BookService();

           string message = await bookSer.UpdateBookData(book,this.bid);

            MessageBox.Show(message, "Operation Success");

            fetchData();
        }

        private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            BookService bookService = new BookService();
            string message = await bookService.DeleteBookData(this.bid);
            MessageBox.Show(message, "Operation Message");
            fetchData();
            this.Close();
        }
    }
}
