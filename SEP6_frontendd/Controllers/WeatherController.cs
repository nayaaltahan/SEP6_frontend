using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChartJSCore.Models;
using SEP6_frontendd.ApiModels;
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

            var chartAtt1 = BubbleCharts.BuildTemperatureAttributesBubbleChart(temperaturesOrigin[0], Colors.GetRed(), Colors.GetRedBorder());

            var chartAtt2 = BubbleCharts.BuildTemperatureAttributesBubbleChart(temperaturesOrigin[1], Colors.GetBlue(), Colors.GetBlueBorder());

            var chartAtt3 = BubbleCharts.BuildTemperatureAttributesBubbleChart(temperaturesOrigin[2], Colors.GetGreen(), Colors.GetGreenBorder() );

            var meanTemperatures = ApiCalls.GetMeanTemperaturesJfk();

            var chart3 = BubbleCharts.BuildTemperatureBubbleChart(meanTemperatures);

            var meanTemperaturesOrigin = ApiCalls.GetMeanTemperaturesOrigin();

            var chart4 = BubbleCharts.BuildTemperatureAttributesBubbleChart1(meanTemperaturesOrigin);

            ViewData["chart1"] = chart1;

            ViewData["chart21"] = chartAtt1;

            ViewData["chart22"] = chartAtt2;

            ViewData["chart23"] = chartAtt3;

            ViewData["chart3"] = chart3;

            ViewData["chart4"] = chart4;

            return View();
        }
    }
}
