using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utility;

namespace _04___KongtunesWEB.Models
{
    public class DAOAutore
    {
        private Database db;
        private static DAOAutore instance;

        private DAOAutore() { db = new Database("04_kongtunes"); }

        public static DAOAutore GetInstance()
        {
            if (instance == null)
                instance = new DAOAutore();

            return instance;
        }

        public List<Autore> Elenco()
        {
            List<Autore> ris = new List<Autore>();
            List<Dictionary<string, string>> righe = db.Read("select * from autori");

            foreach (Dictionary<string, string> riga in righe)
            {
                Autore a = new Autore();
                a.FromDictionary(riga);

                ris.Add(a);
            }
            return ris;
        }

        public bool Salva(Autore a)
        {
            string query = "insert into autori (nome,nazione) values (" +
                            $"'{a.Nome}','{a.Nazione}')";

            return db.Update(query);
        }
    }
}
