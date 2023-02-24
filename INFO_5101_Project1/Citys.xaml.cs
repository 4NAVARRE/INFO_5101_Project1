/**
 * FileName: Citys.cs
 * Purpose: the purpose of the file is to connect statistics.cs to UI implementation for comparing 2 cities population and find the largest cities between selected cities.
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
    /// Interaction logic for Citys.xaml
    /// </summary>
    public partial class Citys : Window
    {
        public List<string> CityList = BackEnd.Statistics.ListCities();
        public Citys()
        {
            InitializeComponent();
        }

        //button click event to get larger city and populations
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string[] split;
            string[] split2;
            split = City1.Text.Split(",");
            split2 = City2.Text.Split(",");
            string temp = BackEnd.Statistics.CompareCitiesPopulation(split[0], split2[0]);
            string[] test = temp.Split(",");
            if (City1.Text == City2.Text)
            {
                LargeText.Text = "Same Cities Entered";
                PopText.Text = test[1];
            }
            else
            {
                if (test[0] == split[0])
                {
                    LargeText.Text = City1.Text;
                    PopText.Text = test[1];
                }
                else
                {
                    LargeText.Text = City2.Text;
                    PopText.Text = test[1];
                }
            }
        }

        //loads all cities in first ComboBox
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

        //loads all cities in second ComboBox
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
    }
}
