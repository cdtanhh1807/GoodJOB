using GoodJOB;
using GoodJOB.Home;
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

namespace GoodJOB
{
    /// <summary>
    /// Interaction logic for PostSeekerUC.xaml
    /// </summary>
    public partial class PostSeekerUC : UserControl
    {
        ConnectSql sql = new ConnectSql();

        PostSeeker? postSeeker;

        Account account;

        string role = "";

        public PostSeekerUC(PostSeeker postSeeker, string role)
        {
            InitializeComponent();
            this.postSeeker = postSeeker;
            this.role = role;

            Get();
        }

        public PostSeekerUC(Account account)
        {
            InitializeComponent();
            this.account = account;
        }

        private void Get()
        {
            if (role == "Company")
            {
                txbJob.Text = postSeeker.Job;
                txbField.Text = postSeeker.Field;
                txbExp.Text = postSeeker.Exp;
                txbTime.Text = postSeeker.Time;
                txbSalary.Text = postSeeker.Salary;
                txbSkill.Text = postSeeker.Skill;
                btnPost.Visibility = Visibility.Visible;
                btnCheckInfor.Visibility = Visibility.Visible;
                btnPost.Visibility = Visibility.Collapsed;
                btnExit.Visibility = Visibility.Visible;
            }
        }

        private void btnPost_Click(object sender, RoutedEventArgs e)
        {
            PostSeeker postSeeker = new PostSeeker(txbJob.Text, txbField.Text, txbTime.Text, txbExp.Text, txbSalary.Text, txbSkill.Text, account.AccountID);
            if (sql.GetPostSeeker(postSeeker))
            {
                MessageBox.Show("Đã đăng bài !");
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);

            if (parentWindow != null)
            {
                parentWindow.Close();
            }
        }

        private void btnCheckInfor_Click(object sender, RoutedEventArgs e)
        {
            CheckInforWD checkInforWD = new CheckInforWD(postSeeker.AccountID, "Company");
            checkInforWD.ShowDialog();
        }
    }
}
