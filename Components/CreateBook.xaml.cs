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
using Library_desktop.Service;

namespace Library_desktop.Components
{
    /// <summary>
    /// Interaction logic for CreateBook.xaml
    /// </summary>
    public partial class CreateBook : Window
    {
        public CreateBook()
        {
            InitializeComponent();
            this.DataContext = new Library_desktop.Class.Book();
        }

        private async void CreateBook_Button(object sender, RoutedEventArgs e)
        {
            var book = (Library_desktop.Class.Book)this.DataContext;

            var bookSer = new BookService();

            string message = await bookSer.CreateBookData(book);

            MessageBox.Show(message, "Operation Message");

            this.DataContext = new Library_desktop.Class.Book();
        }
    }
}
