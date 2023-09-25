using Application.Models;
using Application.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface INewsService
    {
        public Task<List<Article>> GetAllNews();
        
         public Task<List<Article>> GetNewsfromDay(int days);
        //public Task<NewsResponse> GetAllNews();
    }
}
