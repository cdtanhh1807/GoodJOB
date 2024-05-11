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
using Microsoft.Win32;

namespace GoodJOB
{
    /// <summary>
    /// Interaction logic for SeekerInforUC.xaml
    /// </summary>
    public partial class SeekerInforUC : UserControl
    {
        public event EventHandler? btnSaveClicked;
        public event EventHandler? btnEditClicked;

        public Account? account;

        Seeker? seeker = new Seeker();

        bool checkOpen;

        bool checkEdit = false;

        bool sex;

        bool likeCurr = false;

        public SeekerInforUC(string accountID)
        {
            InitializeComponent();
            seeker.AccountID = accountID;
            checkOpen = true;
        }

        public SeekerInforUC(Account account)
        {
            InitializeComponent();
            this.account = account;
            seeker.AccountID = this.account.AccountID;
            checkOpen = false;
        }

        private void GetEdit()
        {
            if (checkEdit == false)
            {
                btnSave.IsEnabled = false;
                txbName.IsReadOnly = true;
                txbPhone.IsReadOnly = true;
                txbMajor.IsReadOnly = true;
                txbLgDegree.IsReadOnly = true;
                txbEmail.IsReadOnly = true;
                txbBirthday.IsReadOnly = true;
                cbFemale.IsEnabled = false;
                cbMale.IsEnabled = false;
                btnAddWorkExp.IsEnabled = false;

                btnAddCV.IsEnabled = false;
                btnEditAvt.IsEnabled = false;
            }
            else
            {
                btnSave.IsEnabled = true;
                txbName.IsReadOnly = false;
                txbPhone.IsReadOnly = false;
                txbMajor.IsReadOnly = false;
                txbLgDegree.IsReadOnly = false;
                txbEmail.IsReadOnly = false;
                txbBirthday.IsReadOnly = false;
                cbFemale.IsEnabled = true;
                cbMale.IsEnabled = true;
                btnAddWorkExp.IsEnabled = true;

                btnAddCV.IsEnabled = true;
                btnEditAvt.IsEnabled = true;
            }
        }

        private void GetInfor()
        {
            SeekerDAO seekerDAO = new SeekerDAO(seeker!.AccountID);
            seeker = seekerDAO.GetInforSeeker();

            if (seeker != null )
            {
                if (seeker.AvtName != "") GetAvt();

                txbName.Text = seeker.Name;
                txbBirthday.Text = seeker.Birthday;
                if (seeker.Sex == true)
                {
                    cbMale.IsChecked = true;
                    cbFemale.IsChecked = false;
                }
                else
                {
                    cbMale.IsChecked = false;
                    cbFemale.IsChecked = true;
                }
                txbPhone.Text = seeker.Phone;
                txbEmail.Text = seeker.Email;
                txbMajor.Text = seeker.Major;
                txbLgDegree.Text = seeker.LanguageDegree;
                txblLike.Text = seeker.Like.ToString();

                if (checkOpen == true)
                {
                    btnExit.Visibility = Visibility.Visible;
                    btnSave.Visibility = Visibility.Collapsed;
                    btnEdit.Visibility = Visibility.Collapsed;
                    btnLike.Visibility = Visibility.Visible;

                    btnEditAvt.Visibility = Visibility.Collapsed;
                }
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            GetInfor();
            GetEdit();
            if (txbName.Text == "")
            {
                MessageBox.Show("Trước tiên hãy điền những thông tin cần thiết cho công ty của bạn nhé !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                checkEdit = true;
                GetEdit();
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);

            if (parentWindow != null)
            {
                parentWindow.Close();
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            countErro = 0;
            checkEdit = true;
            GetEdit();
            btnEditClicked?.Invoke(this, EventArgs.Empty);
        }

        private void GetSeeker()
        {
            SeekerDAO seekerDAO = new SeekerDAO(account!.AccountID);
            seeker = seekerDAO.GetInforSeeker();

            if (seeker != null)
            {
                seeker!.Name = txbName.Text;
                seeker.Phone = txbPhone.Text;
                seeker.Email = txbEmail.Text;
                seeker.Sex = sex;
                seeker.Major = txbMajor.Text;
                seeker.LanguageDegree = txbLgDegree.Text;
                seeker.Birthday = txbBirthday.Text;
                seeker.Like = Convert.ToInt32(txblLike.Text);

                if (filePath != "")
                {
                    seeker.CvPath = filePath;
                    seeker.CvBytes = fileBytes;
                }

                if (avtFilePath != "")
                {
                    seeker.AvtName = avtFilePath;
                    seeker.AvtContent = avtFileBytes;
                }
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            GetSeeker();
            btnSaveClicked?.Invoke(this, EventArgs.Empty);
            SeekerDAO seekerDAO = new SeekerDAO(seeker!);
            if (filePath != "" && fileBytes != null || avtFilePath != "" && avtFileBytes != null)
            {
                if (seeker!.CvPath == "")
                {
                    if (seekerDAO.EditInforAvtSeeker() || (countErro == 0 && countCompleted > 0 || countRemove > 0))
                    {
                        MessageBox.Show("Đã lưu thành công !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                        checkEdit = false;
                        GetEdit();
                        wrap.Children.Clear();
                        GetWrap();
                    }
                    else if (countErro > 0) MessageBox.Show("Lưu không thành công !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (seeker.AvtName == "")
                {
                    if (seekerDAO.EditInforCVSeeker() || (countErro == 0 && countCompleted > 0 || countRemove > 0))
                    {
                        MessageBox.Show("Đã lưu thành công !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                        checkEdit = false;
                        GetEdit();
                        wrap.Children.Clear();
                        GetWrap();
                    }
                    else if (countErro > 0) MessageBox.Show("Lưu không thành công !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    if (seekerDAO.EditInforSeeker() || (countErro == 0 && countCompleted > 0 || countRemove > 0))
                    {
                        MessageBox.Show("Đã lưu thành công !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                        checkEdit = false;
                        GetEdit();
                        wrap.Children.Clear();
                        GetWrap();
                    }
                    else if (countErro > 0) MessageBox.Show("Lưu không thành công !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else if (filePath == "" && avtFilePath == "")
            {
                if (seekerDAO.EditInforNonPicSeeker() || (countErro == 0 && countCompleted > 0 || countRemove > 0))
                {
                    MessageBox.Show("Đã lưu thành công !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    checkEdit = false;
                    GetEdit();
                    wrap.Children.Clear();
                    GetWrap();
                }
                else if (countErro > 0) MessageBox.Show("Lưu không thành công !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else MessageBox.Show("Điền đầy đủ thông tin !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void cbMale_Checked(object sender, RoutedEventArgs e)
        {
            if (cbMale.IsChecked == true)
            {
                sex = true;
                cbFemale.IsChecked = false;
            }
        }

        private void cbFemale_Checked(object sender, RoutedEventArgs e)
        {
            if (cbFemale.IsChecked == true)
            {
                sex = false;
                cbMale.IsChecked = false;
            }
        }

        public void SubscribeToButtonClick(UserControl userControl)
        {
            if (userControl is ExpUC us)
            {
                us.btnMinusClicked += Us_btnMinusClicked;
                us.saveCompleted += Us_saveCompleted;
            }
        }

        int countCompleted = 0;
        int countErro = 0;

        private void Us_saveCompleted(bool result)
        {
            if (result == true) countCompleted++;
            else countErro++;
        }

        int countRemove = 0;
        private void Us_btnMinusClicked(bool result)
        {
            if (result == true)
            {
                countRemove++;
                wrap.Children.Clear();
                GetWrap();
            }
        }

        private void GetWrap()
        {
            ExpDAO expDAO = new ExpDAO(seeker!.AccountID, this);
            List<ExpUC> list = expDAO.LoadExp();

            foreach (ExpUC expUc in list)
            {
                wrap.Children.Add(expUc);
                expUc.CheckActive = true;
                if (checkEdit == true)
                {
                    expUc.CheckEdit = true;
                }
                else expUc.CheckEdit = false;
                SubscribeToButtonClick(expUc);
            }
        }

        private void wrap_Loaded(object sender, RoutedEventArgs e)
        {
            if (seeker != null) GetWrap();
        }

        private void btnAddWorkExp_Click(object sender, RoutedEventArgs e)
        {
            ExpUC expUC = new ExpUC(this);
            wrap.Children.Add(expUC);
            expUC.CheckEdit = true;
            SubscribeToButtonClick(expUC);
        }

        string avtFilePath = "";
        byte[]? avtFileBytes;

        private void btnEditAvt_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.pdf;*.png;*.jpg;*.jpeg)|*.pdf;*.png;*.jpg;*.jpeg";
            if (openFileDialog.ShowDialog() == true)
            {

                avtFilePath = openFileDialog.FileName;
                avtFileBytes = File.ReadAllBytes(avtFilePath);

                if (avtFilePath != "" && avtFileBytes != null)
                {
                    avt.Source = new BitmapImage(new Uri(avtFilePath));
                    MessageBox.Show("Ảnh đại diện đã được tải lên !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);

                    
                }
                else MessageBox.Show("Ảnh đại diện chưa được tải lên !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnLike_Click(object sender, RoutedEventArgs e)
        {
            int temp = Convert.ToInt32(txblLike.Text);
            if (likeCurr == false) likeCurr = true;
            else likeCurr = false;

            if (likeCurr == true) temp++;
            else temp--;

            txblLike.Text = temp.ToString();
            SeekerDAO seekerDAO = new SeekerDAO(seeker!.AccountID);
            if (seekerDAO.LikeSeeker(temp)) { }
        }

        string filePath = "";

        byte[]? fileBytes;

        private void btnAddCV_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.pdf;*.png;*.jpg;*.jpeg)|*.pdf;*.png;*.jpg;*.jpeg";

            if (openFileDialog.ShowDialog() == true)
            {

                filePath = openFileDialog.FileName;
                fileBytes = File.ReadAllBytes(filePath);

                if (filePath != "" && fileBytes != null)
                {
                    MessageBox.Show("CV đã được tải lên !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else MessageBox.Show("CV chưa được tải lên !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);


            }
        }

        private void GetAvt()
        {
            if (seeker!.AvtName != "" && seeker.AvtContent != null)
            {
                SeekerDAO seekerDAO = new SeekerDAO(seeker.AccountID);
                byte[]? fileContent = seekerDAO.DownloadAvtSeeker();

                using (MemoryStream ms = new MemoryStream(fileContent!))
                {
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.StreamSource = ms;
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.EndInit();

                    
                    avt.Source = bitmap;
                }
            }
        }

        private void btnCheckCV_Click(object sender, RoutedEventArgs e)
        {
            if (seeker != null)
            {
                if (seeker!.CvPath != "" && seeker.CvBytes != null)
                {
                    SeekerDAO seekerDAO = new SeekerDAO(seeker.AccountID);
                    byte[]? fileContent = seekerDAO.DownloadCVSeeker();

                    string tempFilePath = System.IO.Path.GetTempFileName();
                    File.WriteAllBytes(tempFilePath, fileContent!);

                    string edgePath = @"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe";
                    Process.Start(edgePath, tempFilePath);
                }
            }
            
        }
    }
}
