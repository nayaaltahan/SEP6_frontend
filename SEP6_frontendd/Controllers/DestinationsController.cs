using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChartJSCore.Models;
using SEP6_frontendd.Util;

namespace SEP6_frontendd.Controllers
{
    public class DestinationsController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.SuccessBody = ApiCalls.GetDestinationFlights();

            var flightsOrigins = ApiCalls.GetDestinationOrigins();

            List<string> dests = new List<string>();
            
            List<List<double?>> counts = new List<List<double?>>();

            List<string> origins = new List<string>();

            foreach (var flightsOrigin in flightsOrigins)
            {
                if (!origins.Contains(flightsOrigin.Origin))
                {
                    origins.Add(flightsOrigin.Origin);
                }

                List<double?> countList = new List<double?>();

                foreach (var flight in flightsOrigin.Flights)
                {
                    countList.Add(flight.count);
                }

                counts.Add(countList);

                foreach (var flight in flightsOrigin.Flights)
                {
                    if (!dests.Contains(flight.Destination))
                    {
                        dests.Add(flight.Destination);
                    }
                }

                

            }

            Chart chart1 = BarCharts.BuildColorfulBarChartWithManyDatasets(dests, counts, origins);

            ViewData["chart1"] = chart1;

            return View();
        }
    }
}
