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

namespace INFO_5101_Project1
{
    /// <summary>
    /// Interaction logic for Display_Province_Rank.xaml
    /// </summary>
    public partial class Display_Province_Rank : Window
    {
        public Display_Province_Rank()
        {
            InitializeComponent();
        }

        private void cityList_Loaded(object sender, RoutedEventArgs e)
        {
            string[] cities=BackEnd.Statistics.RankProvincesByCities();
            cityList.Clear();
            foreach (var city in cities)
            {
                cityList.Text += city +"\n";
            }
        }

        private void popList_Loaded(object sender, RoutedEventArgs e)
        {
            string[] pop = BackEnd.Statistics.RankProvincesByPopulation();
            popList.Clear();
            foreach (var city in pop)
            {
                popList.Text += city + "\n";
            }
        }
    }
}
