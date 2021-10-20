using _11___EntityFrameworkEX.Models;
using _11___EntityFrameworkEX.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _11___EntityFrameworkEX.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHeroService _service;

        // Dipendency Injection del nostro service
        public SuperHeroController(ISuperHeroService service)
        {
            _service = service;
        }

        [HttpGet]
        public List<SuperHero> GetAll()
        {

            return _service.GetAll(); 
        }

        [HttpPost]
        public SuperHero Add([FromBody] SuperHero newsuperhero)
        {
            return _service.AddNew(newsuperhero);

        }

        [HttpGet("{id}")]
        public SuperHero GetByID([FromRoute] int id)
        {
            return _service.GetByID(id);
        }

        [HttpDelete("{id}")]
        public SuperHero Delete([FromRoute] int id)
        {
            return _service.DeleteById(id);
        }
    }
}
