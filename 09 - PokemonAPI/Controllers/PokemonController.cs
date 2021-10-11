using _09___PokemonAPI.Models;
using _09___PokemonAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _09___PokemonAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly DAOPokemon _daop;

        public PokemonController(DAOPokemon d)
        {
            _daop = d;
        }

        [HttpGet]
        public List<Pokemon> GetAll()
        {
            return _daop.GetAll();
        }

        [HttpGet("{id}")]
        public Pokemon GetById([FromRoute] int id)
        {
            return _daop.GetByID(id);
        }

        [HttpPost]
        public void Add([FromBody] Pokemon p)
        {
            _daop.Add(p);
        }

        [HttpDelete("{id}")]
        public void Delete([FromRoute] int id)
        {
            _daop.Delete(id);
        }

        [HttpPut("{id}")]
        public void Update([FromRoute] int id, [FromBody] Pokemon p)
        {
            _daop.Update(id, p);
        }



    }
}
