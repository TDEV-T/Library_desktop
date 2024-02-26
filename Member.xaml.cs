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
    /// Interaction logic for Member.xaml
    /// </summary>
    public partial class Member : Page
    {
        public Member()
        {
            InitializeComponent();
            LoadData();
        }

        public async void LoadData()
        {
            var MemberSer = new MemberService();

            var members = await MemberSer.FetchMemberData();

            MembersDataGrid.ItemsSource = members;
        }

        private void AddMemberButton_Click(object sender, RoutedEventArgs e)
        {
            var createMemberWindow = new CreateMember();
            createMemberWindow.Show();
        }
        
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var Member = (Library_desktop.Class.Member)button.DataContext;

            var editMember = new EditMember(Member,LoadData);
            editMember.Show();

        }
    }
}
