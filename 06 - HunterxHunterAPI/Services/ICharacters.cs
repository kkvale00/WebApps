using _06___DragonBallAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _06___DragonBallAPI.Services
{
    interface ICharacters
    {
        List<Character> GetAll();
        Character GetByID(int id);
        void AddCharacter(Character character);
        void UpdateCharacter(int id, Character character);
        void DeleteCharacter(int id);
    }
}
