using Application.Models;
using Application.Persistence;
using Application.Persistence.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ArticlesRepoService
    {
        private readonly AppDbContext _dbContext;
        private readonly string _baseAPIUrl = "https://api.polygon.io/v2/reference/";
        private readonly ApiKeyConfiguration _apiKeyConfig;
        private readonly IHttpClientFactory _httpClientFactory;
       
        public ArticlesRepoService(AppDbContext dbContext, IOptions<ApiKeyConfiguration> apiKeyConfig, IHttpClientFactory httpClientFactory)
        {
            this._dbContext = dbContext;
            this._apiKeyConfig = apiKeyConfig.Value;
            _httpClientFactory = httpClientFactory;
        }
        public async Task<List<Article>> GetAll()
        {
            var thenews = await _dbContext.News.ToListAsync();
            return thenews;
        }

        public async Task<List<Article>> GetnewsfromDay(int day)
        {
            DateTime nDaysAgo = DateTime.Now.AddDays(-day);
            var thenews = await _dbContext.News.Where(n=>n.published_utc >= nDaysAgo).Select(s=>s).ToListAsync();
            return thenews;
        }
        public async Task<List<Article>> GetnewsByInstrument(string instrument)
        {
            var thenews = await _dbContext.News.Where(n => n.tickers.Contains(instrument)).Select(s => s).Take(10).ToListAsync();
            return thenews;
        }
        public async Task<List<Article>> GetnewsContainsText(string text)
        {
            var thenews = await _dbContext.News.Where(n => n.description.Contains(text)).Select(s => s).ToListAsync();
            return thenews;
        }
    }
}
