using Application.Models;
using Application.Persistence;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class NewsService : INewsService
    {
        private readonly AppDbContext _dbContext;
        private readonly string _baseAPIUrl = "https://api.polygon.io/v2/reference/";
        private readonly ApiKeyConfiguration _apiKeyConfig;
        private readonly IHttpClientFactory _httpClientFactory;
        public NewsService(IOptions<ApiKeyConfiguration> apiKeyConfig, IHttpClientFactory httpClientFactory)
        {
                this._apiKeyConfig = apiKeyConfig.Value;
                _httpClientFactory = httpClientFactory;
        }
        public async Task<NewsResponse> GetAllNews()
        {
            using var httpClient = new HttpClient();
            var requestUrl = $"{_baseAPIUrl}news?order=desc&sort=published_utc&apiKey={_apiKeyConfig.ApiKey}";
            var response = await httpClient.GetAsync(requestUrl);
            var responseBody = await response.Content.ReadAsStringAsync();
            var movieList = JsonConvert.DeserializeObject<NewsResponse>(responseBody);
            return movieList;
        }
        //public async Task SaveAricles(List<NewsResponse> news)
        //{
        //    _dbContext.AddRangeAsync(news);
        //}
    }
}
