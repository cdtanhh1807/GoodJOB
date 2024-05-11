using GoodJOB.DAO;
using GoodJOB.Home;
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
    /// Interaction logic for CompanyChat.xaml
    /// </summary>
    public partial class CompanyChat : UserControl
    {
        Recrui? recrui;

        Account account;

        List<Message> list = new List<Message>();

        List<Message> sortedMessages = new List<Message>();

        ItemSeekerChatUC? usCurr;

        bool checkVis = false;

        public CompanyChat(Account account)
        {
            InitializeComponent();
            this.account = account;
        }

        private void txbInput_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift))
                {
                    txbInput.AppendText(Environment.NewLine);
                    e.Handled = true;
                }
                else
                {
                    if (txbInput.Text != "Nhập để chat...")
                    {
                        DateTime dt = DateTime.Now;
                        Message message = new Message(recrui!.CompanyID, recrui.SeekerID, "Company", txbInput.Text, dt);
                        MessageDAO messageDAO = new MessageDAO(message);
                        if (messageDAO.SendMessage())
                        {
                            txbInput.Text = "";
                        }
                        e.Handled = true;
                        Get();
                    }
                }
            }
        }

        private void Get()
        {
            txbName.Text = usCurr!.seeker.Name;

            MessageDAO messageDAO = new MessageDAO(usCurr.recrui.CompanyID, usCurr.recrui.SeekerID);
            list = messageDAO.LoadMessage();

            sortedMessages = list.OrderBy(m => m.Time).ToList();

            stackChat.Children.Clear();

            foreach (var message in sortedMessages)
            {
                AutoGrowingTextBox autoGrowingTextBox = new AutoGrowingTextBox("Company", message.Role, message.Mess);
                stackChat.Children.Add(autoGrowingTextBox);
            }

            scr.ScrollToEnd();
        }

        private void txbInput_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox txb = (TextBox)sender;
            if (txb.Text == "Nhập để chat...") txb.Text = string.Empty;
        }

        private void txbInput_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox txb = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(txb.Text)) txb.Text = "Nhập để chat...";
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Init();
        }

        private void SubscribeToButtonClick(UserControl us)
        {
            if (us is ItemSeekerChatUC uc)
            {
                uc.ButtonClicked += Uc_ButtonClicked;
            }
        }

        private void Uc_ButtonClicked(object? sender, EventArgs e)
        {
            if (sender is ItemSeekerChatUC us)
            {
                checkVis = true;
                GetVis();

                usCurr = us;
                recrui = us.recrui;
                foreach (ItemSeekerChatUC control in stack.Children)
                {
                    control.GetButton();
                }
                (sender as ItemSeekerChatUC)!.Turn = 1;

                Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Render, new Action(() =>
                {
                    Get();
                }));
            }
        }

        private void GetVis()
        {
            if (checkVis == false)
            {
                bdInput.Visibility = Visibility.Collapsed;
                txbInput.Visibility = Visibility.Collapsed;
                scr.Visibility = Visibility.Collapsed;
                stackChat.Visibility = Visibility.Collapsed;
                bdSend.Visibility = Visibility.Collapsed;
                bd.Visibility = Visibility.Collapsed;
            }
            else
            {
                bdInput.Visibility = Visibility.Visible;
                txbInput.Visibility = Visibility.Visible;
                scr.Visibility = Visibility.Visible;
                stackChat.Visibility = Visibility.Visible;
                bdSend.Visibility = Visibility.Visible;
                bd.Visibility = Visibility.Visible;
            }
        }

        private void Init()
        {
            GetVis();

            RecruiDAO recruiDAO = new RecruiDAO(account.AccountID);
            List<ItemSeekerChatUC> listItem = recruiDAO.LoadSeekerItemChat();

            foreach (var item in listItem)
            {
                stack.Children.Add(item);
                SubscribeToButtonClick(item);
            }
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            if (txbInput.Text != "Nhập để chat...")
            {
                DateTime dt = DateTime.Now;
                Message message = new Message(recrui!.CompanyID, recrui.SeekerID, "Company", txbInput.Text, dt);
                MessageDAO messageDAO = new MessageDAO(message);
                if (messageDAO.SendMessage())
                {
                    txbInput.Text = "";
                }
                e.Handled = true;
                Get();
            }
        }
    }
}
