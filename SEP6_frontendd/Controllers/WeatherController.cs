using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChartJSCore.Models;
using SEP6_frontendd.Util;

namespace SEP6_frontendd.Controllers
{
    public class WeatherController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.SuccessBody = ApiCalls.GetWeathersByOrigin();

            var temperatures = ApiCalls.GetTemperaturesJfk();

            var chart1 = BubbleCharts.BuildTemperatureBubbleChart(temperatures);

            var temperaturesOrigin = ApiCalls.GetTemperatureAttributes();

            var chart2 = BubbleCharts.BuildTemperatureAttributesBubbleChart(temperaturesOrigin);

            var meanTemperatures = ApiCalls.GetMeanTemperaturesJfk();

            var chart3 = BubbleCharts.BuildTemperatureBubbleChart(meanTemperatures);

            var meanTemperaturesOrigin = ApiCalls.GetMeanTemperaturesOrigin();

            var chart4 = BubbleCharts.BuildTemperatureAttributesBubbleChart1(meanTemperaturesOrigin);

            ViewData["chart1"] = chart1;

            ViewData["chart2"] = chart2;

            ViewData["chart3"] = chart3;

            ViewData["chart4"] = chart4;

            return View();
        }
    }
}
