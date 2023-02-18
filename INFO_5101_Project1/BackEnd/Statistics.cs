using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INFO_5101_Project1.BackEnd
{
    public class Statistics
    {
        public Dictionary<string, CityInfo> CityCatalogue { get; }

        public Statistics(string fileName, string fileType)
        {
            DataModeler modeler = new DataModeler();
            CityCatalogue = modeler.ParseFile(fileName, fileType);
        }

        public CityInfo DisplayCityInformation(string Name)
        {
            if (CityCatalogue.TryGetValue(Name, out CityInfo tmp))
            {
                return tmp;
            }
            else
            {
                return null;
            }
            
        }

        public string DisplayLargestPopulationCity(string province)
        {
            CityInfo tmp = null; 
            foreach (var city in CityCatalogue.Values) 
            {
                if ((tmp == null) && (city.province == province))
                {
                    tmp = city;
                }
                if ((city.province == province) && (city.population > tmp.population))
                {
                    tmp = city;
                }
            }
            return tmp.cityName;
        }

        public string DisplaySmallestPopulationCity(string province)
        {
            CityInfo tmp = null;
            foreach (var city in CityCatalogue.Values)
            {
                if ((tmp == null) && (city.province == province))
                {
                    tmp = city;
                }
                if ((city.province == province) && (city.population < tmp.population))
                {
                    tmp = city;
                }
            }
            return tmp.cityName;
        }

    }
}
