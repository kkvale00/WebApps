using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utility;
namespace _04___KongtunesWEB.Models
{
    public class Album : Entity
    {
        public Album()
        {
        }

        public Album(int id, string nome, string genere, DateTime datapubblicazione, int idautore)
            : base(id)
        {
            Nome = nome;
            Genere = genere;
            Datapubblicazione = datapubblicazione;
            Idautore = idautore;
        }

        public string Nome {get;set;}
        public string Genere {get;set;}
        public DateTime Datapubblicazione{get;set;}
        public int Idautore {get;set;}
    }
}
