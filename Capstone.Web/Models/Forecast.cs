﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class Forecast
    {
        public double HighTemp { get; set; }
        public double LowTemp { get; set; }
        public string Condition { get; set; }
        public int ForecastDay { get; set; }

        public string GetAdvisory()
        {
            if (Condition == "rain")
            {
                return "Pack rain gear and wear waterproff shoes.";
            }
            else if (Condition == "thunderstorms")
            {
                return "Seek shelter and avoid hiking on exposed ridges.";
            }
            else if (Condition == "sun")
            {
                return "Pack sunblock.";
            }
            else if (Condition == "snow")
            {
                return "Pack snowshoes.";
            }
            else
                return "Cloudy skies.";
        }

        public string GetTempAdvisory()
        {
            string tempAdvice = "";
            if(HighTemp > 75)
            {
                tempAdvice += "The temperature is higher than 75, make sure you bring an extra gallon of water. ";
            }
            if(HighTemp-LowTemp > 20)
            {
                tempAdvice += "Wear breathable layers clothes. ";
            }
           if(LowTemp<20)
            {
                tempAdvice += "Beware of the dangers of exposure to frigid temperatures.";
            }
            return tempAdvice;
        }

        public double GetCelsius(double temperature)
        {
            return ((temperature - 32) * 5) / 9;
        }
    }
}