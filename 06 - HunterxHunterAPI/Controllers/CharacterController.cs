using _06___DragonBallAPI.Models;
using _06___DragonBallAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _06___HunterxHunterAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private ICharacters _characterService = ScaffoldingCharacterService.GetInstance();

        [HttpGet]
        public List<Character> Get()
        {
            return _characterService.GetAll();
        }

        [HttpPost]
        public void AddNewCharacter([FromBody] Character character)
        {
            _characterService.AddCharacter(character);
        }

        [HttpGet("{id}")]
        public Character GetById([FromRoute] int id)
        {
            return _characterService.GetByID(id);
        }

        [HttpDelete("{id}")]
        public void DeleteByID([FromRoute] int id)
        {
            _characterService.DeleteCharacter(id);
        }

        [HttpPut("{id}")]
        public void UpdateCharacter([FromRoute] int id, [FromBody] Character character)
        {
            _characterService.UpdateCharacter(id, character);
        }

    }
}
