using Application.Models;
using Application.Persistence;
using Application.Persistence.Entities;
using Application.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Server.Models;

namespace Server.Helpers
{
    public class ScheduledTask : IHostedService, IDisposable
    {
        private readonly Timer _timer;
        private readonly DbContextOptionsBuilder<AppDbContext> _options;
        private readonly ApiKeyConfiguration _apiKeyConfig;
        private readonly AppSettings ConnectionString;
        private readonly string _baseAPIUrl = "https://api.polygon.io/v2/reference/";
        public ScheduledTask(IOptions<ApiKeyConfiguration> apiKeyConfig, IOptions<AppSettings> connectionstring)
        {
            // Create a timer that executes the TaskCallback method every hour (3600000 milliseconds)
            _timer = new Timer(TaskCallback, null, 0, 360000000);
            var _connectionstring = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

            this._apiKeyConfig = apiKeyConfig.Value;

            _options = new DbContextOptionsBuilder<AppDbContext>();
            _options.UseSqlServer(_connectionstring);

        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using(var dbContext= new AppDbContext(_options.Options))
            {
                var news = await obtainArticles();
                var theArticles = news.results.Select(r =>
                 new Article
                 { title = r.title, description = r.description, keywords = r.keywords,
                     tickers = r.tickers, published_utc = r.published_utc,
                     article_url = r.article_url, author = r.author, 
                     amp_url = r.amp_url, image_url=r.image_url });

                await dbContext.AddRangeAsync(theArticles);
                await dbContext.SaveChangesAsync();
            }
        }
        private async Task<TheNewsResponse> obtainArticles()
        {
            using var httpClient = new HttpClient();
            var requestUrl = $"{_baseAPIUrl}news?order=desc&sort=published_utc&apiKey={_apiKeyConfig.ApiKey}";
            var response = await httpClient.GetAsync(requestUrl);
            var responseBody = await response.Content.ReadAsStringAsync();
            var articlesList = JsonConvert.DeserializeObject<TheNewsResponse>(responseBody);
            return articlesList;
        }
        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }

        private void TaskCallback(object state)
        {
            Console.WriteLine("Background task executed at: " + DateTime.Now);
        }
    }
}
