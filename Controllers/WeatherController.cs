global using Weather_API.Models;
global using Weather_API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Weather_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherController : ControllerBase
    {   
        private static IWeatherService _weatherService;
        public WeatherController(IWeatherService weatherService)
        {
            _weatherService=weatherService;
        }
       
        [HttpGet("{town}")]
        public ActionResult<Weather> GetCurrent(String town){
            return Ok(_weatherService.GetCurrent(town));
        }
       
        [HttpGet("/currentTemp/{town}")]
        public ActionResult<int> GetCurrentTempTown(String town){
            
            return Ok(_weatherService.GetCurrentTempTown(town));
        }

        [HttpGet("/weatherForecast/{town}")]
        public ActionResult<String> GetWeatherForecastTown(String town){
            return Ok(_weatherService.GetWeatherForecastTown(town));
        }

    }
}