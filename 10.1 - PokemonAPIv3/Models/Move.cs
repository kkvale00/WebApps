using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _10._1___PokemonAPIv3.Models
{
    public class Move
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Power { get; set; }
        public string SpecialEffects { get; set; }
    }
}
