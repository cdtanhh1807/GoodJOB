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
using System.Windows.Shapes;

namespace GoodJOB.Home
{
    /// <summary>
    /// Interaction logic for CheckInforWD.xaml
    /// </summary>
    public partial class CheckInforWD : Window
    {
        string accountID = "";

        string role = "";

        public CheckInforWD(string accountID, string role)
        {
            InitializeComponent();
            this.accountID = accountID;
            this.role = role;
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void main_Loaded(object sender, RoutedEventArgs e)
        {
            if (role == "Company")
            {
                SolidColorBrush brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF284241"));
                bd.BorderBrush = brush;
                SeekerInforUC seekerInforUC = new SeekerInforUC(accountID);
                Grid.SetRow(seekerInforUC, 0);
                Grid.SetColumn(seekerInforUC, 1);
                main.Children.Add(seekerInforUC);
            }
            else
            {
                SolidColorBrush brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F9F2e8"));
                bd.BorderBrush = brush;
                CompanyInforUC companyInforUC = new CompanyInforUC(accountID);
                Grid.SetRow(companyInforUC, 0);
                Grid.SetColumn(companyInforUC, 1);
                main.Children.Add(companyInforUC);
            }
        }
    }
}
