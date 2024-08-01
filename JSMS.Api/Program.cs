using HtmlAgilityPack;
using IdentityServer3.Core.Services;
using JSMS.Api.Controllers;
using JSMS.Api.JwtTokenGenerator;
using JSMS.Api.Services;
using JSMS.Domain.Models;
using JSMS.Persitence.Repositories;
using JSMS.Persitence.WebScraping.BibleChapter;
using JSMS.Persitence.WebScraping.VerseOfTheDay;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MySql.Data.MySqlClient;
using Swashbuckle.AspNetCore.Filters;
using System.Data;
using System.Text;


var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

// Add services to the container.
builder.Services.AddScoped<IDbConnection>(sp =>
    new MySqlConnection(builder.Configuration.GetConnectionString("MySqlConnection")));

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<RegisterRepository>();
builder.Services.AddScoped<LoginRepository>();
builder.Services.AddScoped<UserController>();
builder.Services.AddScoped<JwtTokenAuthGen>();
builder.Services.AddScoped<HttpClient>();
builder.Services.AddScoped<HtmlDocument>();
builder.Services.AddScoped<BibleChapter>();

//---------------------For Generating Verse-----------------------------------------
builder.Services.AddScoped<VerseOfTheDayWebScrapper>(provider =>
{
    var configuration = provider.GetRequiredService<IConfiguration>();
    var url = configuration["ScraperSettings:VerseUrl"]!;
    var node = configuration["ScraperSettings:verseNode"]!;
    return new VerseOfTheDayWebScrapper(url, node);
});

//---------------------For Generating Verse Location-----------------------------------------
builder.Services.AddScoped<VerseLocationWebScrapper>(provider =>
{
    var configuration = provider.GetRequiredService<IConfiguration>();
    var url = configuration["ScraperSettings:VerseUrl"]!;
    var node = configuration["ScraperSettings:VerseLocationNode"]!;
    return new VerseLocationWebScrapper(url, node);
});

builder.Services.AddScoped<BibleChapterWebScraper>();



builder.Services.AddAuthorization();
builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oath2", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

builder.Services.AddAuthentication().AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateAudience = true,
        ValidateIssuer = true,
        ValidAudience = builder.Configuration["JwtSettings:Audience"],
        ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("JwtSettings:Key").Value!)),
    };
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseAuthorization();

app.MapControllers();

app.Run();


