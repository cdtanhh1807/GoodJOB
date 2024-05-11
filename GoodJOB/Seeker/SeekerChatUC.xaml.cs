﻿using GoodJOB.DAO;
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
    /// Interaction logic for SeekerChatUC.xaml
    /// </summary>
    public partial class SeekerChatUC : UserControl
    {
        Recrui? recrui;

        Account? account;

        List<Message> list = new List<Message>();

        List<Message> sortedMessages = new List<Message>();

        ItemCompanyChatUC? usCurr;

        string accountID = "";

        string companyName = "";

        bool checkVis = false;

        public SeekerChatUC(Account account)
        {
            InitializeComponent();
            this.account = account;
        }

        public SeekerChatUC(string accountID, string campanyName)
        {
            InitializeComponent();
            this.accountID = accountID;
            this.companyName = campanyName;
        }

        private void mainGrid_Loaded(object sender, RoutedEventArgs e)
        {
            Init();
            if (accountID != "")
            {
                GetChat();
            }
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
                        Message message = new Message(recrui!.CompanyID, recrui.SeekerID, "Seeker", txbInput.Text, dt);
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
            txbName.Text = usCurr!.Company.Name;

            MessageDAO messageDAO = new MessageDAO(usCurr.recrui.CompanyID, usCurr.recrui.SeekerID);
            list = messageDAO.LoadMessage();

            sortedMessages = list.OrderBy(m => m.Time).ToList();

            stackChat.Children.Clear();

            foreach (var message in sortedMessages)
            {
                AutoGrowingTextBox autoGrowingTextBox = new AutoGrowingTextBox("Seeker", message.Role, message.Mess);
                stackChat.Children.Add(autoGrowingTextBox);
            }

            scr.ScrollToEnd();
        }

        private void txbInput_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox txb = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(txb.Text)) txb.Text = "Nhập để chat...";
        }

        private void txbInput_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox txb = (TextBox)sender;
            if (txb.Text == "Nhập để chat...") txb.Text = string.Empty;
        }

        private void SubscribeToButtonClick(UserControl us)
        {
            if (us is ItemCompanyChatUC uc)
            {
                uc.ButtonClicked += Uc_ButtonClicked;
            }
        }

        private void Uc_ButtonClicked(object? sender, EventArgs e)
        {
            if (sender is ItemCompanyChatUC us)
            {
                checkVis = true;
                GetVis();

                usCurr = us;
                recrui = us.recrui;
                foreach (ItemCompanyChatUC control in stack.Children)
                {
                    control.GetButton();
                }
                (sender as ItemCompanyChatUC)!.Turn = 1;

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

            List<ItemCompanyChatUC> listItem;
            if (accountID == "")
            {
                RecruiDAO recruiDAO = new RecruiDAO(account!.AccountID, true);
                listItem = recruiDAO.LoadCompanyItemChat();
            }
            else
            {
                RecruiDAO recruiDAO = new RecruiDAO(accountID, true);
                listItem = recruiDAO.LoadCompanyItemChat();
            }

            foreach (var item in listItem)
            {
                stack.Children.Add(item);
                SubscribeToButtonClick(item);
            }
        }

        private void GetChat()
        {
            foreach (var item in stack.Children)
            {
                if (item is  ItemCompanyChatUC us)
                {
                    if (us.Company.Name == companyName)
                    {
                        us.btn_Click(null!, null!);
                    }
                }
            }
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            if (txbInput.Text != "Nhập để chat...")
            {
                DateTime dt = DateTime.Now;
                Message message = new Message(recrui!.CompanyID, recrui.SeekerID, "Seeker", txbInput.Text, dt);
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
