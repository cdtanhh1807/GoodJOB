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
    /// Interaction logic for CompanyRecruiUC.xaml
    /// </summary>
    public partial class CompanyRecruiUC : UserControl
    {
        public Button? btnCurr;

        Account account;

        private void GetButton(object sender)
        {
            btnCurr!.IsEnabled = true;
            btnCurr = (Button)sender;
            btnCurr.IsEnabled = false;
        }

        public CompanyRecruiUC(Account account)
        {
            InitializeComponent();
            btnCurr = btnPost;
            btnCurr.IsEnabled = false;
            mainGrid.Children.Clear();
            PostUC postUC = new PostUC(account);
            GetUC(postUC);
            this.account = account;
        }

        private void ChangeStyleButton(object sender)
        {
            Style ctStyleNon = (Style)this.Resources["btnNonSelect"];
            btnCurr!.Style = ctStyleNon;

            Style ctStyleSelect = (Style)this.Resources["btnSelect"];
            Button btn = (Button)sender;
            btn.Style = ctStyleSelect;
        }

        public void GetUC(UserControl uc)
        {
            if (uc is not PostUC)
            {
                mainGrid.Children.Clear();
            }
            Grid.SetRow(uc, 1);
            Grid.SetColumn(uc, 0);
            mainGrid.Children.Add(uc);
        }

        private void btnPost_Click(object sender, RoutedEventArgs e)
        {
            ChangeStyleButton(sender);
            GetButton(sender);
            PostUC postUC = new PostUC(account);
            GetUC(postUC);
        }

        private void btnManagePost_Click(object sender, RoutedEventArgs e)
        {
            ChangeStyleButton(sender);
            GetButton(sender);
            ManagePostUC managePostUC = new ManagePostUC(account);
            SubscribeToButtonClick(managePostUC);
            GetUC(managePostUC);
        }

        public void SubscribeToButtonClick(UserControl userControl)
        {
            if (userControl is ManagePostUC us)
            {
                us.btnEditClicked += UserControl_EditClicked!;
            }
        }

        private void UserControl_EditClicked(object sender, EventArgs e)
        {
            if (sender is PostUC us)
            {
                GetUC(us);
            }
        }

        private void btnChart_Click(object sender, RoutedEventArgs e)
        {
            ChangeStyleButton(sender);
            GetButton(sender);
            ChartUC chartUC = new ChartUC();
            Grid.SetRow(chartUC, 0);
            Grid.SetRowSpan(chartUC, 3);
            main.Children.Add(chartUC);
        }

        private void btnTopSeeker_Click(object sender, RoutedEventArgs e)
        {
            ChangeStyleButton(sender);
            GetButton(sender);
            TopCVCompanyUC topCVCompanyUC = new TopCVCompanyUC();
            GetUC(topCVCompanyUC);
        }

        private void btnPostSeeker_Click(object sender, RoutedEventArgs e)
        {
            ChangeStyleButton(sender);
            GetButton(sender);
            CheckPostSeekerUC check = new CheckPostSeekerUC(account);
            GetUC(check);
        }
    }
}
