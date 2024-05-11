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
    /// Interaction logic for ItemPostSeerUC.xaml
    /// </summary>
    public partial class ItemPostSeerUC : UserControl
    {
        public event EventHandler? btnClicked;
        PostSeeker postSeeker;

        public PostSeeker PostSeeker { get => postSeeker; set => postSeeker = value; }

        public ItemPostSeerUC(PostSeeker postSeeker)
        {
            InitializeComponent();
            this.PostSeeker = postSeeker;
            txblJob.Text = postSeeker.Job;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            btnClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
