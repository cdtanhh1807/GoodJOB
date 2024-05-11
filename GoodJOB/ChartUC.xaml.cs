using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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

namespace GoodJOB
{
    /// <summary>
    /// Interaction logic for ChartUC.xaml
    /// </summary>
    public partial class ChartUC : UserControl
    {
        ChartDAO chartDAO = new ChartDAO();

        List<int> list = new List<int>();

        List<string> listStr = new List<string>();

        public ChartUC()
        {
            InitializeComponent();

            Get();

            SeriesCollection = new SeriesCollection();

            for (int i=0;i< list.Count; i++)
            {
                var columnSeries = new ColumnSeries
                {
                    Title = listStr[i],
                    Values = new ChartValues<int> { list[i] },
                    MaxColumnWidth = 50,
                    Fill = GetColor(),
                    DataLabels = true,
                    LabelPoint = point => point.Y.ToString(),
                    StrokeThickness = 0,
                    ToolTip = null
                };
                
                SeriesCollection.Add(columnSeries);
            }

            string[] str = new string[] { "Công ty" };
            Labels = str;
            Values = value => value.ToString("N");
            PointLabel = chartPoint => string.Format("{0}({1:P})", chartPoint.Y, chartPoint.Participation);

            DataContext = this;
        }

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<int, string> Values { get; set; }
        public Func<ChartPoint, string> PointLabel { get; set; }

        private void PieChart_DataClick(object sender, ChartPoint chartPoint)
        {
            var chart = (LiveCharts.Wpf.PieChart)chartPoint.ChartView;
            foreach(PieSeries item in chart.Series)
            {
                item.PushOut = 0;
            }
            var selectedSeries = (PieSeries)chartPoint.SeriesView;
            selectedSeries.PushOut = 0;
        }

        private void Get()
        {
            
            list = chartDAO.GetLikeCompnay();

            listStr = chartDAO.LoadNameCompnay();

            List<Tuple<string, int>> listNum = chartDAO.LoadNumRecrui();

            foreach(var item in listNum)
            {
                CompanyDAO companyDAO = new CompanyDAO(item.Item1);
                string name = companyDAO.GetNameCompany();
                PieSeries temp = CreatePie(name, item.Item2);
                myPieChart.Series.Add(temp);
            }
        }

        private PieSeries CreatePie(string title, int value)
        {
            SolidColorBrush brush = GetColor();
            PieSeries newSeries = new PieSeries
            {
                Title = title,
                Values = new ChartValues<int> { value },
                DataLabels = true,
                LabelPoint = chartPoint => string.Format("{0}({1:P})", chartPoint.Y, chartPoint.Participation),
                Fill = brush
            };
            return newSeries;
        }

        private Random random = new Random();

        private SolidColorBrush GetColor()
        {
            Color minColor = (Color)ColorConverter.ConvertFromString("#FF284241");
            Color maxColor = (Color)ColorConverter.ConvertFromString("#FF677271");

            Color randomColor = GetRandomColor(minColor, maxColor);

            SolidColorBrush brush = new SolidColorBrush(randomColor);

            return brush;
        }

        private Color GetRandomColor(Color minColor, Color maxColor)
        {
            byte red = (byte)random.Next(minColor.R, maxColor.R + 1);
            byte green = (byte)random.Next(minColor.G, maxColor.G + 1);
            byte blue = (byte)random.Next(minColor.B, maxColor.B + 1);

            return Color.FromRgb(red, green, blue);
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            DependencyObject parent = VisualTreeHelper.GetParent(this);
            if (parent is Panel panel)
            {
                panel.Children.Remove(this);
            }
            else if (parent is ContentControl contentControl)
            {
                contentControl.Content = null;
            }
        }
    }
}
