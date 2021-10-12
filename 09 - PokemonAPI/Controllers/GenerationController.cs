using _09___PokemonAPI.Models;
using _09___PokemonAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _09___PokemonAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GenerationController : ControllerBase
    {
        private readonly DAOGeneration _daog;

        public GenerationController(DAOGeneration g)
        {
            _daog = g;
        }

        [HttpGet]
        public List<Generation> GetAll()
        {
            return _daog.GetAll();
        }

        [HttpGet("{id}")]
        public Generation GetById([FromRoute] int id)
        {
            return _daog.GetByID(id);
        }

        [HttpPost]
        public void Add([FromBody] Generation g)
        {
            _daog.Add(g);
        }

        [HttpDelete("{id}")]
        public void Delete([FromRoute] int id)
        {
            _daog.Delete(id);
        }

        [HttpPut("{id}")]
        public void Update([FromRoute] int id, [FromBody] Generation g)
        {
            _daog.Update(id, g);
        }

    }
}
