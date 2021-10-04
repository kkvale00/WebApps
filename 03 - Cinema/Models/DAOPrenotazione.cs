using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utility;

namespace _03___Cinema.Models
{
    public class DAOPrenotazione
    {
        private Database db;
        private static DAOPrenotazione instance;

        private DAOPrenotazione() { db = new Database("cinema"); }

        public static DAOPrenotazione GetInstance()
        {
            if (instance == null)
                instance = new DAOPrenotazione();

            return instance;
        }

        public List<Prenotazione> Elenco()
        {
            List<Prenotazione> ris = new List<Prenotazione>();
            List<Dictionary<string, string>> righe = db.Read("select * from prenotazioni");

            foreach (Dictionary<string, string> riga in righe)
            {
                Prenotazione p = new Prenotazione();
                p.FromDictionary(riga);

                ris.Add(p);
            }
            return ris;
        }  
        public Prenotazione Cerca(string username)
        {
            string query = $"select * from prenotazioni where username = {username} ";

            Dictionary<string, string> riga = db.ReadOne(query);

            Prenotazione p = new Prenotazione();
            p.FromDictionary(riga);

            return p;
        }

    }
}
