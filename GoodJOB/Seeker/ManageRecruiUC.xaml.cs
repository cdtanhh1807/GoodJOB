using GoodJOB.DAO;
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

namespace GoodJOB
{
    /// <summary>
    /// Interaction logic for ManageRecruiUC.xaml
    /// </summary>
    public partial class ManageRecruiUC : UserControl
    {
        public Recrui recrui;
        public event EventHandler? ButtonClicked;
        public ManageRecruiUC(Recrui recrui)
        {
            InitializeComponent();
            this.recrui = recrui;
            Get();
        }

        private void Get()
        {
            PostDAO postDAO = new PostDAO(recrui.PostID);
            txblJobName.Text = postDAO.GetJobName();
            CompanyDAO companyDAO = new CompanyDAO(recrui.CompanyID);
            txblCompanyName.Text = companyDAO.GetNameCompany();
            if (recrui.Result == true)
            {
                txblStatus.Text = "đã được duyệt";
                txblStatus.Foreground = Brushes.Green;
                txbDetail.Visibility = Visibility.Visible;
            }
            else if (recrui.Result == false)
            {
                txblStatus.Text = "bị từ chối";
                txblStatus.Foreground = Brushes.Red;
            }
            else
            {
                txblStatus.Text = "chưa được duyệt";
                txblStatus.Foreground = Brushes.Gray;
            }
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            ButtonClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
