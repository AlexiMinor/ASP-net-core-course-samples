using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NewsAggregator.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using NewsAggregator.Core.DataTransferObjects;
using NewsAggregator.Filters;
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
        
            return View();

        }

        [ChromeFilter(01, 02)]
        public IActionResult Privacy()
        {
            return View();
        }

        
        [ServiceFilter(typeof(CheckDataFilterAttribute))]
        public IActionResult Privacy1(int hiddenId, IEnumerable<NewsDto> news)
        {
            return View("Privacy");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
