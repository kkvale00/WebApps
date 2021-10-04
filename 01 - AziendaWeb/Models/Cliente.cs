using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utility;
namespace _01___AziendaWeb.Models
{
    public class Cliente : Entity
    {
        public Cliente()
        {
        }

        public Cliente(int id, string nominativo, string piva, int annofondazione, string settore, string servizioacquistato, int capitale) 
                    : base(id)
        {
            Nominativo = nominativo;
            Piva = piva;
            Annofondazione = annofondazione;
            Settore = settore;
            Servizioacquistato = servizioacquistato;
            Capitale = capitale;
        }

        public string Nominativo {get;set;}
        public string Piva {get;set;}
        public int Annofondazione {get;set;}
        public string Settore {get;set;}
        public string Servizioacquistato {get;set;}
        public int Capitale{ get; set; }
    }
}
