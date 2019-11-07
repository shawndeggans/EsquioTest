using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EsqFeatureToggle.MVC.Models;
using EsqFeatureToggle.MVC.RestClient;
using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.Mvc;

namespace EsqFeatureToggle.MVC.Controllers
{
    public class HomeController : Controller
    {
        // Use IFeatureManager if you want features to reflect updates to IConfiguration
        private readonly IFeatureManager _featureManager;
        // Use IFeatureManager if you want features to remain consistent during lifetime of a request
        private readonly IFeatureManagerSnapshot _featureManagerSnapshot;
        private readonly ILogger<HomeController> _logger;
        private readonly IApiClientcs _apiClientcs;

        public HomeController(ILogger<HomeController> logger, IApiClientcs apiClientcs, IFeatureManager featureManager, IFeatureManagerSnapshot featureManagerSnapshot)
        {
            _featureManager = featureManager;
            _featureManagerSnapshot = featureManagerSnapshot;
            _apiClientcs = apiClientcs;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult FeatureNotAvailable()
        {
            return View();
        }

        [FeatureGate(Features.ApplicationFeatureFlags.Privacy)]
        public IActionResult Privacy()
        {
            if(_featureManager.IsEnabled(nameof(Features.ApplicationFeatureFlags.Privacy)))
            {
                Debug.WriteLine("Privacy is enabled.");
            }
            return View();
        }

        [FeatureGate(Features.ApplicationFeatureFlags.WeatherForecast)]
        public async Task<IActionResult> WeatherForcastAsync()
        {
            if (_featureManager.IsEnabled(nameof(Features.ApplicationFeatureFlags.WeatherForecast)))
            {
                Debug.WriteLine("Weather is enabled.");
            }
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
