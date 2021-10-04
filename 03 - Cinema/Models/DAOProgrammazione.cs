using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utility;

namespace _03___Cinema.Models
{
    public class DAOProgrammazione
    {
        private Database db;
        private static DAOProgrammazione instance;

        private DAOProgrammazione() { db = new Database("cinema"); }

        public static DAOProgrammazione GetInstance()
        {
            if (instance == null)
                instance = new DAOProgrammazione();

            return instance;
        }

        public List<Programmazione> Elenco()
        {
            List<Programmazione> ris = new List<Programmazione>();
            List<Dictionary<string, string>> righe = db.Read("select * from programmazioni");

            foreach (Dictionary<string, string> riga in righe)
            {
                Programmazione p = new Programmazione();
                p.FromDictionary(riga);

                ris.Add(p);
            }
            return ris;
        }

        public Programmazione Cerca(int idfilm)
        {
            string query = $"select * from programmazione where idfilm = {idfilm} ";

            Dictionary<string, string> riga = db.ReadOne(query);

            Programmazione p = new Programmazione();
            p.FromDictionary(riga);

            return p;
        }

    }
}
