using INFO_5101_Project1.BackEnd;
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
    /// Interaction logic for CitiesInfo.xaml
    /// </summary>
    public partial class CitiesInfo : Window
    {
        public CitiesInfo()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CityInfo selectedCity = BackEnd.Statistics.DisplayCityInformation(cityInputTextBox.Text);

            if (selectedCity != null)
            {
                CitiesInfoNameField.Text = selectedCity?.cityAscii;
                CitiesInfoLatitudeField.Text = selectedCity?.latitude.ToString();
                CitiesInfoLongtitudeField.Text = selectedCity?.longitude.ToString();
                CitiesInfoCountryField.Text = selectedCity?.country;
                CitiesInfoProvinceField.Text = selectedCity?.province;
                CitiesInfoPopulationField.Text = selectedCity?.population.ToString();
            }
        }

        private void CitiesInfoLocateButton_Click(object sender, RoutedEventArgs e)
        {
            BackEnd.Statistics.ShowCityOnMap(cityInputTextBox.Text);
        }
    }
}
