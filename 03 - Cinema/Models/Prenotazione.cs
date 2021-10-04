using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utility;

namespace _03___Cinema.Models
{
    public class Prenotazione : Entity
    {              
        public int IdProgrammazione { get; set; }
        public string Username { get; set; }
        public int NPosti { get; set; }



    }
}
