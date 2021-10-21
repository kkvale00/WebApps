using _12___JwtAuthenticationExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _12___JwtAuthenticationExample.Services
{
    public interface ICharacterService
    {
        List<Character> Characters();

        Character AddCharacter(Character newcharacter);

    }
}
