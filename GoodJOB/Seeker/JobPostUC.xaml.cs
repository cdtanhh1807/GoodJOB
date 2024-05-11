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
    /// Interaction logic for JobPostUC.xaml
    /// </summary>
    public partial class JobPostUC : UserControl
    {
        public event EventHandler? ButtonClicked;
        public JobPost jobPost;
        public string companyName = "";

        private void Get()
        {
            CompanyDAO companyDAO = new CompanyDAO(jobPost.AccountID);
            companyName = companyDAO.GetNameCompany();
            txblJobName.Text = jobPost.JobName;
            txblCompanyName.Text = companyName;
            txblExp.Text = jobPost.Exp;
            txblExp.Text += " kinh nghiệm";
            txblSalary.Text = jobPost.Salary;
        }

        public JobPostUC(JobPost jobPost)
        {
            InitializeComponent();
            this.jobPost = jobPost;
            Get();
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            ButtonClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
