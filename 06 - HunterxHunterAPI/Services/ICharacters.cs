using _06___HunterxHunterAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _06___HunterxHunterAPI.Services
{
    interface ICharacters
    {
        List<Character> GetAll();
        Character GetByID(int id);
        void AddPerson(Character character);
        void UpdatePerson(int id, Character character);
        void DeletePerson(int id);
    }
}
