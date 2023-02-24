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
    /// Interaction logic for Small_Large_City.xaml
    /// </summary>
    public partial class Small_Large_City : Window
    {
        public List<string> ProvList = BackEnd.Statistics.ListProvinces();
        public List<string> cities = new List<string>();
        public Small_Large_City()
        {
            InitializeComponent();
        }

        private void ProvinceCombo_Loaded(object sender, RoutedEventArgs e)
        {
                foreach (string city in ProvList)
                {
                    ComboBoxItem item = new()
                    {
                        Content = city
                    };
                    ProvinceCombo.Items.Add(item);
                }
        }

        private void SearchInfo_CitySize_Loaded(object sender, RoutedEventArgs e)
        {
            string prov = ProvinceCombo.Text;
            //string temp = BackEnd.Statistics.DisplayLargestPopulationCity(prov);
            //LargestCity.Text = temp;

            //string temp1 = BackEnd.Statistics.DisplayLargestPopulationCity(prov);
            //SmallestCity.Text = "Same Cities Entered";
        }
    }
}
