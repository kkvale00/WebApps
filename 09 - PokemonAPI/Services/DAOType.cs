using _09___PokemonAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utility;
namespace _09___PokemonAPI.Services
{
    public class DAOType
    {
        private Database db;
        private static DAOType _instance;

        private DAOType() { db = new Database("pokemon"); }

        public static DAOType GetInstance()
        {
            return _instance ??= new DAOType();
        }


        public List<Types> GetAll()
        {
            var ris = new List<Types>();

            var query = "select * from types";

            List<Dictionary<string, string>> righe = db.Read(query);

            foreach (var riga in righe)
            {
                Types t = new Types();
                t.FromDictionary(riga);

                ris.Add(t);
            }
            return ris;
        }

        public Types GetByID(int id)
        {
            var query = $"select * from types where id = {id} ";

            Dictionary<string, string> riga = db.ReadOne(query);

            Types t = new Types();
            t.FromDictionary(riga);

            return t;
        }

        public void Add(Types t)
        {
            var query =
                 $"insert into types (type) values" +
                 $"('{t.Typ}');";
            db.Update(query);
        }

        public void Delete(int id)
        {
            db.Update($"delete from types where id = {id}");
        }

        public void Update(int id, Types t)
        {

            var query = $"update types set type = '{t.Typ}' where id = {id};";

            db.Update(query);

        }

    }
}
