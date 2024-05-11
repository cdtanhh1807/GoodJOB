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
    /// Interaction logic for ExpUC.xaml
    /// </summary>
    public partial class ExpUC : UserControl
    {
        public delegate void SaveCompleted(bool result);
        public delegate void MinusCompleted(bool result);
        public event SaveCompleted? saveCompleted;
        public event MinusCompleted? btnMinusClicked;
        Exp? exp;
        Account? account;
        bool checkEdit = false;
        bool checkActive = false;
        bool checkEditAc = false;

        string jobName = "";
        string companyName = "";
        string workTime = "";
        string description = "";

        public bool CheckActive { get => checkActive; set => checkActive = value; }
        public bool CheckEdit { get => checkEdit; set => checkEdit = value; }

        public ExpUC(Exp? exp, SeekerInforUC us)
        {
            InitializeComponent();
            this.exp = exp;
            this.account = us.account;
            SubscribeToButtonClick(us);
        }

        public ExpUC(SeekerInforUC seekerInforUC)
        {
            InitializeComponent();
            this.account = seekerInforUC.account;
            SubscribeToButtonClick(seekerInforUC);
        }

        public void SubscribeToButtonClick(UserControl userControl)
        {
            if (userControl is SeekerInforUC us)
            {
                us.btnSaveClicked += Us_btnSaveClicked;
                us.btnEditClicked += Us_btnEditClicked;
            }
        }

        private void Us_btnEditClicked(object? sender, EventArgs e)
        {
            //MessageBox.Show("ahihi");
            CheckEdit = true;
            checkEditAc = true;
            Check();
            CheckActive = false;
            GetTxb();
            
        }

        private bool CheckTxb()
        {
            if (jobName != txbJobName.Text || companyName != txbCompanyName.Text || workTime != txbWorkTime.Text || description != txbDescription.Text) return true;
            return false;
        }

        private void SaveEdit()
        {
            if (CheckActive == false && CheckTxb() == true)
            {
                Exp exp = new Exp(account!.AccountID, txbJobName.Text, txbWorkTime.Text, txbCompanyName.Text, txbDescription.Text);
                ExpDAO expDAO = new ExpDAO(exp);
                if (expDAO.EditExp(jobName, companyName, workTime, description))
                {
                    CheckActive = true;
                    CheckEdit = false;
                    btnMinus.IsEnabled = false;
                    bool result = true;
                    saveCompleted?.Invoke(result);

                    //btnMinusClicked?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    bool result = false;
                    saveCompleted?.Invoke(result);
                }
            }
            else if (CheckActive == false && CheckTxb() != true)
            {
                CheckActive = true;
            }
        }

        private void Us_btnSaveClicked(object? sender, EventArgs e)
        {
            if (CheckActive == false)
            {
                Exp exp = new Exp(account!.AccountID, txbJobName.Text, txbWorkTime.Text, txbCompanyName.Text, txbDescription.Text);
                if (checkEditAc == true)
                {
                    SaveEdit();
                    checkEditAc = false;
                }
                else
                {
                    ExpDAO expDAO = new ExpDAO(exp);
                    if (expDAO.AddExp())
                    {
                        CheckActive = true;
                        CheckEdit = false;
                        btnMinus.IsEnabled = false;
                        bool result = true;
                        saveCompleted?.Invoke(result);
                    }

                    else
                    {
                        bool result = false;
                        saveCompleted?.Invoke(result);
                    }
                }
                
            }
            else if (CheckActive == false && CheckTxb() != true)
            {
                CheckActive = true;
            }
        }

        private void Check()
        {
            if (CheckEdit == false)
            {
                txbJobName.IsReadOnly = true;
                txbCompanyName.IsReadOnly = true;
                txbWorkTime.IsReadOnly = true;
                txbDescription.IsReadOnly = true;

                btnMinus.IsEnabled = false;
            }
            else
            {
                txbJobName.IsReadOnly = false;
                txbCompanyName.IsReadOnly = false;
                txbWorkTime.IsReadOnly = false;
                txbDescription.IsReadOnly = false;

                btnMinus.IsEnabled = true;
            }
        }

        private void Get()
        {
            if (exp != null)
            {
                txbJobName.Text = exp.JobName;
                txbCompanyName.Text = exp.CompanyName;
                txbWorkTime.Text = exp.WorkTime;
                txbDescription.Text = exp.Description;

                Check();
            }
        }

        private void btnMinus_Click(object sender, RoutedEventArgs e)
        {
            if (CheckEdit == true)
            {
                MessageBoxResult result = MessageBox.Show("Không thể khôi phục ! Bạn có chắc chắn muốn xóa ?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    if (exp != null)
                    {
                        ExpDAO expDAO = new ExpDAO(exp);
                        if (expDAO.MinusExp())
                        {
                            btnMinusClicked?.Invoke(true);
                            var parent = this.Parent as Panel;
                            if (parent != null)
                            {
                                parent.Children.Remove(this);
                            }
                        }
                        else MessageBox.Show("Xóa không thành công !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Get();
        }

        private void GetTxb()
        {
            jobName = txbJobName.Text;
            companyName = txbCompanyName.Text;
            workTime = txbWorkTime.Text;
            description = txbDescription.Text;
        }
    }
}
