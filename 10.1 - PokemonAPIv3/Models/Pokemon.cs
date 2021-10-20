using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _10._1___PokemonAPIv3.Models
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Weight { get; set; }
        public Generation Generation { get; set; }
        public PokemonType[] Types { get; set; }
        public Move[] Moves { get; set; }
    }
}
