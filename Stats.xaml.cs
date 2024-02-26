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

namespace Library_desktop
{
    /// <summary>
    /// Interaction logic for Stats.xaml
    /// </summary>
    public partial class Stats : Window
    {

        private readonly BorrowService borrowSer = new BorrowService();

        public Stats()
        {
            InitializeComponent();
            LoadData();

        }

        public async void LoadData()
        {
            StatsData data = await borrowSer.GetStats();

            BookBox.Text = $"Books: {data.book}";
            MemberBox.Text = $"Members: {data.member}";
            BorrowBox.Text = $"Borrow: {data.borrow}";
            BorrowNotCompleteBox.Text = $"Borrow Not Complete: {data.borrowNotCompelete}";
        }
    }
}
