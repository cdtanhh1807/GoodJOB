using GoodJOB.DAO;
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
    /// Interaction logic for CheckPostSeekerUC.xaml
    /// </summary>
    public partial class CheckPostSeekerUC : UserControl
    {


        double maxScroll;
        double pageSize;
        int maxIndex;
        int currPage = 1;

        Account account;

        ConnectSql sql = new ConnectSql();

        public CheckPostSeekerUC(Account account)
        {
            InitializeComponent();
            this.account = account;
        }

        private void SubscribeToButtonClick(UserControl us)
        {
            if (us is ItemPostSeerUC uc)
            {
                uc.btnClicked += Uc_btnClicked;
            }
        }

        private void Uc_btnClicked(object? sender, EventArgs e)
        {
            if (sender is ItemPostSeerUC uc)
            {
                PostSeekerUC postSeekerUC = new PostSeekerUC(uc.PostSeeker, "Company");
                PostSeekerWD postSeekerWD = new PostSeekerWD(postSeekerUC);
                postSeekerWD.Show();
            }
        }

        private void GetWrap()
        {
            List<ItemPostSeerUC> list = sql.LoadPostSeeker();

            foreach (ItemPostSeerUC item in list)
            {
                wrap.Children.Add(item);
                SubscribeToButtonClick(item);
            }

            Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Render, new Action(() =>
            {
                maxScroll = scr.ScrollableHeight;
                pageSize = scr.ViewportHeight;
                maxIndex = (int)(maxScroll / pageSize) + 1;
            }));
        }

        private void wrap_Loaded(object sender, RoutedEventArgs e)
        {
            GetWrap();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            maxScroll = scr.ScrollableHeight;
            pageSize = scr.ViewportHeight;
            maxIndex = (int)(maxScroll / pageSize) + 1;
            txbl.Text = currPage.ToString();
        }

        private void GetScroll()
        {
            double temp = currPage - 1;
            temp = temp * pageSize;
            scr.ScrollToVerticalOffset(temp);
        }

        private void btnPre_Click(object sender, RoutedEventArgs e)
        {
            if (currPage == 1)
            {
                scr.ScrollToVerticalOffset(0);
                txbl.Text = "1";
            }
            else
            {
                currPage--;
                GetScroll();
                txbl.Text = currPage.ToString();

            }
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            if (currPage == maxIndex)
            {
                if (scr.VerticalOffset < maxScroll)
                {
                    scr.ScrollToVerticalOffset(maxScroll);
                    txbl.Text = (Convert.ToInt16(txbl.Text) + 1).ToString();
                }
                else return;
            }
            else if (currPage < maxIndex)
            {
                currPage++;
                GetScroll();
                txbl.Text = currPage.ToString();
            }
        }
    }
}
