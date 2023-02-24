/**
 * FileName: DisplayProvincesInfo.cs
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
    /// Interaction logic for DisplayProvincesInfo.xaml
    /// </summary>
    public partial class DisplayProvincesInfo : Window
    {
        public List<string> ProvList = BackEnd.Statistics.ListProvinces();
        public DisplayProvincesInfo()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string prov = ComboBoxProvinces.Text;
            ProvPop.Text = BackEnd.Statistics.DisplayProvincePopulation(prov).ToString();
            ProvCap.Text = BackEnd.Statistics.GetCapital(prov).Item1;
            ProvLat.Text = BackEnd.Statistics.GetCapital(prov).Item2.ToString();
            ProvLon.Text = BackEnd.Statistics.GetCapital(prov).Item3.ToString();
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
