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
    /// Interaction logic for CreateMember.xaml
    /// </summary>
    public partial class CreateMember : Window
    {
        public CreateMember()
        {
            InitializeComponent();
            this.DataContext = new Library_desktop.Class.Member();
        }

        private async void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            var member = (Library_desktop.Class.Member)this.DataContext;

            var memberSer = new MemberService();

            string message = await memberSer.CreateMemberData(member);

            MessageBox.Show(message, "Operation Message");

            this.DataContext = new Library_desktop.Class.Member();
        }
    }
}
