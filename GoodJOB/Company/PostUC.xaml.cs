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
    /// Interaction logic for PostUC.xaml
    /// </summary>
    public partial class PostUC : UserControl
    {
        public event EventHandler? IsEdited;

        JobPost? jobPost = new JobPost();

        Account account;

        string typeOfWorkSelec = "";

        bool checkEdit = false;

        public PostUC(Account account)
        {
            InitializeComponent();
            this.account = account;
        }

        public PostUC(Account account, JobPost jobPost, bool checkEdit)
        {
            InitializeComponent();
            this.account = account;
            this.jobPost = jobPost;
            GetEdit();
            this.checkEdit = checkEdit;
        }

        private void GetBegin(ComboBox cbb)
        {
            cbb.SelectedIndex = 0;
        }

        private void GetEdit()
        {
            txbJobName.Text = jobPost!.JobName;
            cbbField.Text = jobPost.Field;
            cbbWorkTime.Text = jobPost.WorkingTime;
            typeOfWorkSelec = jobPost.TypeOfWork;
            GetTypeOfWork();
            List<string> lsSalary = SplitSalary(jobPost.Salary);
            txbSalaryFrom.Text = lsSalary[0];
            txbSalaryTo.Text = lsSalary[1];
            txbSalaryNote.Text = lsSalary[2];
            if (lsSalary[2] == "giờ") cbbSalary.SelectedIndex = 2;
            else if (lsSalary[2] == "Tháng") cbbSalary.SelectedIndex = 3;
            else cbbSalary.SelectedIndex = 1;
            cbbExp.Text = jobPost.Exp;
            txbSkill.Text = jobPost.Skill;
            txbDescription.Text = jobPost.Description;
            txbWelfare.Text = jobPost.Welfare;
            GetEditNum(jobPost.NumOfRecrui);
            GetEditDateOfPost(jobPost.DateOfPost, jobPost.PostingDate);
            account.AccountID = jobPost.AccountID;

            btnPost.Visibility = Visibility.Collapsed;
            btnSave.Visibility = Visibility.Visible;
            btnExit.Visibility = Visibility.Visible;
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            if (checkEdit == false)
            {
                GetBegin(cbbExp);
                GetBegin(cbbField);
                GetBegin(cbbPostTime);
                GetBegin(cbbSalary);
                GetBegin(cbbWorkTime);
                GetBegin(cbbNumOfRecrui);
            }
        }

        private void cbbField_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem selectedItem = (ComboBoxItem)cbbField.SelectedItem;
            if (selectedItem.Content.ToString() == "Khác")
            {
                txbField.IsEnabled = true;
                txbField.Text = "Nhập lĩnh vực";
            }
            else
            {
                txbField.IsEnabled = false;
                txbField.Text = "";
            }
        }

        private void cbbSalary_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem selectedItem = (ComboBoxItem)cbbSalary.SelectedItem;
            if (selectedItem.Content.ToString() == "Chọn")
            {
                txbSalaryFrom.IsEnabled = false;
                txbSalaryTo.IsEnabled = false;
                txbSalaryNote.IsEnabled = false;
            }
            else
            {
                txbSalaryFrom.Text = "10$";
                txbSalaryTo.Text = "20$";
                txbSalaryFrom.IsEnabled = true;
                txbSalaryTo.IsEnabled = true;
                txbSalaryNote.IsEnabled = true;
            }
            if (selectedItem.Content.ToString() == "Theo sản phẩm")
            {
                txbSalaryNote.Text = "cái";
                txbSalaryNote.IsEnabled = true;
            }
            else if (selectedItem.Content.ToString() == "Theo tháng")
            {
                txbSalaryNote.Text = "tháng";
                txbSalaryNote.IsEnabled = false;
            }
            else if (selectedItem.Content.ToString() == "Theo giờ")
            {
                txbSalaryNote.Text = "giờ";
                txbSalaryNote.IsEnabled = false;
            }
            else
            {
                txbSalaryNote.Text = "";
                txbSalaryFrom.Text = "";
                txbSalaryTo.Text = "";
            }
        }

        private void cbbPostTime_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem selectedItem = (ComboBoxItem)cbbPostTime.SelectedItem;
            if (selectedItem.Content.ToString() == "Dưới 1 tháng" || selectedItem.Content.ToString() == "Trên 1 năm")
            {
                txbDateOfPost.IsEnabled = true;
                if (selectedItem.Content.ToString() == "Dưới 1 tháng") txbDateOfPost.Text = "VD: 10 ngày";
                else txbDateOfPost.Text = "VD: 2024-12-01";
            }
            else
            {
                txbDateOfPost.IsEnabled = false;
                txbDateOfPost.Text = "";
            }
        }

        private void GetTypeOfWork()
        {
            if (typeOfWorkSelec == "Full-time") cbFullTime.IsChecked = true;
            else if (typeOfWorkSelec == "Part-time") cbPartTime.IsChecked = true;
            else cbIntern.IsChecked = true;
        }

        private void cbIntern_Checked(object sender, RoutedEventArgs e)
        {
            if (cbIntern.IsChecked == true)
            {
                typeOfWorkSelec = cbIntern.Content.ToString()!;
                cbFullTime.IsChecked = false;
                cbPartTime.IsChecked = false;
            }
        }

        private void cbPartTime_Checked(object sender, RoutedEventArgs e)
        {
            if (cbPartTime.IsChecked == true)
            {
                typeOfWorkSelec = cbPartTime.Content.ToString()!;
                cbFullTime.IsChecked = false;
                cbIntern.IsChecked = false;
            }
        }

        private void cbFullTime_Checked(object sender, RoutedEventArgs e)
        {
            if (cbFullTime.IsChecked == true)
            {
                typeOfWorkSelec = cbFullTime.Content.ToString()!;
                cbPartTime.IsChecked = false;
                cbIntern.IsChecked = false;
            }
        }

        private bool CheckPost()
        {
            if (txbJobName.Text == "" || (txbField.IsEnabled == true && txbField.Text == "Nhập lĩnh vực") || cbbField.Text == "Chọn" || cbbExp.Text == "Chọn" || cbbWorkTime.Text == "Chọn" || typeOfWorkSelec == "" || cbbSalary.Text == "Chọn" || txbSkill.Text == "" || txbDescription.Text == "" || (txbNumOfRecrui.IsEnabled == true && txbNumOfRecrui.Text == "VD: 6") || cbbNumOfRecrui.Text == "Chọn" || (txbDateOfPost.IsEnabled == true && (txbDateOfPost.Text == "VD: 10 ngày" || txbDateOfPost.Text == "VD: 2024-12-01")) || cbbPostTime.Text == "Chọn" || txbWelfare.Text == "") return false;
            return true;
        }

        private void btnPostReview_Click(object sender, RoutedEventArgs e)
        {
            if (CheckPost())
            {
                GetPost();
                PostReviewWD postReviewWD = new PostReviewWD(jobPost!, account);
                postReviewWD.ShowDialog();
            }
            else MessageBox.Show("Hãy điền đầy đủ thông tin !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void cbbNumOfRecrui_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem selectedItem = (ComboBoxItem)cbbNumOfRecrui.SelectedItem;
            if (selectedItem.Content.ToString() != "Trên 5 người")
            {
                txbNumOfRecrui.IsEnabled = false;
                txbNumOfRecrui.Text = "";
            }
            else
            {
                txbNumOfRecrui.IsEnabled = true;
                txbNumOfRecrui.Text = "VD: 6";
            }
        }

        private List<string> SplitSalary(string temp)
        {
            int dashIndex = temp.IndexOf('-');
            int slashIndex = temp.IndexOf('/');

            string firstPart = temp.Substring(0, dashIndex).Trim();
            string secondPart = temp.Substring(dashIndex + 1, slashIndex - dashIndex - 1).Trim();
            string thirdPart = temp.Substring(slashIndex + 1).Trim();

            List<string> result = new List<string>();
            result.Add(firstPart);
            result.Add(secondPart);
            result.Add(thirdPart);

            return result;
        }

        private string GetSalary()
        {
            string result = txbSalaryFrom.Text + " - " + txbSalaryTo.Text + " / " + txbSalaryNote.Text;
            return result;
        }

        private void GetEditNum(int num)
        {
            if (num > 5)
            {
                cbbNumOfRecrui.SelectedIndex = 6;
                txbNumOfRecrui.Text = num.ToString();
            }
            else
            {
                if (num == 1) cbbNumOfRecrui.SelectedIndex = 1;
                else if (num == 2) cbbNumOfRecrui.SelectedIndex = 2;
                else if (num == 3) cbbNumOfRecrui.SelectedIndex = 3;
                else if (num == 4) cbbNumOfRecrui.SelectedIndex = 4;
                else if (num == 5) cbbNumOfRecrui.SelectedIndex = 5;
            }
        }

        private int GetNum(string temp)
        {
            string[] parts = temp.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int resultInt = 0;
            if (parts.Length > 0)
            {
                string result = parts[0];
                resultInt = int.Parse(result);
            }
            return resultInt;
        }

        private int GetNumOfRecrui()
        {
            if (cbbNumOfRecrui.Text == "Trên 5 người")
            {
                return GetNum(txbNumOfRecrui.Text);
            }
            else
            {
                return GetNum(cbbNumOfRecrui.Text);
            }
        }

        private void GetEditDateOfPost(DateTime date, DateTime day)
        {
            TimeSpan timeDifference = date.Subtract(day);

            int daysDifference = timeDifference.Days;
            int monthsDifference = (date.Month - day.Month) + 12 * (date.Year - day.Year);
            int yearsDifference = date.Year - day.Year;

            if (daysDifference < 30)
            {
                cbbPostTime.SelectedIndex = 1;
                txbDateOfPost.Text = daysDifference.ToString() + " ngày";
            }
            else if (monthsDifference <= 12)
            {
                txbDateOfPost.Text = monthsDifference.ToString() + " tháng";
                cbbPostTime.SelectedValue = txbDateOfPost.Text;
            }
            else
            {
                txbDateOfPost.Text = date.ToString();
                cbbPostTime.SelectedIndex = 14;
            }
        }

        private DateTime GetDateOfPost()
        {
            DateTime dt = DateTime.Now;
            if (cbbPostTime.Text == "Dưới 1 tháng")
            {
                dt = dt.AddDays(GetNum(txbDateOfPost.Text));
            }
            else if (cbbPostTime.Text == "Trên 1 năm")
            {
                dt = Convert.ToDateTime(txbDateOfPost.Text);
            }
            else
            {
                dt = dt.AddMonths(GetNum(cbbPostTime.Text));
            }
            return dt;
        }

        private string GetField()
        {
            if (cbbField.Text == "Khác") return txbField.Text;
            return cbbField.Text;
        }

        private void GetPost()
        {
            jobPost!.JobName = txbJobName.Text;
            jobPost!.Field = GetField();
            jobPost!.WorkingTime = cbbWorkTime.Text;
            jobPost!.TypeOfWork = typeOfWorkSelec;
            jobPost!.Salary = GetSalary();
            jobPost!.Exp = cbbExp.Text;
            jobPost!.Skill = txbSkill.Text;
            jobPost!.Description = txbDescription.Text;
            jobPost!.NumOfRecrui = GetNumOfRecrui();
            jobPost!.DateOfPost = GetDateOfPost();
            jobPost!.AccountID = account.AccountID;
            jobPost!.PostingDate = DateTime.Now;
            jobPost!.Welfare = txbWelfare.Text;
        }

        private void btnPost_Click(object sender, RoutedEventArgs e)
        {
            if (CheckPost())
            {
                GetPost();
                MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng bài ?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    PostDAO postDAO = new PostDAO(jobPost!);
                    if (postDAO.Post()) MessageBox.Show("Đăng bài thành công !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    else MessageBox.Show("Đăng bài không thành công !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else MessageBox.Show("Hãy điền đầy đủ thông tin !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void txbField_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox txb = (TextBox)sender;
            if (txb.Text == "Nhập lĩnh vực") txb.Text = string.Empty;
        }

        private void txbField_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox txb = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(txb.Text)) txb.Text = "Nhập lĩnh vực";
        }

        private void txbSalaryFrom_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox txb = (TextBox)sender;
            if (txb.Text == "10$") txb.Text = string.Empty;
        }

        private void txbSalaryFrom_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox txb = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(txb.Text)) txb.Text = "10$";
        }

        private void txbSalaryTo_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox txb = (TextBox)sender;
            if (txb.Text == "20$") txb.Text = string.Empty;
        }

        private void txbSalaryTo_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox txb = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(txb.Text)) txb.Text = "20$";
        }

        private void txbSalaryNote_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox txb = (TextBox)sender;
            if (txb.Text == "cái") txb.Text = string.Empty;
        }

        private void txbSalaryNote_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox txb = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(txb.Text)) txb.Text = "cái";
        }

        private void txbNumOfRecrui_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox txb = (TextBox)sender;
            if (txb.Text == "VD: 6") txb.Text = string.Empty;
        }

        private void txbNumOfRecrui_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox txb = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(txb.Text)) txb.Text = "VD: 6";
        }

        private void txbDateOfPost_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox txb = (TextBox)sender;
            if (txb.Text == "VD: 10 ngày" || txb.Text == "VD: 2024-12-01") txb.Text = string.Empty;
        }

        private void txbDateOfPost_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox txb = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(txb.Text))
            {
                if (cbbPostTime.Text == "Dưới 1 tháng") txb.Text = "VD: 10 ngày";
                else if (cbbPostTime.Text == "Trên 1 năm") txb.Text = "VD: 2024-12-01";
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (CheckPost())
            {
                GetPost();
                MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn muốn sửa bài đăng ?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    PostDAO postDAO = new PostDAO(jobPost!);
                    if (postDAO.EditPost())
                    {
                        MessageBox.Show("Sửa bài đăng thành công !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                        IsEdited?.Invoke(this, EventArgs.Empty);
                        var parent = (Panel)this.Parent;
                        parent.Children.Remove(this);
                    }
                    else MessageBox.Show("Sửa bài đăng không thành công !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else MessageBox.Show("Hãy điền đầy đủ thông tin !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            var parent = (Panel)this.Parent;
            parent.Children.Remove(this);
        }
    }
}
