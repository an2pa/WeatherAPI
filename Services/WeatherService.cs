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
         private static List<Weather> weathers= new List<Weather>();


        public Weather GetCurrent(String town)
        {
            var client= new HttpClient();
            var url=$"https://api.weatherbit.io/v2.0/current?city={town}&key=26f2d4953dd949e4988d3ed461818964";
            var weatherResponse= client.GetStringAsync(url).Result;
            var formattedResponseMain= JObject.Parse(weatherResponse);
            var dataArray = formattedResponseMain["data"];
            var firstDataItem = dataArray[0];
            var weatherDescription = firstDataItem["weather"];
            var description = weatherDescription.Value<string>("description");
            Weather weather=new Weather{
                Town= dataArray[0].Value<String>("city_name"),
                Date=dataArray[0].Value<String>("datetime"),
                Temperature=dataArray[0].Value<String>("temp"),
                Description=description
                };
            Console.WriteLine(dataArray[0]["weather"].Value<String>("datetime"));

            return weather;
        }

        public string GetCurrentTempTown(string town)
        {
            throw new NotImplementedException();
        }

        public List<Weather> GetWeatherForecastTown(string town)
        {
            throw new NotImplementedException();
        }
    }
}