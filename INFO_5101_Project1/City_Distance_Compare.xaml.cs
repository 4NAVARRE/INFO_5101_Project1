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
    /// Interaction logic for City_Distance_Compare.xaml
    /// </summary>
    public partial class City_Distance_Compare : Window
    {
        public List<string> CityList = BackEnd.Statistics.ListCities();

        public City_Distance_Compare()
        {
            InitializeComponent();
        }

        private void City1_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (string city in CityList)
            {
                ComboBoxItem item = new()
                {
                    Content = city
                };
                City1.Items.Add(item);
            }
        }

        private void City2_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (string city in CityList)
            {
                ComboBoxItem item = new()
                {
                    Content = city
                };
                City2.Items.Add(item);
            }
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            string[] split;
            string[] split2;
            split = City1.Text.Split(",");
            split2 = City2.Text.Split(",");
            double temp = BackEnd.Statistics.CalculateDistanceBetweenCities(split[0], split2[0]);
            if (City1.Text == City2.Text && City1.Text != "Cities")
            {
                DistanceText.Text = "Same Cities Entered";
            }
            else if(temp != null && temp !=0)
            {
                DistanceText.Text = temp.ToString("#.##") + " KM";

            }
        }
    }
}
