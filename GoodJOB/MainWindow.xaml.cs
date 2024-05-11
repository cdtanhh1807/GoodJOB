using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GoodJOB.Home;

namespace GoodJOB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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

        private void btnForget_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            SignUpWD signUpWD = new SignUpWD();
            signUpWD.ShowDialog();
        }

        private void Login()
        {
            string infor = "";
            Account account = new Account(txbUserName.Text, pwPass.Password);
            AccountDAO accountDAO = new AccountDAO(account);
            if (accountDAO.Login(ref account, ref infor))
            {
                HomeWD homeWD = new HomeWD(account.Role, account);
                this.Hide();
                homeWD.ShowDialog();
                this.Show();
            }
            else MessageBox.Show(infor, "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Login();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var storyboard = FindResource("WindowLoadAnimation") as Storyboard;
            storyboard!.Begin();
        }

        private void txbUserName_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (pwPass.Password != null && txbUserName.Text != "") Login();
            }
        }

        private void pwPass_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (pwPass.Password != null && txbUserName.Text != "") Login();
            }
        }
    }
}