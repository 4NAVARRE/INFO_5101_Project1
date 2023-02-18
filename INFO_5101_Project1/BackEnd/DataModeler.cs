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

        public Dictionary<string, CityInfo> data = new Dictionary<string, CityInfo>();
        public delegate void ParsingMethod(string fileName);

        public void ParseXML(string fileName)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);

            XmlNodeList cityNodes = doc.SelectNodes("//city");
            foreach (XmlNode cityNode in cityNodes)
            {
                string cityName = cityNode.SelectSingleNode("name").InnerText;
                string cityAscii = cityNode.SelectSingleNode("name_ascii").InnerText;
                double latitude = double.Parse(cityNode.SelectSingleNode("latitude").InnerText);
                double longitude = double.Parse(cityNode.SelectSingleNode("longitude").InnerText);
                string country = cityNode.SelectSingleNode("country").InnerText;
                string province = cityNode.SelectSingleNode("province").InnerText;
                int population = int.Parse(cityNode.SelectSingleNode("population").InnerText);
                int cityID = int.Parse(cityNode.Attributes["id"].Value);  
                

                CityInfo cityInfo = new CityInfo(cityID, cityName, cityAscii, population, province, latitude, longitude, country);
                data.Add(cityName, cityInfo);
            }
        }

        public void ParseJSON(string fileName)
        {
            // Code to parse JSON file
            string json = File.ReadAllText(fileName);
            JArray cityArray = JArray.Parse(json);

            foreach (JObject cityObject in cityArray)
            {
                string cityName = (string)cityObject["name"];
                string cityAscii = (string)cityObject["name_ascii"];
                double latitude = (double)cityObject["latitude"];
                double longitude = (double)cityObject["longitude"];
                string country = (string)cityObject["country"];
                string province = (string)cityObject["province"];
                int population = (int)cityObject["population"];
                int cityID = (int)cityObject["id"];

                CityInfo cityInfo = new CityInfo(cityID, cityName, cityAscii, population, province, latitude, longitude, country);
                data.Add(cityName, cityInfo);
            }
        }

        public void ParseCSV(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            {
                reader.ReadLine(); // Skip header line

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    string cityName = values[0];
                    string cityAscii = values[1];
                    double latitude = double.Parse(values[2]);
                    double longitude = double.Parse(values[3]);
                    string country = values[4];
                    string province = values[5];
                    int population = int.Parse(values[6]);
                    int cityID = int.Parse(values[7]);
                   
                    CityInfo cityInfo = new CityInfo(cityID, cityName, cityAscii, population, province, latitude, longitude, country);
                    data.Add(cityName, cityInfo);
                }
            }
        }

        public Dictionary<string, CityInfo> ParseFile(string fileName, string fileType)
        {
            data = new Dictionary<string, CityInfo>();
            ParsingMethod parser = null;

            switch (fileType.ToLower())
            {
                case "xml":
                    parser = ParseXML;
                    break;
                case "json":
                    parser = ParseJSON;
                    break;
                case "csv":
                    parser = ParseCSV;
                    break;
                default:
                    throw new ArgumentException("Wrong file type");
            }

            parser(fileName);


            return data;
        }
    }
}
