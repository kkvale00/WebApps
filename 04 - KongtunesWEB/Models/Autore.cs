using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utility;
namespace _04___KongtunesWEB.Models
{
    public class Autore : Entity
    {
        public Autore()
        {
        }

        public Autore(int id, string nome, string nazione) 
            : base(id)
        {
            Nome = nome;
            Nazione = nazione;
        }

        public string Nome { get; set; }
        public string Nazione { get; set; }
    }
}
