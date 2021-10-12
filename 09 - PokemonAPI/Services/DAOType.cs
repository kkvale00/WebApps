using _09___PokemonAPI.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utility;
namespace _09___PokemonAPI.Services
{
    public class DAOType
    {
        private static DAOType _instance;
        private Database db;

        /*ci richiamo l'iconfig per importante il database, dopo aver creato DB
         * 
        protected readonly Database db;
        public DAOType(IConfiguration config)
        {
            db = new Database(config["Db:Name"]);
        }

        */
        private DAOType() { db = new Database("pokemon"); }

        public static DAOType GetInstance()
        {
            return _instance ??= new DAOType();
        }




        /*alternative List GetAll()
         * public list<pokemontype
         *         public List<Types> GetAll()
        {
            var results = db.Read("select * from types;");
            return results.Select(result => FromDictionary(result)).ToList();
        }

        private Types FromDictionary(Dictionary<string, string> result)
        {
            if (result is null)
            {
                return null;
            }
            return new Types { Id = int.Parse(result["id"]), Typ = result["type"] };
        }
         * 
         * 
         */
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
        /*
         * alternative to getbyid
         *         public Types GetById(int id)
        {
            return FromDictionary(

                db.ReadOne($"SELECT * FROM types WHERE id = {id};";
                
                );


         */

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
