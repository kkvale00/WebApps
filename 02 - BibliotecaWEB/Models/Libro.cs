using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utility;
namespace _02___BibliotecaWEB.Models
{
    public class Libro : Entity
    {
        public Libro() { }

        public Libro(int id, string titolo, string genere, int annopubblicazione, string linguaoriginale, int copiemagazzino, int idautore)
                  : base(id)
        {
            Titolo = titolo;
            Genere = genere;
            Annopubblicazione = annopubblicazione;
            Linguaoriginale = linguaoriginale;
            Copiemagazzino = copiemagazzino;
            Idautore = idautore;
        }

        public string Titolo {get;set;}
        public string Genere {get;set;}
        public int Annopubblicazione {get;set;}
        public string Linguaoriginale {get;set;}
        public int Copiemagazzino {get;set;}
        public int Idautore { get; set; }
    }
}
