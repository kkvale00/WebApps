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
    public class TypeController : ControllerBase
    {
        private readonly DAOType _daot;

        public TypeController(DAOType t)
        {
            _daot = t;
        }

        [HttpGet]
        public List<Types> GetAll()
        {
            return _daot.GetAll();
        }

        [HttpGet("{id}")]
        public Types GetById([FromRoute] int id)
        {
            return _daot.GetByID(id);
        }

        [HttpPost]
        public void Add([FromBody] Types t)
        {
            _daot.Add(t);
        }

        [HttpDelete("{id}")]
        public void Delete([FromRoute] int id)
        {
            _daot.Delete(id);
        }

        [HttpPut("{id}")]
        public void Update([FromRoute] int id, [FromBody] Types t)
        {
            _daot.Update(id, t);
        }





    }
}
