using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _06___HunterxHunterAPI.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Power { get; set; }
        public DateTime Dob { get; set; }
    }
}
