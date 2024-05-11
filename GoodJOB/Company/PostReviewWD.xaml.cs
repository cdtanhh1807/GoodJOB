using GoodJOB.DAO;
using GoodJOB.Home;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace GoodJOB
{
    /// <summary>
    /// Interaction logic for PostReviewWD.xaml
    /// </summary>
    public partial class PostReviewWD : Window
    {
        JobPost jobPost;

        Account account;

        CV? cv;

        Company? company;

        public PostReviewWD(JobPost jobPost, Account account)
        {
            InitializeComponent();
            this.jobPost = jobPost;
            this.account = account;
            GetApply();
        }

        private void GetApply()
        {
            CompanyDAO companyDAO = new CompanyDAO(jobPost.AccountID);
            company = companyDAO.GetInforCompany();
            txblCompanyName.Text = companyDAO.GetNameCompany();
            txblField.Text = jobPost.Field;
            txblJobName.Text = jobPost.JobName;
            txblExp.Text = jobPost.Exp;
            txblSalary.Text = jobPost.Salary;
            txbSkill.Text = jobPost.Skill;
            txbDescription.Text = jobPost.Description;
            txblTypeOfWork.Text = jobPost.TypeOfWork;
            txblWorkingTime.Text = jobPost.WorkingTime;
            txblPostingDate.Text += jobPost.PostingDate.ToString("dd/MM/yyyy");
            txblNumOfRecrui.Text = jobPost.NumOfRecrui.ToString();
            txbWelfare.Text = jobPost.Welfare;

            if (account.Role == "Company")
            {
                btnRecrui.IsEnabled = false;
            }

            GetAvt();
        }

        private void GetAvt()
        {
            if (company!.AvtName != "" && company.AvtContent != null)
            {
                CompanyDAO companyDAO = new CompanyDAO(company.AccountID);
                byte[]? content = companyDAO.DownloadAvtCompany();

                using (MemoryStream ms = new MemoryStream(content!))
                {
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.StreamSource = ms;
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.EndInit();


                    img.Source = bitmap;
                }
            }
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void PostReviewWDAni_Loaded(object sender, RoutedEventArgs e)
        {
            var storyboard = FindResource("WindowLoadAnimation") as Storyboard;
            storyboard!.Begin();
        }

        private void btnRecrui_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
            if (openFileDialog.ShowDialog() == true)
            {

                string filePath = openFileDialog.FileName;
                byte[] fileBytes = File.ReadAllBytes(filePath);

                if (fileBytes == null || filePath == "") MessageBox.Show("CV chưa được tải lên !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);

                cv = new CV(filePath, fileBytes);
            }

            if (cv != null)
            {
                PostDAO postDAO = new PostDAO(jobPost.AccountID, jobPost.PostID);
                if (postDAO.ApplyJob(account.AccountID, cv.FilePath, cv.FileBytes!)) MessageBox.Show("Đã gửi đơn ứng tuyển !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                else MessageBox.Show("Gửi đơn ứng tuyển không thành công !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();
            }
            else MessageBox.Show("Hãy thêm CV !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void btnExit_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnViewCompany_Click(object sender, RoutedEventArgs e)
        {
            CheckInforWD checkInforWD = new CheckInforWD(jobPost.AccountID, "Seeker");
            this.Hide();
            checkInforWD.ShowDialog();
            this.Show();
        }
    }
}
