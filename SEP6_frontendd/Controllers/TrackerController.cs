using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEP6_frontendd.Controllers
{
    public class TrackerController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.SuccessBody = ApiCalls.GetMeanAirtime();
            ViewBag.table2 = ApiCalls.GetMeanDelay();
            return View();
        }
    }
}
