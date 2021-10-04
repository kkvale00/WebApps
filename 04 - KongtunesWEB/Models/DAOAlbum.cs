using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utility;
namespace _04___KongtunesWEB.Models
{
    public class DAOAlbum
    {
        private Database db;
        private static DAOAlbum instance;

        private DAOAlbum() { db = new Database("04_kongtunes"); }

        public static DAOAlbum GetInstance()
        {
            if (instance == null)
                instance = new DAOAlbum();

            return instance;
        }

        public List<Album> Elenco()
        {
            List<Album> ris = new List<Album>();
            List<Dictionary<string, string>> righe = db.Read("select * from album");

            foreach (Dictionary<string, string> riga in righe)
            {
                Album a = new Album();
                a.FromDictionary(riga);

                ris.Add(a);
            }
            return ris;
        }

        public bool Salva(Album a)
        {
            string query = "insert into album (nome,genere,datapubblicazione,idautore) values (" +
                            $"'{a.Nome}','{a.Genere}','{a.Datapubblicazione.Year}-{a.Datapubblicazione.Month}-{a.Datapubblicazione.Day}',{a.Idautore})";

            return db.Update(query);
        }
    }
}
