using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NewsAggregator.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Serilog;

namespace NewsAggregator.Controllers
{
    public class HomeController : Controller
    {
        
        public HomeController()
        {
        }

        public IActionResult Index()
        {
            try
            {
                //throw new NullReferenceException("test");

            }
            catch (Exception e)
            {
                Log.Fatal(e, "Unhanded exception was throwed by app");
            }
            return View();

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
