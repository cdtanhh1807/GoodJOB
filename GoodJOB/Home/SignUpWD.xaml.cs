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
using GoodJOB.Home;

namespace GoodJOB
{
    /// <summary>
    /// Interaction logic for SignUpWD.xaml
    /// </summary>
    public partial class SignUpWD : Window
    {
        private string role = "";
        public SignUpWD()
        {
            InitializeComponent();
        }

        private void cbCompany_Checked(object sender, RoutedEventArgs e)
        {
            role = "Company";
            cbSeeker.IsChecked = false;
        }

        private void cbSeeker_Checked(object sender, RoutedEventArgs e)
        {
            role = "Seeker";
            cbCompany.IsChecked = false;
        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            Account account = new Account(txbUserName.Text, pwPass.Password, role, txbAccID.Text);
            AccountDAO accountDAO = new AccountDAO(account);
            if (accountDAO.SignUp(account))
            {
                if (role == "Company")
                {
                    if (accountDAO.AddCompany()) this.Close();
                }
                else if (role == "Seeker")
                {
                    if (accountDAO.AddSeeker()) this.Close();
                }
            }
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void txbAccID_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox txb = (TextBox)sender;
            if (txb.Text == "Account ID của bạn") txb.Text = string.Empty;
        }

        private void txbAccID_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox txb = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(txb.Text)) txb.Text = "Account ID của bạn";
        }

        private void txbUserName_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox txb = (TextBox)sender;
            if (txb.Text == "Tên đăng nhập") txb.Text = string.Empty;
        }

        private void txbUserName_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox txb = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(txb.Text)) txb.Text = "Tên đăng nhập";
        }

        private void pwPass_GotFocus(object sender, RoutedEventArgs e)
        {
            txblPass.Visibility = Visibility.Collapsed;
        }

        private void pwPass_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(pwPass.Password)) txblPass.Visibility = Visibility.Visible;
        }
    }
}
