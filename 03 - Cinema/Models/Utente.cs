using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utility;

namespace _03___Cinema.Models
{
    public class Utente : Entity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public DateTime Dob { get; set; }
        public string Residenza { get; set; }

    }
}
