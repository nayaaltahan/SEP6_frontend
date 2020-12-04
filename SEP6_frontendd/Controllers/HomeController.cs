using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SEP6_frontendd.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ChartJSCore.Helpers;
using ChartJSCore.Models;
using SEP6_frontendd.Util;

namespace SEP6_frontendd.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var monthlyFlights = ApiCalls.GetMonthlyFlights();
           var monthlyFlightsOrigins = ApiCalls.GetMonthlyFlightsOrigin();

            var months = new Dictionary<int,string>
            {
                {1,"Jan"}, {2,"Feb"}, {3,"Mar"}, {4,"Apr"}, {5,"May"}, {6,"June"},
                {7, "Jul"}, {8,"Aug"}, {9, "Sep"}, {10,"Oct"}, {11, "Nov"}, {12, "Dec"}
            };

            var monthsNames = new List<string>();

            foreach (var flights in monthlyFlights)
            {
                monthsNames.Add(months.GetValueOrDefault(flights.month));
            }

            var counts = new List<double?>();

            foreach (var flight in monthlyFlights)
            {
                counts.Add(flight.count);
            }

            var chart1 = BarCharts.BuildColorfulBarChart(monthsNames, counts);


            var countsByOrigin = new List<List<double?>>();

            var origins = new List<string>();

            foreach (var monthlyFlightsOrigin in monthlyFlightsOrigins)
            {
                var counts1 = new List<double?>();
                foreach (var monthlyFlights1 in monthlyFlightsOrigin.monthlyFlights)
                {
                    counts1.Add(monthlyFlights1.count);
                }
                countsByOrigin.Add(counts1);

                origins.Add(monthlyFlightsOrigin.origin);
            }

            var chart2 = BarCharts.BuildColorfulBarChartWithManyDatasets(monthsNames, countsByOrigin, origins);

            var chart3 = BarCharts.GetStackedBarChart(monthsNames, countsByOrigin, origins);

            ViewData["chart1"] = chart1;

            ViewData["chart2"] = chart2;

            ViewData["chart3"] = chart3;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
