﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{



    public class Publisher
    {
        public string name { get; set; }
        public string homepage_url { get; set; }
        public string logo_url { get; set; }
        public string favicon_url { get; set; }
    }

    public class Result
    {
        public string id { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public DateTime published_utc { get; set; }
        public string article_url { get; set; }
        public List<string> tickers { get; set; }
        public string? amp_url { get; set; }
        public string image_url { get; set; }
        public string description { get; set; }
        public List<string> keywords { get; set; }
    }

    public class TheNewsResponse
    {
        public List<Result> results { get; set; }
        public string status { get; set; }
        public string request_id { get; set; }
        public int count { get; set; }
        public string next_url { get; set; }
    }


    public class ArticlesModel
    {
        public string id { get; set; }
        public Publisher publisher { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public DateTime published_utc { get; set; }
        public string article_url { get; set; }
        public List<string> tickers { get; set; }
        public string amp_url { get; set; }
        public string image_url { get; set; }
        public string description { get; set; }
        public List<string> keywords { get; set; }
    }

   

  

}
