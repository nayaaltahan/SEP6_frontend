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
            //Create First Chart
            var monthlyFlights = ApiCalls.GetMonthlyFlights();

            var monthsNames = GetMonthsNames(monthlyFlights);

            var counts = GetFlightsCounts(monthlyFlights);

            var chart1 = BarCharts.BuildColorfulBarChart(monthsNames, counts);

            //Craete Second Chart
            var monthlyFlightsOrigins = ApiCalls.GetMonthlyFlightsOrigin();


            var countsByOrigin = GetFlightsCountsByOrigin(monthlyFlightsOrigins, out var origins);

            var chart2 = BarCharts.BuildColorfulBarChartWithManyDatasets(monthsNames, countsByOrigin, origins);

            var chart3 = BarCharts.GetStackedBarChart(monthsNames, countsByOrigin, origins);

            var countsByMonth = GetCountsByMonth(countsByOrigin);

            var sortedCountedByMonth = countsByMonth
                .SelectMany(inner => inner.Select((item, index) => new { item, index }))
                .GroupBy(i => i.index, i => i.item)
                .Select(g => g.ToList())
                .ToList();

            var chart4 = BarCharts.GetStackedBarChart(monthsNames, sortedCountedByMonth, origins);

            ViewData["chart1"] = chart1;

            ViewData["chart2"] = chart2;

            ViewData["chart3"] = chart3;

            ViewData["chart4"] = chart4;

            return View();
        }

        private static List<List<double?>> GetCountsByMonth(List<List<double?>> countsByOrigin)
        {
            var countsByMonth = new List<List<double?>>();

            for (int i = 0; i < 12; i++)
            {
                var newCounts = new List<double?>();

                foreach (var counts1 in countsByOrigin)
                {
                    newCounts.Add(counts1[i]);
                }

                var total = newCounts[0] + newCounts[1] + newCounts[2];

                for (int j = 0; j < newCounts.Count; j++)
                {
                    newCounts[j] = newCounts[j] / total;
                }

                countsByMonth.Add(newCounts);
            }

            return countsByMonth;
        }

        private static List<List<double?>> GetFlightsCountsByOrigin(List<MonthlyFlightsOrigin> monthlyFlightsOrigins, out List<string> origins)
        {
            var countsByOrigin = new List<List<double?>>();

            origins = new List<string>();

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

            return countsByOrigin;
        }

        private static List<double?> GetFlightsCounts(List<MonthlyFlights> monthlyFlights)
        {
            var counts = new List<double?>();

            foreach (var flight in monthlyFlights)
            {
                counts.Add(flight.count);
            }

            return counts;
        }

        private static List<string> GetMonthsNames(List<MonthlyFlights> monthlyFlights)
        {
            var months = new Dictionary<int, string>
            {
                {1, "Jan"}, {2, "Feb"}, {3, "Mar"}, {4, "Apr"}, {5, "May"}, {6, "June"},
                {7, "Jul"}, {8, "Aug"}, {9, "Sep"}, {10, "Oct"}, {11, "Nov"}, {12, "Dec"}
            };

            var monthsNames = new List<string>();

            foreach (var flights in monthlyFlights)
            {
                monthsNames.Add(months.GetValueOrDefault(flights.month));
            }

            return monthsNames;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
