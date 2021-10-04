using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utility;

namespace _03___Cinema.Models
{
    public class Film : Entity
    {
        public string Titolo    {get;set;}
        public string Genere    {get;set;}
        public int Annouscita   {get;set;}
        public string Trama     {get;set;}
        public int Durata       {get;set;}
        public bool Vietato { get; set; }
        public string Locandina { get; set; }
        public List<Programmazione> Programmazioni { get; set; }
    }
}
