using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEP6_frontendd.ApiModels
{
    public class DestinationOrigin 
    {
        public string Origin { get; set; }

        public List<DestinationFlights> Flights { get; set; }
    }
}
