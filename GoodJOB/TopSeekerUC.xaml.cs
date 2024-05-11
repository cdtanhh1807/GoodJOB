using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    /// Interaction logic for TopSeekerUC.xaml
    /// </summary>
    public partial class TopSeekerUC : UserControl
    {
        public event EventHandler? ButtonClicked;

        Seeker? seeker;

        int rank;

        string role = "";

        public Seeker? Seeker { get => seeker; set => seeker = value; }

        public TopSeekerUC(Seeker seeker, int rank, string role)
        {
            InitializeComponent();
            this.Seeker = seeker;
            this.rank = rank;
            this.role = role;
        }

        private void Get()
        {
            if (rank < 5)
            {
                if (role == "Seeker")
                {
                    bd.BorderBrush = Brushes.Transparent;
                    bdRank.Opacity = 0.175;
                    bdInfor.Opacity = 0.175;
                }
                else
                {
                    SolidColorBrush brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F9F2e8"));
                    bd.BorderBrush = Brushes.Transparent;
                    bdRank.Background = brush;
                    bdRank.Opacity = 1;
                    bdInfor.Background = brush;
                    bdInfor.Opacity = 1;
                }
            }

            txblRank.Text = rank.ToString();
            txblName.Text = Seeker!.Name.ToString();
            txblLike.Text = Seeker.Like.ToString() + " likes";
        }

        private void Border_Loaded(object sender, RoutedEventArgs e)
        {
            Get();
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            ButtonClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
