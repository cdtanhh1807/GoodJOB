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
    /// Interaction logic for SeekerManageRecrui.xaml
    /// </summary>
    public partial class SeekerManageRecrui : UserControl
    {
        Account account;
        bool role = true;
        SeekerControlUC seekerControlUC;
        public SeekerManageRecrui(Account account, SeekerControlUC seekerControlUC)
        {
            InitializeComponent();
            this.account = account;
            this.seekerControlUC = seekerControlUC;
        }

        private void ReceiveStack()
        {
            stack.Children.Clear();
            RecruiDAO recruiDAO = new RecruiDAO(account);
            List<ManageRecruiUC> list = recruiDAO.LoadManegeRecrui();

            foreach (ManageRecruiUC manageRecruiUC in list)
            {
                stack.Children.Add(manageRecruiUC);
                SubcribeToButton(manageRecruiUC);
            }
        }

        private void SubcribeToButton(UserControl userControl)
        {
            if (userControl is ManageRecruiUC us)
            {
                us.ButtonClicked += Us_ButtonClicked;
            }
        }

        private void Us_ButtonClicked(object? sender, EventArgs e)
        {
            if (sender is ManageRecruiUC us)
            {
                //ReplyRecruiUC replyRecruiUC = new ReplyRecruiUC(us.recrui);
                //main.Children.Add(replyRecruiUC);

                InterviewWD interviewWD = new InterviewWD(us.recrui, false, seekerControlUC);
                if (interviewWD.Recrui!.Result == true) interviewWD.ShowDialog();

            }
        }

        private void SendStack()
        {
            stack.Children.Clear();
            RecruiDAO recruiDAO = new RecruiDAO(account);
            List<ManageRecruiUC> list = recruiDAO.LoadManegeRecruiNon();

            foreach (ManageRecruiUC manageRecruiUC in list)
            {
                stack.Children.Add(manageRecruiUC);
            }
        }

        private void Get()
        {
            if (role == true) ReceiveStack();
            else SendStack();
        }

        private void stack_Loaded(object sender, RoutedEventArgs e)
        {
            Get();
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            role = false;
            Get();
        }

        private void btnRecei_Click(object sender, RoutedEventArgs e)
        {
            role = true;
            Get();
        }
    }
}
