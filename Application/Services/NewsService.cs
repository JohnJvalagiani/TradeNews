using Application.Models;
using Application.Persistence;
using Application.Persistence.Entities;
using AutoMapper;
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
        private readonly ArticlesRepoService _articlesRepoService;
        private readonly IMapper _mapper;
        public NewsService(IMapper mapper, ArticlesRepoService articlesRepoService)
        {
            _mapper= mapper;
            _articlesRepoService = articlesRepoService;
        }
        public async Task<List<Article>> GetAllNews()
        {
           return await _articlesRepoService.GetAll();
        }

        public Task<List<Article>> GetNewsfromDay(int days)
        {
            throw new NotImplementedException();
        }
    }
}
