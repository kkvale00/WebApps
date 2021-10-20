using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _11___EntityFrameworkEX.Models
{
    public class SuperHero
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Strength { get; set; }
        public bool CanFly { get; set; }
    }
}
