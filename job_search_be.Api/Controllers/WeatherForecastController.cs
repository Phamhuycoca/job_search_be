﻿using job_search_be.Application.Helpers;
using job_search_be.Application.Wrappers.Concrete;
using job_search_be.Infrastructure.Common.Utilities;
using job_search_be.Infrastructure.Enum;
using job_search_be.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace job_search_be.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }
        [Authorize]
        [HasPermission(Permission.List)]
        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpGet("Users")]
        public IActionResult GetUser([FromQuery] CommonListQuery query)
        {
                return Ok(query);
           
        }
        [HttpGet("Hello")]
        public IActionResult Hello()
        {
            return Ok("Hello");
        }
    }
}