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
    /// Interaction logic for RecruiUC.xaml
    /// </summary>
    public partial class RecruiUC : UserControl
    {
        public JobPostRecrui jobPostRecrui;

        public event EventHandler? ButtonClicked;

        private int turn = 0;

        public int Turn { get => turn; set => turn = value; }

        public RecruiUC(JobPostRecrui jobPostRecrui)
        {
            InitializeComponent();
            this.jobPostRecrui = jobPostRecrui;
            Get();
        }

        private void Get()
        {
            PostDAO postDAO = new PostDAO(jobPostRecrui.PostID);
            txblJobName.Text = postDAO.GetJobName();
            txblNumRec.Text += jobPostRecrui.Count;
        }

        public void GetButton()
        {
            Turn = 0;
            btn.IsEnabled = true;
            ChangeButtonBackground(btn, "#00FFFFFF");
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            ButtonClicked?.Invoke(this, EventArgs.Empty);
            Turn = 1;
            ChangeButtonBackground(sender as Button, "#516d6b");
        }

        private void ChangeButtonBackground(Button? button, string hex)
        {
            Border? border = btn.Template.FindName("border", btn) as Border;
            if (border != null)
            {
                border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(hex));
            }
        }
    }
}
