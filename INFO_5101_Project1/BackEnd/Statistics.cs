using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace INFO_5101_Project1.BackEnd
{
    public class Statistics
    {
        public static Dictionary<string, CityInfo> CityCatalogue { get; set; }

        public Statistics(string fileName, string fileType)
        {
            DataModeler modeler = new();
            CityCatalogue = modeler.ParseFile(fileName, fileType);
        }

        public Statistics()
        {
            CityCatalogue = new Dictionary<string, CityInfo>();
        }

        public static CityInfo? DisplayCityInformation(string Name)
        {
            Name = CheckSame(Name);
            if (Name == null)
                return null;
            if (CityCatalogue.TryGetValue(Name, out CityInfo? tmp))
            {
                return tmp;
            }
            else
            {
                return null;
            }

        }

        public static string? DisplayLargestPopulationCity(string province)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            CityInfo? tmp = null;
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
            if(tmp != null)
            {
                return tmp.cityName;
            }
            return "";

#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }

        public static string DisplaySmallestPopulationCity(string province)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            CityInfo? tmp = null;
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
            if (tmp != null)
            {
                return tmp.cityName;
            }
            return "";
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }
        public static string CompareCitiesPopulation(string city1, string city2)
        {
            CityInfo? tmp1 = null;
            CityInfo? tmp2 = null;
            foreach (var city in CityCatalogue.Values)
            {
                if (city.cityName.Equals(city1))
                {
                    tmp1 = city;
                }
                if (city.cityName.Equals(city2))
                {
                    tmp2 = city;
                }
            }
            if (tmp1 != null && tmp2 != null)
            {
                if (tmp1.population > tmp2.population)
                {
                    return tmp1.cityName + ", " + tmp1.population;
                }
                else if (tmp2.population > tmp1.population)
                {
                    return tmp2.cityName + ", " + tmp2.population;
                }
                else
                {
                    return "Both are the same size";
                }
            }
            else
            {
                ArgumentNullException argumentNullException = new($"Error city1 or city2 has a null population");
                throw argumentNullException;
            }
        }

        public static void ShowCityOnMap(string cityName)
        {
            bool test=false;

            cityName = CheckSame(cityName);
            if (cityName == "")
                return;

            foreach (var city in CityCatalogue.Values)
            {
                if(cityName.Equals(city.cityName))
                {
                    test = true;
                }
            }

            CityCatalogue.TryGetValue(cityName, out var tmp);
            
            if(test)
            {
                string url = $"https://www.google.com/maps/place/{tmp.latitude},{tmp.longitude}";
                Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
            }
            
        }
        public static int DisplayProvincePopulation(string province)
        {
            int totalPop = 0;
            foreach (var tmp in CityCatalogue.Values)
            {
                if (tmp.province == province)
                {
                    totalPop += tmp.population;
                }
            }
            return totalPop;
        }
        public static List<string> DisplayProvinceCities(string province)
        {
            List<string> list = new();
            foreach (var tmp in CityCatalogue.Values)
            {
                if (tmp.province == province)
                {
                    list.Add(tmp.cityName);
                }
            }
            return list;
        }
        public static List<string> ListCities()
        {
            List<string> list = new();
            foreach (var tmp in CityCatalogue.Values)
            {
                list.Add(tmp.cityName + ", " + tmp.province);
            }
            return list;
        }
        public static List<string> ListProvinces()
        {
            List<string> list = new();
            foreach (var tmp in CityCatalogue.Values)
            {
                list.Add(tmp.province);
            }
            return list;
        }
        public static string[] RankProvincesByPopulation()
        {
            int count = 0;
            string[] pvs = new string[13];
            List<string> list = new();
            int[] population = new int[13];
            List<int> rankedPop = new();
            foreach (var tmp in CityCatalogue.Values)
            {
                list.Add(tmp.province);
            }
            list = list.Distinct().ToList();
            foreach (var tmp in list)
            {
                pvs[count] = tmp;
                count++;
            }
            foreach (var tmp in CityCatalogue.Values)
            {
                foreach (var prov in list)
                {
                    if (tmp.province == prov)
                    {
                        for (int i = 0; i < 13; i++)
                        {
                            if (pvs[i] == prov)
                            {
                                population[i] += tmp.population;
                            }
                        }
                    }
                }
            }
            List<ProvincePopulation> provincePopulations = new();
            for (int i = 0; i < pvs.Length; i++)
            {
                provincePopulations.Add(new ProvincePopulation { Province = pvs[i], Population = population[i] });
            }
            provincePopulations.Sort((x, y) => x.Population.CompareTo(y.Population));
            string[] sortedProvinces = provincePopulations.Select(x => x.Province + ", " + x.Population).ToArray();

            return sortedProvinces;
        }

        public static string[] RankProvincesByCities()
        {
            int count = 0;
            string[] pvs = new string[13];
            List<string> list = new();
            int[] cities = new int[13];
            List<int> rankedPop = new();
            foreach (var tmp in CityCatalogue.Values)
            {
                list.Add(tmp.province);
            }
            list = list.Distinct().ToList();
            foreach (var tmp in list)
            {
                pvs[count] = tmp;
                count++;
            }
            count = 0;
            foreach (var tmp in CityCatalogue.Values)
            {
                foreach (var prov in list)
                {
                    if (tmp.province == prov)
                    {
                        for (int i = 0; i < 13; i++)
                        {
                            if (pvs[i] == prov)
                            {
                                cities[i]++;
                            }
                        }
                    }
                }
            }
            List<ProvincePopulation> provincePopulations = new();
            for (int i = 0; i < pvs.Length; i++)
            {
                provincePopulations.Add(new ProvincePopulation { Province = pvs[i], Population = cities[i] });
            }
            provincePopulations.Sort((x, y) => x.Population.CompareTo(y.Population));
            string[] sortedProvinces = provincePopulations.Select(x => x.Province + ", " + x.Population).ToArray();

            return sortedProvinces;
        }

        public static string CheckSame(string cityName)
        {
            cityName += "1";
            if (CityCatalogue.ContainsKey(cityName))
            {
                cityName = cityName.Substring(0, cityName.Length - 1);
                CityCatalogue.TryGetValue(cityName, out var findResult);
                MessageBoxResult result = MessageBox.Show($"Are you thinking about {findResult.cityAscii} in {findResult.province}", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    return cityName;
                }

                int tmp = 1;
                while (true)
                {
                    cityName += $"{tmp}";
                    if (CityCatalogue.TryGetValue(cityName, out findResult))
                        result = MessageBox.Show($"Are you thinking about {findResult.cityAscii} in {findResult.province}", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    else
                        break;
                    if (result == MessageBoxResult.Yes)
                        return cityName;

                    tmp++;
                }
                return null;
            }
            else
            {
                return cityName.Substring(0, cityName.Length - 1);
            }
        }
        public static (string, double, double) GetCapital(string prov)
        {
            foreach (var tmp in CityCatalogue.Values)
            {
                if (tmp.province == prov)
                {
                    if (tmp.capital != "")
                    {
                        return (tmp.cityName, tmp.latitude, tmp.longitude);
                    }
                }
            }
            return ("", 0, 0);
        }
        public static double CalculateDistanceBetweenCities(string city1, string city2)
        {
            if (!CityCatalogue.ContainsKey(city1) || !CityCatalogue.ContainsKey(city2))
            {
                return 0;
            }
            else if(city1=="" | city2=="")
            {
                return 0;
            }
            CityInfo city1Info = CityCatalogue[city1];
            CityInfo city2Info = CityCatalogue[city2];

            double R = 6371e3; // Earth's radius in meters
            double lat1 = city1Info.latitude * Math.PI / 180; // Convert to radians
            double lat2 = city2Info.latitude * Math.PI / 180; // Convert to radians
            double deltaLat = (city2Info.latitude - city1Info.latitude) * Math.PI / 180;
            double deltaLon = (city2Info.longitude - city1Info.longitude) * Math.PI / 180;

            double a = Math.Sin(deltaLat / 2) * Math.Sin(deltaLat / 2) +
                Math.Cos(lat1) * Math.Cos(lat2) *
                Math.Sin(deltaLon / 2) * Math.Sin(deltaLon / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            double distance = R * c;

            return distance / 1000; // Return distance in kilometers
        }
    }
    public class ProvincePopulation
    {
        public string Province { get; set; }
        public int Population { get; set; }
    }
}