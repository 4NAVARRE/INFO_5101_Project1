/**
 * FileName: DataModeler.cs
 * Purpose: It holds the information of parsing data from a particular file.
 * Author: Kieran Primeau, Stanislav Kovalenko, Agnita Paul, Bhavin Patel
 * Creation Date: 20 February, 2023
 * 
 **/
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace INFO_5101_Project1.BackEnd
{
    public class DataModeler
    {

        public Dictionary<string, CityInfo> data = new();
        public delegate void ParsingMethod(string fileName);

        //Parse XML and grabs all information from a certain file
        private void ParseXML(string fileName)
        {
            XmlDocument doc = new();
            List <string> duplicated = new List<string> ();
            int tmp = 1;
            doc.Load(fileName);
            XmlNodeList cityNodes = doc.SelectNodes("//CanadaCity");
            foreach (XmlNode cityNode in cityNodes)
            {
                string cityName = cityNode.SelectSingleNode("city").InnerText;
                string cityAscii = cityNode.SelectSingleNode("city_ascii").InnerText;
                double latitude = double.Parse(cityNode.SelectSingleNode("lat").InnerText);
                double longitude = double.Parse(cityNode.SelectSingleNode("lng").InnerText);
                string country = cityNode.SelectSingleNode("country").InnerText;
                string province = cityNode.SelectSingleNode("admin_name").InnerText;
                string capital = cityNode.SelectSingleNode("capital").InnerText;
                int population = int.Parse(cityNode.SelectSingleNode("population").InnerText);
                int cityID = int.Parse(cityNode.SelectSingleNode("id").InnerText);
                CityInfo cityInfo = new(cityID, cityName, cityAscii, population, province, capital, latitude, longitude, country);
                try
                {
                    data.Add(cityName, cityInfo);
                }
                catch
                {
                    string ifExist= "";
                    while (true)
                    {
                        ifExist = cityName + $"{tmp}";
                        if (!duplicated.Contains(ifExist))
                            break;
                        tmp++;
                    }
                    
                    data.Add(ifExist, cityInfo);

                    
                }
            }
        }

        //Parse JSON and grabs all information from a certain file
        private void ParseJSON(string fileName)
        {
            // Code to parse JSON file
            string json = File.ReadAllText(fileName);
            List<string> duplicated = new List<string>();
            JArray cityArray = JArray.Parse(json);
            int tmp = 1;

            foreach (JObject cityObject in cityArray)
            {
                try
                {
                    string cityName = (string)cityObject["city"];
                    string cityAscii = (string)cityObject["city_ascii"];
                    double latitude = (double)cityObject["lat"];
                    double longitude = (double)cityObject["lng"];
                    string country = (string)cityObject["country"];
                    string province = (string)cityObject["admin_name"];
                    string capital = (string)cityObject["capital"];
                    int population = (int)cityObject["population"];
                    int cityID = (int)cityObject["id"];

                    CityInfo cityInfo = new(cityID, cityName, cityAscii, population, province, capital, latitude, longitude, country);
                    try
                    {
                        data.Add(cityName, cityInfo);
                    }
                    catch
                    {
                        string ifExist = "";
                        while (true)
                        {
                            ifExist = cityName + $"{tmp}";
                            if (!duplicated.Contains(ifExist))
                                break;
                            tmp++;
                        }

                        data.Add(ifExist, cityInfo);


                    }
                }
                catch { }
            }
        }

        //Parse CSV and grabs all information from a certain file
        private void ParseCSV(string fileName)
        {
            using StreamReader reader = new(fileName);
            int tmp = 1;
            List<string> duplicated = new List<string>();
            reader.ReadLine(); // Skip header line
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                var values = line.Split(',');
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                string cityName = values[0];
                string cityAscii = values[1];
                double latitude = double.Parse(values[2]);
                double longitude = double.Parse(values[3]);
                string country = values[4];
                string province = values[5];
                string capital = values[6];
                int population = int.Parse(values[7]);
                int cityID = int.Parse(values[8]);

                CityInfo cityInfo = new(cityID, cityName, cityAscii, population, province, capital, latitude, longitude, country);
                try
                {
                    data.Add(cityName, cityInfo);
                }
                catch
                {
                    string ifExist = "";
                    while (true)
                    {
                        ifExist = cityName + $"{tmp}";
                        if (!duplicated.Contains(ifExist))
                            break;
                        tmp++;
                    }

                    data.Add(ifExist, cityInfo);


                }
            }
        }
        public Dictionary<string, CityInfo> ParseFile(string fileName, string fileType)
        {
            data = new Dictionary<string, CityInfo>();
            ParsingMethod parser = fileType.ToLower() switch
            {
                "xml" => ParseXML,
                "json" => ParseJSON,
                "csv" => ParseCSV,
                _ => throw new ArgumentException("Wrong file type"),
            };
            parser(fileName);
            return data;
        }
    }
}
