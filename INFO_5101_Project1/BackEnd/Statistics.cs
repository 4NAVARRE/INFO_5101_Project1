using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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

            return tmp.cityName;
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
            return tmp.cityName;
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
                    return tmp1.cityName + "Has the larger population.";
                }
                else if (tmp2.population > tmp1.population)
                {
                    return tmp2.cityName + "Has the larger population.";
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
        public static string[] RankProvincesByPopulation()
        {
            int count = 0;
            string[] pvs = new string[13];
            List<string> list = new();
            int[] population = new int[13];
            List<int> rankedPop = new();
            string[] combined = new string[13];
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
            for (int i = 0; i < 13; i++)
            {
                combined[i] = pvs[i] + "," + population[i];
            }
            Array.Sort(combined, (x, y) => x.CompareTo(y));

            return combined;
        }

        public static string[] RankProvincesByCities()
        {
            int count = 0;
            string[] pvs = new string[13];
            List<string> list = new();
            int[] cities = new int[13];
            List<int> rankedPop = new();
            string[] combined = new string[13];
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
            for (int i = 0; i < 13; i++)
            {
                combined[i] = pvs[i] + "," + cities[i];
            }
            Array.Sort(combined, (x, y) => x.CompareTo(y));

            return combined;
        }

        public static string CheckSame(string cityName)
        {
            cityName += cityName + "1";
            if (CityCatalogue.ContainsKey(cityName))
            {
                cityName.Remove(cityName.Length - 1, 1);
                CityCatalogue.TryGetValue(cityName, out var findResult);
                MessageBoxResult result = MessageBox.Show($"Are you thinking about {findResult.cityAscii} in {findResult.province}", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

                int tmp = 1;
                while (true)
                {
                    cityName += cityName + $"{tmp}";
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
                return cityName.Remove(cityName.Length - 1, 1);
            }
        }
    }
}