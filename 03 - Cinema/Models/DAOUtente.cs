using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utility;
namespace _03___Cinema.Models
{
    public class DAOUtente
    {
        private Database db;
        private static DAOUtente instance;

        private DAOUtente() { db = new Database("cinema"); }

        public static DAOUtente GetInstance()
        {
            if (instance == null)
                instance = new DAOUtente();

            return instance;
        }

        public List<Utente> Elenco()
        {
            List<Utente> ris = new List<Utente>();
            List<Dictionary<string, string>> righe = db.Read("select * from utenti");

            foreach (Dictionary<string, string> riga in righe)
            {
                Utente u = new Utente();
                u.FromDictionary(riga);

                ris.Add(u);
            }
            return ris;
        }

        public bool Salva(Utente u)
        {
            string query = "insert into utenti (username,password,nome,cognome,dob,residenza) values" +
                            $"('{u.Username}','{u.Password}','{u.Nome}','{u.Cognome}','{u.Dob.Year}-{u.Dob.Month}-{u.Dob.Day}','{u.Residenza}')";

            return db.Update(query);
        }
    }
}
