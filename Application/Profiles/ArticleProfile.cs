using Application.Models;
using Application.Persistence.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.Profiles
{

    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            CreateMap<NewsResponse, Article>().ReverseMap();
        }
    }
}
