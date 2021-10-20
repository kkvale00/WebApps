using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _11___EntityFrameworkEX.Models
{
    public class Moves
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Power { get; set; }
        public string Description { get; set; }
        public int SuperheroID { get; set; }
    }
}
