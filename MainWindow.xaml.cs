using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Library_desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var page = (Page)Activator.CreateInstance(Type.GetType($"Library_desktop.Borrow"));
            MainFrame.Navigate(page);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var menuItem = e.OriginalSource as MenuItem;

            if(menuItem != null)
            {
                var pageName = menuItem.Tag.ToString();

                var page = (Page)Activator.CreateInstance(Type.GetType($"Library_desktop.{pageName}"));
    
                MainFrame.Navigate(page);
            }
        }
    }
}