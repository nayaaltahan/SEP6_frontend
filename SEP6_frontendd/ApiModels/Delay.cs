using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEP6_frontendd.ApiModels
{
    public class Delay
    {
        public string Origin { get; set; }
        public double ArrivalDelay { get; set; }
        public double DepartureDelay { get; set; }
    }
}
