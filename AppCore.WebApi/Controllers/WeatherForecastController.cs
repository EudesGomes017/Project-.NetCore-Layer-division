using AppCore.Domain;
using AppCore.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCore.WebApi.Controllers
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

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }


        //Get api/values/5
        //insert
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {   
            /*quando passamos o nome, estamos fazendo o insert*/
            var heroi = new Heroi { Nome = "Homem de Ferro" };
            using (var contexto = new HeroiContext())
            {   
                //primeira forma de fazer um insert
                contexto.Herois.Add(heroi);
                //segunda forma de fazerum insert
                //contexto.Add(heroi);
                contexto.SaveChanges();
            }
            return Ok();
        }
    }
}
