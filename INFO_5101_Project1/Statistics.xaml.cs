/**
 * FileName: Statistics.cs
 * Purpose: The purpose of the file is to connect statistics.cs to UI implementation.
 * Author: Kieran Primeau, Stanislav Kovalenko, Agnita Paul, Bhavin Patel
 * Creation Date: 20 February, 2023
 * 
 **/


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
    /// Interaction logic for Statistics.xaml
    /// </summary>
    public partial class Statistics : Window
    {
        public Statistics()
        {
            InitializeComponent();
        }
        private void ProvCityClick(object sender, RoutedEventArgs e)
        {
            Province provPage = new();
            provPage.Show();
        }
        private void ProvCityList_Click(object sender, RoutedEventArgs e)
        {
            Display_Province_Rank pr = new();
            pr.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CitiesInfo cityInfoPage = new();
            cityInfoPage.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DisplayProvincesInfo provPopPage = new();
            provPopPage.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Citys cityPage = new();
            cityPage.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            City_Distance_Compare cityPage = new();
            cityPage.Show();
        }

        private void CitySize_Click(object sender, RoutedEventArgs e)
        {
            Small_Large_City cityPage = new();
            cityPage.Show();
        }
    }
}
