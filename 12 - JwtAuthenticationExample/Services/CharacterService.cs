using _12___JwtAuthenticationExample.Data;
using _12___JwtAuthenticationExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _12___JwtAuthenticationExample.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly DataContext _ctx;
        public CharacterService(DataContext ctx)
        {
            _ctx = ctx;
        }


        public Character AddCharacter(Character newcharacter)
        {
           var createdchar = _ctx.Characters.Add(newcharacter);

            _ctx.SaveChanges();

            return createdchar.Entity;
        }

        public List<Character> Characters()
        {
           return _ctx.Characters.ToList();
        }
    }
}
