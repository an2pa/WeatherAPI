using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;



namespace Weather_API.Services
{
    public class WeatherService : IWeatherService
    {
        


        public Weather GetCurrent(String town)
        {
            var client = new HttpClient();
            var url = $"https://api.weatherbit.io/v2.0/current?city={town}&key=26f2d4953dd949e4988d3ed461818964";
            var weatherResponse = client.GetStringAsync(url).Result;
            var formattedResponseMain = JObject.Parse(weatherResponse);
            var dataArray = formattedResponseMain["data"];
            var firstDataItem = dataArray[0];
            var weatherDescription = firstDataItem["weather"];
            var description = weatherDescription.Value<string>("description");
            Weather weather = new Weather
            {
                Town = dataArray[0].Value<String>("city_name"),
                Date = DateTime.Parse(dataArray[0].Value<string>("datetime").Split(':')[0]),
                Temperature = dataArray[0].Value<float>("temp"),
                Description = description
            };
            Console.WriteLine(dataArray[0]["weather"].Value<String>("datetime"));

            return weather;
        }

        public List<Weather> GetHistoryTown(String town, String start_date, String end_date)
        {   
            List<Weather> weathers = new List<Weather>();
            var client = new HttpClient();
            var url = $"https://api.weatherbit.io/v2.0/history/daily?city={town}&start_date={start_date}&end_date={end_date}&key=26f2d4953dd949e4988d3ed461818964";
            var weatherResponse = client.GetStringAsync(url).Result;
            var formattedResponseMain = JObject.Parse(weatherResponse);
            var dataArray = formattedResponseMain["data"];
            
            foreach (var item in dataArray)
            {
                Console.WriteLine("datetime: " + item["datetime"] + " " + item["temp"] + " " + formattedResponseMain["city_name"]);
                Weather weather1 = new Weather
                {
                    Town = formattedResponseMain["city_name"].ToString(),
                    Date = DateTime.Parse(item["datetime"].ToString()),
                    Temperature =float.Parse(item["temp"].ToString()),
                    Description = " "
                };
                Console.WriteLine(weather1);
                weathers.Add(weather1);
            }
           Console.WriteLine(weathers);
            var weathersToReturn=weathers.Distinct();
            return weathersToReturn.ToList();

        }




        public List<Weather> GetWeatherForecastTown(String town)
        {
           List<Weather> weathers = new List<Weather>();
            var client = new HttpClient();
            var url = $"https://api.weatherbit.io/v2.0/forecast/daily?city={town}&key=26f2d4953dd949e4988d3ed461818964";
            var weatherResponse = client.GetStringAsync(url).Result;
            var formattedResponseMain = JObject.Parse(weatherResponse);
            var dataArray = formattedResponseMain["data"];
            
            foreach (var item in dataArray)
            {
                Console.WriteLine("datetime: " + item["datetime"] + " " + item["temp"] + " " + formattedResponseMain["city_name"]);
                Weather weather1 = new Weather
                {
                    Town = formattedResponseMain["city_name"].ToString(),
                    Date = DateTime.Parse(item["datetime"].ToString()),
                    Temperature =float.Parse(item["temp"].ToString()),
                    Description = item["weather"]["description"].ToString()
                };
                Console.WriteLine(weather1);
                weathers.Add(weather1);
            }
           Console.WriteLine(weathers);
            var weathersToReturn=weathers.Distinct();
            return weathersToReturn.ToList();

        
        return weathers;
        }
    }
}