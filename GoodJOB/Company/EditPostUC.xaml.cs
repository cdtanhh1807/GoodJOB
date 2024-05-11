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
    /// Interaction logic for EditPostUC.xaml
    /// </summary>
    public partial class EditPostUC : UserControl
    {
        public event EventHandler? btnEditClicked;
        public event EventHandler? btnDeleteClicked;
        public JobPost jobPost;

        private void Get()
        {
            txblJobName.Text = jobPost.JobName;
            txblPostingDate.Text = jobPost.PostingDate.ToString("dd/MM/yyyy");
            string status = "";
            if (jobPost.DateOfPost < DateTime.Now) status = "Quá hạn";
            else status = "Đang đăng tuyển";
            txblStatus.Text = status;
        }

        public EditPostUC(JobPost jobPost)
        {
            InitializeComponent();
            this.jobPost = jobPost;
            Get();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            btnEditClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            btnDeleteClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
