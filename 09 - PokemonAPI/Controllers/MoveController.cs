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
    public class MoveController : ControllerBase
    {
        private readonly DAOMove _daom;

        public MoveController(DAOMove m)
        {
            _daom = m;
        }

        [HttpGet]
        public List<Move> GetAll()
        {
            return _daom.GetAll();
        }

        [HttpGet("{id}")]
        public Move GetById([FromRoute] int id)
        {
            return _daom.GetByID(id);
        }

        [HttpPost]
        public void Add([FromBody] Move m)
        {
            _daom.Add(m);
        }

        [HttpDelete("{id}")]
        public void Delete([FromRoute] int id)
        {
            _daom.Delete(id);
        }

        [HttpPut("{id}")]
        public void Update([FromRoute] int id, [FromBody] Move m)
        {
            _daom.Update(id, m);
        }


    }
}
