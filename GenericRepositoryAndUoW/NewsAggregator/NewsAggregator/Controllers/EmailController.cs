using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace NewsAggregator.Controllers
{
    public class EmailController : Controller
    {
        private readonly IConfiguration _configuration;

        public EmailController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            var x = _configuration.GetSection("Emails").GetChildren().ToList();

            var dict = x
                .Select(el 
                    => new KeyValuePair<string, string>(el.Key, el.Value))
                .ToDictionary(keyValuePair => keyValuePair.Key, 
                    keyValuePair => keyValuePair.Value);

            return View();
        }
    }
}
