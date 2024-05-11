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
using System.Windows.Threading;

namespace GoodJOB
{
    /// <summary>
    /// Interaction logic for ReplyRecruiUC.xaml
    /// </summary>
    public partial class ReplyRecruiUC : UserControl
    {
        Recrui recrui;

        List<Message> list = new List<Message>();

        List<Message> sortedMessages = new List<Message>();

        public ReplyRecruiUC(Recrui recrui)
        {
            InitializeComponent();
            this.recrui = recrui;
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
                    DateTime dt = DateTime.Now;
                    Message message = new Message(recrui.CompanyID, recrui.SeekerID, "Seeker", txbInput.Text, dt);
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

        private void gridMain_Loaded(object sender, RoutedEventArgs e)
        {
            Get();
        }

        private void Get()
        {
            MessageDAO messageDAO = new MessageDAO(recrui.CompanyID, recrui.SeekerID);
            list = messageDAO.LoadMessage();

            sortedMessages = list.OrderBy(m => m.Time).ToList();

            stackChat.Children.Clear();

            foreach (var message in sortedMessages)
            {
                AutoGrowingTextBox autoGrowingTextBox = new AutoGrowingTextBox("Seeker", message.Role, message.Mess);
                stackChat.Children.Add(autoGrowingTextBox);
            }
        }

        private void scr_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Dispatcher.BeginInvoke(DispatcherPriority.ContextIdle, new System.Action(() =>
            {
                scr.Focus();
            }));
        }
    }
}
