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
using LiveCharts.Wpf.Charts.Base;

namespace GoodJOB
{
    /// <summary>
    /// Interaction logic for SeekerRecruiUC.xaml
    /// </summary>
    public partial class SeekerRecruiUC : UserControl
    {
        double maxScroll;
        double pageSize;
        int maxIndex;
        int currPage = 1;

        JobPost jobPost = new JobPost();

        Account account;

        string fieldCurr = "";

        public SeekerRecruiUC(Account account)
        {
            InitializeComponent();
            this.account = account;
        }

        private void GetBegin(ComboBox cbb)
        {
            cbb.SelectedIndex = 0;
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

        private void wrap_Loaded(object sender, RoutedEventArgs e)
        {
            LoadWrap();
        }

        bool checkSearch = false;

        private void CheckSearch()
        {
            if (cbbField.SelectedIndex != 0 || cbbSalary.SelectedIndex != 0 || cbbExp.SelectedIndex != 0 || cbbTypeOfWork.SelectedIndex != 0 || cbbLocation.SelectedIndex != 0) checkSearch = true;
            else checkSearch = false;
        }

        private void LoadWrap()
        {
            HashSet<string> hsField = new HashSet<string>();

            SeekerDAO seekerDAO = new SeekerDAO(account.AccountID);
            List<JobPostUC> list = seekerDAO.LoadJobPost(ref hsField);

            cbbField.ItemsSource = null;
            cbbField.ItemsSource = hsField;
            GetBegin(cbbField);

            ClearWrapPost();

            foreach (JobPostUC jobPostUC in list)
            {
                wrap.Children.Add(jobPostUC);
                SubscribeToButtonClick(jobPostUC);
            }

            DelayWrap();
        }

        public void SubscribeToButtonClick(UserControl userControl)
        {
            if (userControl is JobPostUC us)
            {
                us.ButtonClicked += UserControl_ButtonClicked!;
            }
        }

        private void UserControl_ButtonClicked(object sender, EventArgs e)
        {
            if (sender is JobPostUC us)
            {
                fieldCurr = us.jobPost.Field;
                cbbField.SelectedValue = fieldCurr;
                SearchJob(fieldCurr);
                checkSearch = true;
                jobPost.JobName = txblDetailJobName.Text = us.jobPost.JobName;
                txblDetailCompanyName.Text = us.companyName;
                jobPost.Exp = txblDetailExp.Text = us.jobPost.Exp;
                jobPost.Salary = txblDetailSalary.Text = us.jobPost.Salary;
                jobPost.Description = txblDetailDescription.Text = us.jobPost.Description;
                jobPost.Field = us.jobPost.Field;
                jobPost.WorkingTime = us.jobPost.WorkingTime;
                jobPost.TypeOfWork = us.jobPost.TypeOfWork;
                jobPost.Skill = us.jobPost.Skill;
                jobPost.NumOfRecrui = us.jobPost.NumOfRecrui;
                jobPost.DateOfPost = us.jobPost.DateOfPost;
                jobPost.PostID = us.jobPost.PostID;
                jobPost.PostingDate = us.jobPost.PostingDate;
                jobPost.AccountID = us.jobPost.AccountID;
                jobPost.Welfare = us.jobPost.Welfare;

                btnApply.Visibility = Visibility.Visible;
            }
        }

        private void ClearWrapPost()
        {
            wrap.Children.Clear();

            txblDetailJobName.Text = "";
            txblDetailCompanyName.Text = "";
            txblDetailExp.Text = "";
            txblDetailSalary.Text = "";
            txblDetailDescription.Text = "";

            btnApply.Visibility = Visibility.Collapsed;
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

        private void SearchJob(string field)
        {
            if (txbJobName.Text != "Nhập tên công việc")
            {
                GetBegin(cbbSalary);
                GetBegin(cbbExp);
                GetBegin(cbbTypeOfWork);
                GetBegin(cbbLocation);
                GetBegin(cbbField);
            }

            List<JobPostUC> list;

            if (field == "")
            {
                SeekerDAO seekerDAO = new SeekerDAO(account.AccountID);
                list = seekerDAO.SearchJob(txbJobName.Text, cbbField.Text, cbbExp.Text, cbbSalary.Text, cbbTypeOfWork.Text, cbbLocation.Text);
            }
            else
            {
                SeekerDAO seekerDAO = new SeekerDAO(account.AccountID);
                list = seekerDAO.SearchJob(txbJobName.Text, field, cbbExp.Text, cbbSalary.Text, cbbTypeOfWork.Text, cbbLocation.Text);
            }

            if (list.Count > 0)
            {
                btnApply.Visibility = Visibility.Collapsed;
                ClearWrapPost();
                foreach (JobPostUC jobPostUC in list)
                {
                    wrap.Children.Add(jobPostUC);
                    SubscribeToButtonClick(jobPostUC);
                }

                DelayWrap();
            }
            else
            {
                LoadWrap();
                ClearWrapPost();
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {   
            SearchJob("");
        }

        private void txbJobName_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox txb = (TextBox)sender;
            if (txb.Text == "Nhập tên công việc") txb.Text = string.Empty;
        }

        private void txbJobName_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox txb = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(txb.Text)) txb.Text = "Nhập tên công việc";
        }

        private void btnApply_Click(object sender, RoutedEventArgs e)
        {
            PostReviewWD postReviewWD = new PostReviewWD(jobPost, account);
            postReviewWD.ShowDialog();

            CheckSearch();
            if (checkSearch == true) SearchJob(fieldCurr);
            else LoadWrap();
            
        }

        private void btnChart_Click(object sender, RoutedEventArgs e)
        {
            ChartUC chartUC = new ChartUC();
            Grid.SetRow(chartUC, 0);
            Grid.SetRowSpan(chartUC, 3);
            main.Children.Add(chartUC);

        }

        private void main_Loaded(object sender, RoutedEventArgs e)
        {
            GetBegin(cbbSalary);
            GetBegin(cbbExp);
            GetBegin(cbbTypeOfWork);
            GetBegin(cbbLocation);
        }

        private void btnPerson_Click(object sender, RoutedEventArgs e)
        {
            TopCVSeekerUC topCVSeekerUC = new TopCVSeekerUC();
            Grid.SetRow(topCVSeekerUC, 0);
            Grid.SetRowSpan(topCVSeekerUC, 3);
            main.Children.Add(topCVSeekerUC);
        }

        private void btnPost_Click(object sender, RoutedEventArgs e)
        {
            PostSeekerUC postSeekerUC = new PostSeekerUC(account);
            Grid.SetRow(postSeekerUC, 0);
            Grid.SetRowSpan(postSeekerUC, 3);
            main.Children.Add(postSeekerUC);
        }
    }
}
