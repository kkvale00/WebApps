using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utility;

namespace _02___BibliotecaWEB.Models
{
    public class Autore : Entity
    {
        public Autore() { }

        public Autore(int id, string nome, string cognome, DateTime dob, string nazione)
                    : base(id)
        {
            Nome = nome;
            Cognome = cognome;
            Dob = dob;
            Nazione = nazione;
        }

        public string Nome {get;set;}
        public string Cognome {get;set;}
        public DateTime Dob{get;set;}
        public string Nazione {get;set; }





    }
}
