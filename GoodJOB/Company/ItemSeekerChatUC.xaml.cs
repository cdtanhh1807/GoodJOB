using GoodJOB.DAO;
using GoodJOB.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
    /// Interaction logic for ItemSeekerChatUC.xaml
    /// </summary>
    public partial class ItemSeekerChatUC : UserControl
    {
        public event EventHandler? ButtonClicked;

        public Recrui recrui;

        public Seeker seeker;

        private int turn = 0;

        public int Turn { get => turn; set => turn = value; }

        public ItemSeekerChatUC(Recrui recrui)
        {
            InitializeComponent();
            this.recrui = recrui;
            SeekerDAO seekerDAO = new SeekerDAO(this.recrui.SeekerID);
            seeker = seekerDAO.GetInforSeeker()!;
            txbName.Text = seeker.Name;
        }

        private void btnCheck_Click(object sender, RoutedEventArgs e)
        {
            if (turn == 1)
            {
                CheckInforWD checkInforWD = new CheckInforWD(recrui.SeekerID, "Company");
                checkInforWD.ShowDialog();
            }
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

        public void GetButton()
        {
            Turn = 0;
            btn.IsEnabled = true;
            ChangeButtonBackground(btn, "#00FFFFFF");
        }
    }
}
