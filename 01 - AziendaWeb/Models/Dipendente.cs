using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utility;
namespace _01___AziendaWeb.Models
{
    public class Dipendente : Entity
    { 
        public Dipendente() { }

        public Dipendente(int id, string nome, string cognome, DateTime dob, string reparto, string residenza) 
                        : base(id)
        {
            Nome = nome;
            Cognome = cognome;
            Dob = dob;
            Reparto = reparto;
            Residenza = residenza;
        }

        public string Nome      {get;set;}
        public string Cognome   {get;set;}
        public DateTime Dob     {get;set;}
        public string Reparto   {get;set;}
        public string Residenza {get;set;}
    }
}
