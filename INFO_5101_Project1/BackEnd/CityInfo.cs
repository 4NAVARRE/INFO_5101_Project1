using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INFO_5101_Project1.BackEnd
{
    public class CityInfo
    {
        public string capital { get; }
        public long cityId { get; }
        public string cityName { get; }
        public string cityAscii { get; }
        public int population { get; }
        public string province { get; }
        public double latitude { get; }
        public double longitude { get; }
        public string country { get; }

        public CityInfo(long cityId, string cityName, string cityAscii, int population, string province, string capital, double latitude, double longitude, string country)
        {
            this.cityId = cityId;
            this.cityName = cityName;
            this.cityAscii = cityAscii;
            this.population = population;
            this.province = province;
            this.latitude = latitude;
            this.longitude = longitude;
            this.country = country;
            this.capital = capital;
        } 

        public string GetProvince()
        {
            return province;
        }

        public int GetPopulation()
        {
            return population;
        }
        public (double, double) GetLocation()
        {
            return (latitude, longitude);
        }
    }
}
