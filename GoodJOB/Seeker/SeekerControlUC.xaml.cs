using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    /// Interaction logic for SeekerControlUC.xaml
    /// </summary>
    public partial class SeekerControlUC : UserControl
    {
        HomeWD? homeWD;

        Account? account;

        public HomeWD? HomeWD { get => homeWD; set => homeWD = value; }

        public SeekerControlUC(HomeWD homeWD, Account account)
        {
            InitializeComponent();
            this.HomeWD = homeWD;
            homeWD.btnCurr = btnInfor;
            homeWD.btnCurr.IsEnabled = false;
            this.account = account;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            if (window != null && window is Window) window.Close();
        }

        private void btnRecrui_Click(object sender, RoutedEventArgs e)
        {
            homeWD!.GetButton(sender, e);
            SeekerRecruiUC seekerRecruiUC = new SeekerRecruiUC(account!);
            homeWD.GetUC(seekerRecruiUC);
        }

        private void btnInfor_Click(object sender, RoutedEventArgs e)
        {
            homeWD!.GetButton(sender, e);
            SeekerInforUC seekerInforUC = new SeekerInforUC(account!);
            homeWD.GetUC(seekerInforUC);
        }

        private void btnManageRectui_Click(object sender, RoutedEventArgs e)
        {
            homeWD!.GetButton(sender, e);
            SeekerManageRecrui seekerManageRecrui = new SeekerManageRecrui(account!, this);
            homeWD.GetUC(seekerManageRecrui);
        }

        public void btnChat_Click(object sender, RoutedEventArgs e)
        {
            homeWD!.GetButton(sender, e);
            SeekerChatUC seekerChatUC = new SeekerChatUC(account!);
            homeWD.GetUC(seekerChatUC);
        }

        public void GetBtnChat(string companyName)
        {
            homeWD!.GetBtnChat(btnChat);
            SeekerChatUC seekerChatUC = new SeekerChatUC(account!.AccountID, companyName);
            homeWD.GetUC(seekerChatUC);
        }
    }
}
