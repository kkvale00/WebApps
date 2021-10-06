using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _05___DummyAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        /*private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }*/

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            /*
            List<int> numeri = new List<int> { 1, 3, 4, 5231, 3155, 3, 8 };
            var numeriPari = from n in numeri where n % 2 == 0 select n;
            foreach (var n in numeriPari)
            {
                Console.WriteLine(n);
            }
            Console.WriteLine("========================");
            var nPari = numeri.Where(n => n % 2 == 0);
            foreach (var n in nPari)
            {
                Console.WriteLine(n);
            }
            */

            List<string> nomi = new List<string> { "Mario", "Pippo", "Alessia" };

            // Select fa in modo di generare un nuovo IEnumerable
            // a partire da uno esistente, sfuttando la lambda expression passata come
            // parametro
            var lunghezzaNomi = nomi.Select(n => n.Length);

            foreach (var l in lunghezzaNomi)
            {
                Console.WriteLine(l);
            }

            var lunghezzeRaddoppiate = lunghezzaNomi.Select(n => n * 2);

            foreach (var l in lunghezzeRaddoppiate)
            {
                Console.WriteLine(l);
            }

            var prova = nomi.Select(x => x.Length).Select(x => x * 2);

            List<int> ris = new List<int>();

            foreach (var n in nomi)
            {
                ris.Add(n.Length);
            }

            var lunghezzaNomiQ = from n in nomi select n.Length;

            /*
            foreach (var n in Enumerable.Range(5, 10))
            {
                Console.WriteLine(n);
            }
            */
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
