using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Weather_API.Services
{
    public interface IWeatherService
    {
        Weather GetCurrent(String town);
      
        String GetCurrentTempTown(String town);
        List<Weather> GetWeatherForecastTown(String town);
    }
}