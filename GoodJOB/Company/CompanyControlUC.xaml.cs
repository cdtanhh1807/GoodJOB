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
using GoodJOB.Home;

namespace GoodJOB
{
    /// <summary>
    /// Interaction logic for CompanyControlUC.xaml
    /// </summary>
    public partial class CompanyControlUC : UserControl
    {
        HomeWD? homeWD;

        Account account;

        public HomeWD? HomeWD { get => homeWD; set => homeWD = value; }

        public CompanyControlUC(HomeWD homeWD, Account account)
        {
            InitializeComponent();
            this.HomeWD = homeWD;
            homeWD.btnCurr = btnInfor;
            homeWD.btnCurr.IsEnabled = false;
            this.account = account;
        }

        private void btnInfor_Click(object sender, RoutedEventArgs e)
        {
            homeWD!.GetButton(sender, e);
            CompanyInforUC companyInforUC = new CompanyInforUC(account);
            homeWD.GetUC(companyInforUC);
        }

        private void btnRecrui_Click(object sender, RoutedEventArgs e)
        {
            homeWD!.GetButton(sender, e);
            CompanyRecruiUC companyRecruiUC = new CompanyRecruiUC(account);
            homeWD.GetUC(companyRecruiUC);
        }

        private void btnManageRectui_Click(object sender, RoutedEventArgs e)
        {
            homeWD!.GetButton(sender, e);
            CompanyManageRecruiUC companyManageRecruiUC = new CompanyManageRecruiUC(account);
            homeWD.GetUC(companyManageRecruiUC);
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            if (window != null && window is Window) window.Close();
        }

        private void btnChat_Click(object sender, RoutedEventArgs e)
        {
            homeWD!.GetButton(sender, e);
            CompanyChat companyChat = new CompanyChat(account);
            homeWD.GetUC(companyChat);
        }
    }
}
