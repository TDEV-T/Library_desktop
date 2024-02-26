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
    /// Interaction logic for EditMember.xaml
    /// </summary>
    public partial class EditMember : Window
    {

        private Member mem;
        private String mid;
        private Action loadData;

        public EditMember(Library_desktop.Class.Member member,Action LoadData)
        {
            InitializeComponent();
            this.DataContext = member;
            this.mid = member.m_user;
            this.loadData = LoadData;
        }

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var member = (Library_desktop.Class.Member)this.DataContext;

            var memSer = new MemberService();

            string message = await memSer.UpdateMemberData(member, this.mid);

            MessageBox.Show(message, "Operation Message");

            loadData();
        }

        private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var memSer = new MemberService();

            string message = await memSer.DeleteMemberData(mid);

            MessageBox.Show(message, "Operation Message");

            loadData();

            this.Close();
       
        }
    }
}
