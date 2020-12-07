using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEP6_frontendd.ApiModels
{
    public class TemperatureAttributes: Temperature
    {
        public double Dewp { get; set; }
    }
}
