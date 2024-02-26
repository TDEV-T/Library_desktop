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
    /// Interaction logic for ReturnBorrow.xaml
    /// </summary>
    public partial class ReturnBorrow : Window
    {
        private readonly BorrowService borrowService = new BorrowService();

        public DateTime br_date_time_old;
        public string mid;
        public string bid;
        public DateTime BrDateRt { get; set; }
        public int br_fine { get; set; }
        public Action fetchData;
        public ReturnBorrow(DateTime br_date,string mid,string bid,Action fetchData)
        {
            InitializeComponent();
            this.br_date_time_old = br_date;
            this.mid = mid;
            this.bid = bid;
            this.fetchData = fetchData;

  
        }

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            BrDateRt = (DateTime)DateReturnPicker.SelectedDate;

            var returnData = new BorrowReturn
            {
                br_date_br_old = br_date_time_old,
                m_user_old = mid,
                b_id_old = bid,
                br_fine = br_fine,
                br_date_rt = BrDateRt
            };

            string message = await borrowService.ReturnBorrowData(returnData);

            fetchData();
            
            MessageBox.Show(message);

            this.Close();
        }
    }
}
