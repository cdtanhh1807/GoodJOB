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

namespace GoodJOB
{
    /// <summary>
    /// Interaction logic for PostSeekerWD.xaml
    /// </summary>
    public partial class PostSeekerWD : Window
    {
        public PostSeekerWD(PostSeekerUC postSeekerUC)
        {
            InitializeComponent();
            main.Children.Add(postSeekerUC);
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
