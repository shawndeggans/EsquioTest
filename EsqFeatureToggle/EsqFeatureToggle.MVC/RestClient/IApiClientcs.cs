using System.Threading.Tasks;
using EsqFeatureToggle.MVC.Models;
using System.Collections.Generic;

namespace EsqFeatureToggle.MVC.RestClient
{
    public interface IApiClientcs
    {
        Task<List<WeatherForcast>> GetWeatherForcastAsync();
    }
}