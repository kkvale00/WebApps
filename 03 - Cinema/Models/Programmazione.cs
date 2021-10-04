using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utility;

namespace _03___Cinema.Models
{
    public class Programmazione : Entity
    {
        public int Idfilm { get; set; }
        public int Sala { get; set; }
        public DateTime Orario { get; set; }


    }
}
