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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Library_desktop.Components;
using Library_desktop.Service;

namespace Library_desktop
{
    /// <summary>
    /// Interaction logic for Book.xaml
    /// </summary>
    public partial class Book : Page
    {
        internal string b_id;

        public Book()
        {
            InitializeComponent();
            LoadData();
        }

        public async void LoadData()
        {
            var BookSer = new BookService();
            var books = await BookSer.FetchBookData();

            BooksDataGrid.ItemsSource = books;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the current book
            var button = (Button)sender;
            var book = (Library_desktop.Class.Book)button.DataContext;

            var editWindow = new EditPage(book,LoadData);
            editWindow.Show();
        }

        private void AddBookButton_Click(object sender, RoutedEventArgs e)
        {
            var createBookWindow = new CreateBook();
            createBookWindow.Show();
        }
    }
}
