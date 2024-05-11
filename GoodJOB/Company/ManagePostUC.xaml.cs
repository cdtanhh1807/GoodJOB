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
using GoodJOB.DAO;
using GoodJOB.Home;

namespace GoodJOB
{
    /// <summary>
    /// Interaction logic for ManagePostUC.xaml
    /// </summary>
    public partial class ManagePostUC : UserControl
    {
        public event EventHandler? btnEditClicked;

        double maxScroll;
        double pageSize;
        int maxIndex;
        int currPage = 1;

        Account account;

        JobPost? jobPost;

        public ManagePostUC(Account account)
        {
            InitializeComponent();
            this.DataContext = this;
            this.account = account;
        }

        private void scr_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {

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

        private void scr_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            e.Handled = true;
        }

        private void GetWrap()
        {
            PostDAO postDAO = new PostDAO(account.AccountID);
            List<EditPostUC> list = postDAO.LoadEditJob();

            foreach (EditPostUC editPostUc in list)
            {
                wrap.Children.Add(editPostUc);
                SubscribeToButtonClick(editPostUc);
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

        public void SubscribeToButtonClick(UserControl userControl)
        {
            if (userControl is EditPostUC us)
            {
                us.btnEditClicked += UserControl_EditClicked!;
                us.btnDeleteClicked += UserControl_DeleteClicked!;
            }
        }

        public void IsEditedClick(UserControl userControl)
        {
            if (userControl is PostUC us)
            {
                us.IsEdited += Us_IsEdited;
            }
        }

        private void Us_IsEdited(object? sender, EventArgs e)
        {
            wrap.Children.Clear();
            GetWrap();
        }

        private void UserControl_EditClicked(object sender, EventArgs e)
        {
            if (sender is EditPostUC us)
            {
                this.jobPost = us.jobPost;
                PostUC postUC = new PostUC(account, jobPost, true);
                IsEditedClick(postUC);
                btnEditClicked?.Invoke(postUC, EventArgs.Empty);
            }
        }

        private void UserControl_DeleteClicked(object sender, EventArgs e)
        {
            if (sender is EditPostUC us)
            {
                MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa bài đăng này ?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    PostDAO postDAO = new PostDAO(us.jobPost.PostID);
                    if (postDAO.DeletePost())
                    {
                        wrap.Children.Clear();
                        GetWrap();
                        MessageBox.Show("Đã xóa bài đăng !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else MessageBox.Show("Xóa bài đăng không thành công !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void scr_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
