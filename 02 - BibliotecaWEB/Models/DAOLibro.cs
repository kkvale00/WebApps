using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utility;
namespace _02___BibliotecaWEB.Models
{
    public class DAOLibro
    {
        private Database db;

        public static DAOLibro instance = null;

        private DAOLibro()
        {
            db = new Database("Biblioteca");

        }

        public static DAOLibro GetInstance()
        {
            if (instance == null)
                instance = new DAOLibro();

            return instance;
        }

        public Libro Cerca(int id)
        {
            string query = $"select * from libri where id = {id} ";

            Dictionary<string, string> riga = db.ReadOne(query);

            Libro l = new Libro();
            l.FromDictionary(riga);

            return l;
        }

        public List<Libro> Elenco()
        {
            List<Libro> ris = new List<Libro>();

            string query = "select * from libri";

            List<Dictionary<string, string>> righe = db.Read(query);

            foreach (Dictionary<string, string> riga in righe)
            {
                Libro l = new Libro();
                l.FromDictionary(riga);

                ris.Add(l);
            }
            return ris;
        }

        public bool Insert(Libro l)
        {
            string query =
                 $"insert into libri (titolo,genere,annopubblicazione,linguaoriginale,copiemagazzino,idautore) " +
                 $"values('{l.Titolo}', '{l.Genere}', {l.Annopubblicazione}, '{l.Linguaoriginale}',{l.Copiemagazzino},{l.Idautore});";


            return db.Update(query);
        }

        public bool Update(Libro l)
        {
            string query =
            $"update libri set titolo = '{l.Titolo}'," +
            $"genere = '{l.Genere}', annopubblicazione = {l.Annopubblicazione}, linguaoriginale = '{l.Linguaoriginale}'," +
            $"copiemagazzino = {l.Copiemagazzino}, idautore = {l.Idautore} where id = {l.Id}";

            return db.Update(query);
        }

        public bool Delete(int id)
        {
            string query = $"delete from libri where id = {id}";

            return db.Update(query);
        }

       

    }
}
