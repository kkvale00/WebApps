using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utility;

namespace _03___Cinema.Models
{
    public class DAOFilm
    {
        private Database db;
        private static DAOFilm instance;

        private DAOFilm() { db = new Database("cinema"); }

        public static DAOFilm GetInstance()
        {
            if (instance == null)
                instance = new DAOFilm();

            return instance;
        }

        public List<Film> Elenco()
        {
            List<Film> ris = new List<Film>();
            List<Dictionary<string, string>> righe = db.Read("select * from film");

            foreach (Dictionary<string,string> riga in righe)
            {
                Film f = new Film();
                f.FromDictionary(riga);

                //TODO: manca da valorizzare la lista di programmazione del film!
               ris.Add(f);
            }
            return ris;
        }

        public bool Salva(Film f)
        {
            string query = "insert into film (titolo,genere,annouscita,trama,durata,vietato,locandina) values" +
                            $"('{f.Titolo}','{f.Genere}',{f.Annouscita},'{f.Trama}',{f.Durata},{f.Vietato},'{f.Locandina}')";




            return db.Update(query);
        }



    }
}
