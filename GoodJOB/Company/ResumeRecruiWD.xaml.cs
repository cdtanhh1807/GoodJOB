using GoodJOB.DAO;
using GoodJOB.Home;
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
using System.Windows.Shapes;

namespace GoodJOB
{
    /// <summary>
    /// Interaction logic for ResumeRecruiWD.xaml
    /// </summary>
    public partial class ResumeRecruiWD : Window
    {
        ResumeApplyUC resumeApplyUC;

        private void Get()
        {
            txbName.Text = resumeApplyUC.seeker.Name;
            txbBirthday.Text = resumeApplyUC.seeker.Birthday;
            txbSex.Text = GetSex(resumeApplyUC.seeker.Sex);
            txbPhone.Text = resumeApplyUC.seeker.Phone;
        }

        public ResumeRecruiWD(ResumeApplyUC resumeApplyUC)
        {
            InitializeComponent();
            this.resumeApplyUC = resumeApplyUC;
            Get();
        }

        private string GetSex(bool sex)
        {
            if (sex) return "Nam";
            return "Nữ";
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnCheckCV_Click(object sender, RoutedEventArgs e)
        {
            if (resumeApplyUC.recrui != null && txbName.Text != "")
            {
                RecruiDAO recruiDAO = new RecruiDAO(resumeApplyUC.recrui);
                byte[]? fileContent = recruiDAO.DownLoadCV();
                if (fileContent != null)
                {
                    string tempFilePath = System.IO.Path.GetTempFileName();
                    File.WriteAllBytes(tempFilePath, fileContent!);

                    string edgePath = @"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe";
                    Process.Start(edgePath, tempFilePath);
                }
            }
        }

        private void btnCheckInfor_Click(object sender, RoutedEventArgs e)
        {
            if (resumeApplyUC.recrui != null && txbName.Text != "")
            {
                CheckInforWD checkInforWD = new CheckInforWD(resumeApplyUC.recrui.SeekerID, "Company");
                this.Hide();
                checkInforWD.ShowDialog();
                this.Show();
            }
        }
    }
}
