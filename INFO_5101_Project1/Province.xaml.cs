/**
 * FileName: Province.cs
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
    /// Interaction logic for Province.xaml
    /// </summary>
    public partial class Province : Window
    {
        public List<string> ProvList = BackEnd.Statistics.ListProvinces();
        public List<string> cities = new List<string>();
        public Province()
        {
            InitializeComponent();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            string prov = ComboBoxProvinces.Text;
            cities = BackEnd.Statistics.DisplayProvinceCities(prov);
            list.Items.Clear();
            foreach (var city in cities)
            {
                list.Items.Add(city);
            }
        }

        private void ComboBoxProvinces_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (string city in ProvList)
            {
                ComboBoxItem item = new()
                {
                    Content = city
                };
                ComboBoxProvinces.Items.Add(item);
            }
        }
    }
}
