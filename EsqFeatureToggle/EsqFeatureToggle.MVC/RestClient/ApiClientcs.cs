using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace EsqFeatureToggle.MVC.RestClient
{
    public class ApiClientcs : IApiClientcs
    {
        private readonly Uri EndPoint = new Uri(Environment.GetEnvironmentVariable("WeatherApi"));
        private HttpClient _httpClient;

        public ApiClientcs(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Models.WeatherForcast>> GetWeatherForcastAsync()
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await _httpClient.GetAsync(EndPoint).ConfigureAwait(true);
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Models.WeatherForcast>>(content);
            } catch (Exception ex)
            {
                var s = ex.Message;
                return null;
            }
        }
    }
}
