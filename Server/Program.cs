using Application.Models;
using Application.Persistence;
using Application.Profiles;
using Application.Services;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Configuration.Bind("AppSettings", new ApiKeyConfiguration());
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.Configure<ApiKeyConfiguration>(builder.Configuration.GetSection("ApiKeyConfiguration"));
builder.Services.AddHttpClient();
builder.Services.AddScoped<INewsService,NewsService>();

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new ArticleProfile());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

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
