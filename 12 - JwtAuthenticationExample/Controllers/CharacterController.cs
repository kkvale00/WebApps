using _12___JwtAuthenticationExample.Models;
using _12___JwtAuthenticationExample.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _12___JwtAuthenticationExample.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _service;
        public CharacterController(ICharacterService service)
        {
            _service = service;
        }
        [HttpGet]
        public IEnumerable<Character> GetAll()
        {
            return _service.Characters();
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public void Post([FromBody] Character character)
        {
            _service.AddCharacter(character);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
