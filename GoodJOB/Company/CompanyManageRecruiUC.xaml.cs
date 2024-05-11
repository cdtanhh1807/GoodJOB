using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
    /// Interaction logic for CompanyManageRecruiUC.xaml
    /// </summary>
    public partial class CompanyManageRecruiUC : UserControl
    {
        double maxScroll;
        double pageSize;
        int maxIndex;
        int currPage = 1;

        double maxScrollResume;
        double pageSizeResume;
        int maxIndexResume;
        int currPageResume = 1;

        Account account;

        int postIDCurr;

        public CompanyManageRecruiUC(Account account)
        {
            InitializeComponent();
            this.account = account;
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

        private void GetScrollResume()
        {
            double temp = currPageResume - 1;
            temp = temp * pageSizeResume;
            scrResume.ScrollToVerticalOffset(temp);
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

        public void SubscribeToButtonClick(UserControl userControl)
        {
            if (userControl is RecruiUC us)
            {
                us.ButtonClicked += UserControl_ButtonClicked!;
            }
        }

        public void SubscribeToButtonResumeClick(UserControl userControl)
        {
            if (userControl is ResumeApplyUC us)
            {
                us.ButtonResumeClicked += UserControl_ButtonResumeClicked!;
                us.AcceptOrRefusePerformed += UserControl_AcceptOrRefusePerformed!;
            }
        }

        

        private void UserControl_ButtonClicked(object sender, EventArgs e)
        {
            if (sender is RecruiUC us)
            {
                foreach (RecruiUC control in stack.Children)
                {
                    control.GetButton();
                }
                (sender as RecruiUC)!.Turn = 1;

                postIDCurr = us.jobPostRecrui.PostID;
                stackResume.Children.Clear();
                GetStackResume(postIDCurr);

                maxScrollResume = scrResume.ScrollableHeight;
                pageSizeResume = scrResume.ViewportHeight;
                maxIndexResume = (int)(maxScrollResume / pageSizeResume) + 1;
                txblResume.Text = currPageResume.ToString();
            }
        }

        private void UserControl_ButtonResumeClicked(object sender, EventArgs e)
        {
            if (sender is ResumeApplyUC us)
            {
                foreach (ResumeApplyUC control in stackResume.Children)
                {
                    control.GetButton();
                }
                (sender as ResumeApplyUC)!.Turn = 1;

                Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Render, new Action(() =>
                {
                    ResumeRecruiWD resumeRecruiWD = new ResumeRecruiWD(us);
                    resumeRecruiWD.ShowDialog();
                }));
            }
        }

        private void UserControl_AcceptOrRefusePerformed(object sender, EventArgs e)
        {
            if (sender is ResumeApplyUC us)
            {
                stackResume.Children.Clear();
                GetStackResume(postIDCurr);
                //CleanInfor();
            }
        }

        //private void CleanInfor()
        //{
        //    txbBirthday.Text = "";
        //    txbName.Text = "";
        //    txbSex.Text = "";
        //}

        private void stack_Loaded(object sender, RoutedEventArgs e)
        {
            GetStack();
        }

        private void GetStack()
        {
            RecruiDAO recruiDAO = new RecruiDAO(account.AccountID);
            List<RecruiUC> list = recruiDAO.LoadJobPostRecrui();

            foreach (RecruiUC recruiUC in list)
            {
                stack.Children.Add(recruiUC);
                SubscribeToButtonClick(recruiUC);
            }

            Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Render, new Action(() =>
            {
                maxScroll = scr.ScrollableHeight;
                pageSize = scr.ViewportHeight;
                maxIndex = (int)(maxScroll / pageSize) + 1;
            }));
        }

        private void GetStackResume(int postID)
        {
            RecruiDAO recruiDAO = new RecruiDAO(postID);
            List<ResumeApplyUC> list = recruiDAO.LoadRecrui();

            foreach (ResumeApplyUC resumeApplyUC in list)
            {
                stackResume.Children.Add(resumeApplyUC);
                SubscribeToButtonResumeClick(resumeApplyUC);
            }

            Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Render, new Action(() =>
            {
                maxScrollResume = scrResume.ScrollableHeight;
                pageSizeResume = scrResume.ViewportHeight;
                maxIndexResume = (int)(maxScrollResume / pageSizeResume) + 1;
            }));
        }

        //private void btnCheckCV_Click(object sender, RoutedEventArgs e)
        //{
        //    if (recrui != null && txbName.Text != "")
        //    {
        //        byte[]? fileContent = connectSql.DownLoadCV(recrui.PostID, recrui.SeekerID);
        //        if (fileContent != null)
        //        {
        //            string tempFilePath = System.IO.Path.GetTempFileName();
        //            File.WriteAllBytes(tempFilePath, fileContent!);

        //            string edgePath = @"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe";
        //            Process.Start(edgePath, tempFilePath);
        //        }
        //    }
        //}

        private void scr_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            e.Handled = true;
        }

        private void btnNextResume_Click(object sender, RoutedEventArgs e)
        {
            if (currPageResume == maxIndexResume)
            {
                if (scrResume.VerticalOffset < maxScrollResume)
                {
                    scrResume.ScrollToVerticalOffset(maxScrollResume);
                    txblResume.Text = (Convert.ToInt16(txblResume.Text) + 1).ToString();
                }
                else return;
            }
            else if (currPageResume < maxIndexResume)
            {
                currPageResume++;
                GetScrollResume();
                txblResume.Text = currPageResume.ToString();
            }
        }

        private void btnPreResume_Click(object sender, RoutedEventArgs e)
        {
            if (currPageResume == 1)
            {
                scrResume.ScrollToVerticalOffset(0);
                txblResume.Text = "1";
            }
            else
            {
                currPageResume--;
                GetScrollResume();
                txblResume.Text = currPageResume.ToString();
            }
        }


        //private void btnCheckInfor_Click(object sender, RoutedEventArgs e)
        //{
        //    if (recrui != null && txbName.Text != "")
        //    {
        //        CheckInforWD checkInforWD = new CheckInforWD(recrui.SeekerID, "Company");
        //        checkInforWD.Show();
        //    }
        //}
    }
}
