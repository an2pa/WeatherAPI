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
       
        [HttpGet("/current/{town}")]
        public ActionResult<Weather> GetCurrent(String town){
            return Ok(_weatherService.GetCurrent(town));
        }
       
        [HttpGet("/history/{town}/{start_date}/{end_date}")]
        public ActionResult<List<Weather>> GetCurrentTempTown(String town, String start_date, String end_date){
            
            return Ok(_weatherService.GetHistoryTown(town, start_date, end_date));
        }

        [HttpGet("/weatherForecast/{town}")]
        public ActionResult<String> GetWeatherForecastTown(String town){
            return Ok(_weatherService.GetWeatherForecastTown(town));
        }

    }
}