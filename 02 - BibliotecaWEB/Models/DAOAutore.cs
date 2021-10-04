using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utility;


namespace _02___BibliotecaWEB.Models
{
    public class DAOAutore 
    {
        private Database db;

        public static DAOAutore instance = null;

        private DAOAutore()
        {
            db = new Database("Biblioteca");

        }

        public static DAOAutore GetInstance()
        {
            if (instance == null)
                instance = new DAOAutore();

            return instance;
        }

        public Autore Cerca(int id)
        {
            string query = $"select * from autori where id = {id} ";

            Dictionary<string, string> riga = db.ReadOne(query);

            Autore a = new Autore();
            a.FromDictionary(riga);

            return a;
        }

        public List<Autore> Elenco()
        {
            List<Autore> ris = new List<Autore>();

            string query = "select * from autori";

            List<Dictionary<string, string>> righe = db.Read(query);

            foreach (Dictionary<string, string> riga in righe)
            {
                Autore a = new Autore();
                a.FromDictionary(riga);

                ris.Add(a);
            }
            return ris;
        }

        public bool Insert(Autore a)
        {
            string query =
                 $"insert into Autori (nome,cognome,dob,nazione) " +
                 $"values('{a.Nome}', '{a.Cognome}', '{a.Dob.Year}-{a.Dob.Month}-{a.Dob.Day}', '{a.Nazione}');";


            return db.Update(query);
        }

        public bool Update(Autore a)
        {

            string query =
            $"update autori set nome = '{a.Nome}'," +
            $"cognome = '{a.Cognome}', dob = '{a.Dob:yyyy-MM-dd}', nazione = '{a.Nazione}'" +
            $" where id = {a.Id}";

            return db.Update(query);
        }

        public bool Delete(int id)
        {
            string query = $"delete from autori where id = {id}";

            return db.Update(query);
        }
    }
}
