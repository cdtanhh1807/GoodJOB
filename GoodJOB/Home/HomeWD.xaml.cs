using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
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
using static System.Net.Mime.MediaTypeNames;

namespace GoodJOB
{
    /// <summary>
    /// Interaction logic for HomeWD.xaml
    /// </summary>
    public partial class HomeWD : Window
    {
        private string role = "";

        public Button? btnCurr;

        Account? account;

        public Account? Account { get => account; set => account = value; }

        public HomeWD(string role, Account account)
        {
            InitializeComponent();
            this.role = role;
            this.Account = account;
            LoadControl();
        }

        public void GetButton(object sender, RoutedEventArgs e)
        {
            btnCurr!.IsEnabled = true;
            btnCurr = (Button)sender;
            btnCurr.IsEnabled = false;
        }

        public void GetBtnChat(Button sender)
        {
            btnCurr!.IsEnabled = true;
            btnCurr = sender;
            btnCurr.IsEnabled = false;
        }

        public void GetUC(UserControl uc)
        {
            mainWork.Children.Clear();
            Grid.SetRow(uc, 0);
            Grid.SetColumn(uc, 1);
            mainWork.Children.Add(uc);
        }

        private void GetUCBegin(UserControl ucControl, UserControl ucWork)
        {
            Grid.SetRow(ucControl, 0);
            Grid.SetColumn(ucControl, 0);
            mainControl.Children.Add(ucControl);

            Grid.SetRow(ucWork, 0);
            Grid.SetColumn(ucWork, 1);
            mainWork.Children.Add(ucWork);
        }
        
        private void LoadControl()
        {
            if (role == "Company")
            {
                CompanyControlUC companyControlUC = new CompanyControlUC(this, Account!);
                CompanyInforUC companyInforUC = new CompanyInforUC(Account!);
                GetUCBegin(companyControlUC, companyInforUC);
            }
            else
            {
                SeekerControlUC seekerControlUC = new SeekerControlUC(this, Account!);
                SeekerInforUC seekerInforUC = new SeekerInforUC(Account!);
                GetUCBegin(seekerControlUC, seekerInforUC);
            }
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}