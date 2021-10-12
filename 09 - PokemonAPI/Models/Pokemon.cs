using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utility;
namespace _09___PokemonAPI.Models
{
    public class Pokemon : Entity
    {
        public string Name { get; set; }
        public double Weigth { get; set; }
        public Generation Generation { get; set; }
        public List<Types> Types { get; set; }
        public List<Move> Moves { get; set; }







    }
}
