using GoodJOB.DAO;
using GoodJOB.Home;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
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
    /// Interaction logic for CompanyInforUC.xaml
    /// </summary>
    public partial class CompanyInforUC : UserControl
    {
        Account? account;

        Company company = new Company();

        bool checkOpen = false;

        bool likeCurr = false;

        public CompanyInforUC(string accountID)
        {
            this.account = new Account();
            InitializeComponent();
            company.AccountID = accountID;
            account.AccountID = accountID;
            checkOpen = true;
        }

        public CompanyInforUC(Account account)
        {
            InitializeComponent();
            this.account = account;
            company.AccountID = this.account.AccountID;
            checkOpen = false;
        }

        private void GetInfor()
        {
            CompanyDAO companyDAO = new CompanyDAO(account!.AccountID);
            company = companyDAO.GetInforCompany()!;

            if (company != null)
            {
                txbName.Text = company.Name;
                txbPhone.Text = company.Phone;
                txbAddress.Text = company.Address;
                txbEmail.Text = company.Email;
                cbbVPDD.Text = company.Vpdd;
                txbCEO.Text = company.CeoName;
                txbVAT.Text = company.VatID;
                txbIntroduce.Text = company.Introduce;
                txblLike.Text = company.Like.ToString();

                GetAvt();
            }

            if (checkOpen == true)
            {
                btnAddGPKD.Visibility = Visibility.Visible;
                btnAddGPKD.IsEnabled = false;
                btnChangeAvt.Visibility = Visibility.Collapsed;
                btnEdit.Visibility = Visibility.Collapsed;
                btnSave.Visibility = Visibility.Collapsed;
                btnExit.Visibility = Visibility.Visible;
                GetAvt();
            }
            else btnLike.Visibility = Visibility.Collapsed;
        }

        private void GetCompany()
        {
            company.Name = txbName.Text;
            company.Phone = txbPhone.Text;
            company.Address = txbAddress.Text;
            company.Email = txbEmail.Text;
            company.Vpdd = cbbVPDD.Text;
            company.CeoName = txbCEO.Text;
            company.VatID = txbVAT.Text;
            company.Introduce = txbIntroduce.Text;
            company.Like = Convert.ToInt32(txblLike.Text);

            company!.AvtName = avtFilePath;
            company.AvtContent = avtFileBytes;
            company.GpkdName = filePath;
            company.GpkdContent = fileBytes;
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            cbbVPDD.SelectedIndex = 0;
            GetInfor();
            CheckBtnEdit();
            if (txbName.Text == "")
            {
                MessageBox.Show("Trước tiên hãy điền những thông tin cần thiết cho công ty của bạn nhé !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                CheckEdit = true;
                CheckBtnEdit();
            }
        }

        string avtFilePath = "";
        byte[]? avtFileBytes;

        private void btnChangeAvt_Click(object sender, RoutedEventArgs e)
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


                    avt.Source = bitmap;
                }
            }
        }

        string filePath = "";
        byte[]? fileBytes;

        private void btnAddGPKD_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PDF files (*.pdf)|*.pdf|PNG files (*.png)|*.png|JPEG files (*.jpg)|*.jpg";
            if (openFileDialog.ShowDialog() == true)
            {

                filePath = openFileDialog.FileName;
                fileBytes = File.ReadAllBytes(filePath);

                if (filePath != "" && fileBytes != null)
                {
                    
                    MessageBox.Show("GPKD đã được tải lên !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else MessageBox.Show("GPKD chưa được tải lên !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);

                
            }
        }

        private void btnViewGPKD_Click(object sender, RoutedEventArgs e)
        {
            if (company.GpkdName != "" && company.GpkdContent != null)
            {
                CompanyDAO companyDAO = new CompanyDAO(company.AccountID);
                byte[]? fileContent = companyDAO.DownloadGPKD();

                string tempFilePath = System.IO.Path.GetTempFileName();
                File.WriteAllBytes(tempFilePath, fileContent!);

                string edgePath = @"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe";
                Process.Start(edgePath, tempFilePath);
            }
        }

        bool CheckEdit = false;

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            CheckEdit = true;
            CheckBtnEdit();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (CheckEdit == true)
            {
                GetCompany();
                CompanyDAO companyDAO = new CompanyDAO(company);
                if (company.GpkdName != "" || company.AvtName != "")
                {
                    if (company.AvtName == "")
                    {
                        if (companyDAO.EditInforGPKDCompany())
                        {
                            CheckEdit = false;
                            CheckBtnEdit();
                            MessageBox.Show("Chỉnh sửa dữ liệu thành công !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else MessageBox.Show("Chỉnh sửa dữ liệu không thành công !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else if (company.GpkdName == "")
                    {
                        if (companyDAO.EditInforAvtCompany())
                        {
                            CheckEdit = false;
                            CheckBtnEdit();
                            MessageBox.Show("Chỉnh sửa dữ liệu thành công !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else MessageBox.Show("Chỉnh sửa dữ liệu không thành công !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        if (companyDAO.EditInforCompany())
                        {
                            CheckEdit = false;
                            CheckBtnEdit();
                            MessageBox.Show("Chỉnh sửa dữ liệu thành công !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else MessageBox.Show("Chỉnh sửa dữ liệu không thành công !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                else if (company.GpkdName == "" && company.AvtName == "")
                {
                    if (companyDAO.EditInforNonPicCompany())
                    {
                        CheckEdit = false;
                        CheckBtnEdit();
                        MessageBox.Show("Chỉnh sửa dữ liệu thành công !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else MessageBox.Show("Chỉnh sửa dữ liệu không thành công !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else MessageBox.Show("Điền đầy đủ thông tin !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void CheckBtnEdit()
        {
            if (CheckEdit == true)
            {
                txbName.IsReadOnly = false;
                txbPhone.IsReadOnly = false;
                txbEmail.IsReadOnly = false;
                txbAddress.IsReadOnly = false;
                txbCEO.IsReadOnly = false;
                txbIntroduce.IsReadOnly = false;
                txbVAT.IsReadOnly = false;
                cbbVPDD.IsReadOnly = false;
                btnChangeAvt.IsEnabled = true;
                btnAddGPKD.IsEnabled = true;
                btnViewGPKD.IsEnabled = false;
                btnSave.IsEnabled = true;
            }
            else
            {
                txbName.IsReadOnly = true;
                txbPhone.IsReadOnly = true;
                txbEmail.IsReadOnly = true;
                txbAddress.IsReadOnly = true;
                txbCEO.IsReadOnly = true;
                txbIntroduce.IsReadOnly = true;
                txbVAT.IsReadOnly = true;
                cbbVPDD.IsReadOnly = true;
                btnChangeAvt.IsEnabled = false;
                btnAddGPKD.IsEnabled = false;
                btnViewGPKD.IsEnabled = true;
                btnSave.IsEnabled = false;
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

        private void btnLike_Click(object sender, RoutedEventArgs e)
        {
            int temp = Convert.ToInt32(txblLike.Text);
            if (likeCurr == false) likeCurr = true;
            else likeCurr = false;

            if (likeCurr == true) temp++;
            else temp--;

            txblLike.Text = temp.ToString();
            CompanyDAO companyDAO = new CompanyDAO(company!.AccountID);
            if (companyDAO.LikeCompany(temp))
            {

            }
        }
    }
}
