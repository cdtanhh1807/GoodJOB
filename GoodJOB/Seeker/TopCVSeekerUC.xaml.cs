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
    /// Interaction logic for TopCVSeekerUC.xaml
    /// </summary>
    public partial class TopCVSeekerUC : UserControl
    {
        double maxScroll;
        double pageSize;
        int maxIndex;
        int currPage = 1;

        public TopCVSeekerUC()
        {
            InitializeComponent();
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

        private void wrap_Loaded(object sender, RoutedEventArgs e)
        {
            LoadWrap();
            DateTime dt = DateTime.Now;
            txblDay.Text = "Cập nhật ngày " + dt.ToString("dd/MM/yyyy");
        }

        private void LoadWrap()
        {
            SeekerDAO seekerDAO = new SeekerDAO();
            List<TopSeekerUC> list = seekerDAO.LoadTopSeeker(false);

            foreach (TopSeekerUC topSeekerUC in list)
            {
                wrap.Children.Add(topSeekerUC);
                SubscribeToButtonClick(topSeekerUC);
            }

            DelayWrap();
        }

        public void SubscribeToButtonClick(UserControl userControl)
        {
            if (userControl is TopSeekerUC us)
            {
                us.ButtonClicked += Us_ButtonClicked;
            }
        }

        private void Us_ButtonClicked(object? sender, EventArgs e)
        {
            if (sender is TopSeekerUC us)
            {
                CheckInforWD checkInforWD = new CheckInforWD(us.Seeker!.AccountID, "Company");
                checkInforWD.ShowDialog();
            }
        }

        private void DelayWrap()
        {
            Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Render, new Action(() =>
            {
                maxScroll = scr.ScrollableHeight;
                pageSize = scr.ViewportHeight;
                maxIndex = (int)(maxScroll / pageSize) + 1;
            }));
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            DependencyObject parent = VisualTreeHelper.GetParent(this);
            if (parent is Panel panel)
            {
                panel.Children.Remove(this);
            }
            else if (parent is ContentControl contentControl)
            {
                contentControl.Content = null;
            }
        }
    }
}
