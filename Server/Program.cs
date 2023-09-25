using Application.Models;
using Application.Persistence;
using Application.Profiles;
using Application.Services;
using AutoMapper;
using Hangfire;
using Hangfire.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Server.Helpers;
using Server.Models;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Configuration.Bind("AppSettings", new ApiKeyConfiguration());
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.Configure<ApiKeyConfiguration>(builder.Configuration.GetSection("ApiKeyConfiguration"));
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("ConnectionStrings"));
builder.Services.AddHttpClient();
builder.Services.AddScoped<INewsService,NewsService>();
builder.Services.AddAutoMapper(typeof(ArticleProfile));
//builder.Services.AddHostedService<ScheduledTask>();
builder.Services.AddScoped<ArticlesRepoService>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
