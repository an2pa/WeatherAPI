using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Weather_API.Models
{
    public class Weather
    {
        public String Town { get; set; } = "Sarajevo";
        public DateTime Date { get; set; }
        public float Temperature { get; set; }
        public String Description { get; set; } = "Not known";
    }
}