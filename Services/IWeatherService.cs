using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Weather_API.Services
{
    public interface IWeatherService
    {
        Weather GetCurrent(String town);
      
        List<Weather> GetHistoryTown(String town, String start_date, String end_date);
        List<Weather> GetWeatherForecastTown(String town);
    }
}