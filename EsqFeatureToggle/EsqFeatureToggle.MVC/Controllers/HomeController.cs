using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EsqFeatureToggle.MVC.Models;
using EsqFeatureToggle.MVC.RestClient;

namespace EsqFeatureToggle.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IApiClientcs _apiClientcs;

        public HomeController(ILogger<HomeController> logger, IApiClientcs apiClientcs)
        {
            _apiClientcs = apiClientcs;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> WeatherForcastAsync()
        {
            var ForcastList = await _apiClientcs.GetWeatherForcastAsync();
            return View(ForcastList);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
