using GoodJOB.DAO;
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

namespace GoodJOB
{
    /// <summary>
    /// Interaction logic for ResumeApplyUC.xaml
    /// </summary>
    public partial class ResumeApplyUC : UserControl
    {
        public event EventHandler? ButtonResumeClicked;
        public event EventHandler? AcceptOrRefusePerformed;
        public Recrui recrui = new Recrui();
        public Seeker seeker = new Seeker();
        public JobPost post = new JobPost();
        private int turn = 0;

        public int Turn { get => turn; set => turn = value; }

        private void Get()
        {
            txbSeekerName.Text = seeker.Name;
            txbPostingDate.Text = post.PostingDate.ToString("dd/MM/yyyy");
        }

        public ResumeApplyUC(Recrui recrui)
        {
            InitializeComponent();
            this.recrui = recrui;
            PostDAO postDAO = new PostDAO(recrui.PostID);
            this.post = postDAO.GetPost();
            SeekerDAO seekerDAO = new SeekerDAO(recrui.SeekerID);
            seeker = seekerDAO.GetInforSeeker()!;
            Get();
        }

        public void GetButton()
        {
            Turn = 0;
            btn.IsEnabled = true;
            ChangeButtonBackground(btn, "#00FFFFFF");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ButtonResumeClicked?.Invoke(this, EventArgs.Empty);
            Turn = 1;
            ChangeButtonBackground(sender as Button, "#FFDFD5C8");
        }

        private void ChangeButtonBackground(Button? button, string hex)
        {
            Border? border = btn.Template.FindName("border", btn) as Border;
            if (border != null)
            {
                border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(hex));
            }
        }

        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            if (Turn == 1)
            {
                InterviewWD interviewWD = new InterviewWD(recrui, true);
                interviewWD.ShowDialog();
                AcceptOrRefusePerformed?.Invoke(this, EventArgs.Empty);
            }
        }

        private void btnRefuse_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            
            if (Turn == 1)
            {
                MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn muốn từ chối ?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    RecruiDAO recruiDAO = new RecruiDAO(recrui);
                    if (recruiDAO.Reply("0"))
                    {
                        MessageBox.Show("Đã từ chối !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                        AcceptOrRefusePerformed?.Invoke(this, EventArgs.Empty);
                    }
                    else MessageBox.Show("Từ chối không thành công !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                
            }
        }
    }
}
