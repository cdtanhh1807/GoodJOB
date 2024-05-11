using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
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
using GoodJOB.DAO;
using GoodJOB.Home;

namespace GoodJOB
{
    /// <summary>
    /// Interaction logic for InterviewWD.xaml
    /// </summary>
    public partial class InterviewWD : Window
    {
        Recrui? recrui;

        Interview? interview;

        bool check = false;

        SeekerControlUC? seekerControlUC;

        public Recrui? Recrui { get => recrui; set => recrui = value; }

        public InterviewWD(Recrui recrui, bool check)
        {
            InitializeComponent();
            this.Recrui = recrui;
            this.check = check;
            Get();
        }

        public InterviewWD(Recrui recrui, bool check, SeekerControlUC? seekerControlUC)
        {
            InitializeComponent();
            this.Recrui = recrui;
            this.check = check;
            Get();
            this.seekerControlUC = seekerControlUC;
        }

        private void Get()
        {
            if (check == false && Recrui!.Result == true)
            {
                btnChat.Visibility = Visibility.Visible;
                btnSend.Visibility = Visibility.Collapsed;

                RecruiDAO recruiDAO = new RecruiDAO(Recrui);
                interview = recruiDAO.GetInterview();
                txbInterviewDay.Text = interview!.InterviewDay.ToString("dd/MM/yyyy");
                txbAddress.Text = interview!.Address;
            }
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            string format = "dd/MM/yyyy";
            DateTime dt = DateTime.ParseExact(txbInterviewDay.Text, format, System.Globalization.CultureInfo.InvariantCulture);
            RecruiDAO recruiDAO = new RecruiDAO(Recrui!);
            if (recruiDAO.Interview("1", dt, txbAddress.Text)) this.Close();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnChat_Click(object sender, RoutedEventArgs e)
        {
            CompanyDAO companyDAO = new CompanyDAO(recrui!.CompanyID);
            string companyName = companyDAO.GetNameCompany();
            seekerControlUC!.GetBtnChat(companyName);
            this.Close();
        }
    }
}
