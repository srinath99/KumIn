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
using System.Windows.Threading;
using System.Data;

namespace KumIn_WPF
{
    /// <summary>
    /// Interaction logic for Primary.xaml
    /// </summary>
    public partial class Primary : Window
    {
        DateTime timeNow = DateTime.Now;
        DataTable dummyTable = new DataTable();

        public Primary()
        {
            InitializeComponent();
            lblTime.Content = timeNow.ToString("f");

            DispatcherTimer myTimer = new DispatcherTimer();
            myTimer.Interval = new TimeSpan(0, 0, 15);
            myTimer.Tick += new EventHandler(myTimer_Tick);
            myTimer.Start();
        }

        private void myTimer_Tick(object sender, object e)
        {
            timeNow = DateTime.Now;
            lblTime.Content = timeNow.ToString("f");
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnAddNewStudent_Click(object sender, RoutedEventArgs e)
        {
            AddStudent myAddStudent = new AddStudent();
            myAddStudent.Show();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            DeleteStudent myDeleteStudent = new DeleteStudent();
            myDeleteStudent.Show();
        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            DataRow dummyRow = dummyTable.NewRow();

            if (!dummyTable.Columns.Contains("FirstName"))
            {
                dummyTable.Columns.Add("FirstName");
            }
            if (!dummyTable.Columns.Contains("LastName"))
            {
                dummyTable.Columns.Add("LastName");
            }
            if (!dummyTable.Columns.Contains("InTime"))
            {
                dummyTable.Columns.Add("InTime");
            }

            dummyRow["FirstName"] = "Srinath";
            dummyRow["LastName"] = "Nandakumar";
            dummyRow["InTime"] = DateTime.Now.ToString("t");


            dgdListing.ItemsSource = dummyTable.DefaultView;
            dummyTable.Rows.Add(dummyRow);
        }
    }
}
