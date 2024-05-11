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
    /// Interaction logic for AutoGrowingTextBox.xaml
    /// </summary>
    public partial class AutoGrowingTextBox : UserControl
    {
        string role = "";

        string text = "";

        string roleAcc = "";

        public AutoGrowingTextBox(string roleAcc, string role, string text)
        {
            InitializeComponent();
            this.role = role;
            this.text = text;
            this.roleAcc = roleAcc;
            Get();
        }

        private void CheckLeng()
        {
            if (txb.Text.Length < 38) txb.Width = double.NaN;
        }

        private void Get()
        {
            txb.Text = text;
            if (roleAcc == "Seeker")
            {
                txb.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF284241"));
                txb.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F9F2e8"));
                if (role == "Company")
                {
                    txb.HorizontalAlignment = HorizontalAlignment.Left;
                    
                }
                else
                {
                    txb.HorizontalAlignment = HorizontalAlignment.Right;
                    txb.TextAlignment = TextAlignment.Right;
                    txb.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F9F2e8"));
                    txb.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF284241"));
                }
            }
            else
            {
                txb.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F9F2e8"));
                txb.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF284241"));
                if (role == "Company")
                {
                    txb.HorizontalAlignment = HorizontalAlignment.Right;
                    txb.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF284241"));
                    txb.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F9F2e8"));
                }
                else
                {
                    txb.HorizontalAlignment = HorizontalAlignment.Left;
                    txb.TextAlignment = TextAlignment.Left;
                }
            }

            CheckLeng();
        }
    }
}
