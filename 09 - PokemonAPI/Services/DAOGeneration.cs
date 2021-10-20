using _09___PokemonAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utility;
namespace _09___PokemonAPI.Services
{
    public class DAOGeneration
    {

        private Database db;
        private static DAOGeneration _instance;

        private DAOGeneration() { db = new Database("pokemon"); }

        public static DAOGeneration GetInstance()
        {
            return _instance ??= new DAOGeneration();
        }

        public List<Generation> GetAll()
        {
            var ris = new List<Generation>();

            var query = "select * from generations";

            List<Dictionary<string, string>> righe = db.Read(query);

            foreach (var riga in righe)
            {
                Generation g = new Generation();
                g.FromDictionary(riga);

                ris.Add(g);
            }
            return ris;
        }

        public Generation GetByID(int id)
        {
            var query = $"select * from Generation where id = {id} ";

            Dictionary<string, string> riga = db.ReadOne(query);

            Generation g = new Generation();
            g.FromDictionary(riga);

            return g;
        }

        public void Add(Generation g)
        {
            var query =
                 $"insert into generations (generation) values" +
                 $"('{g.Generations}');";
            db.Update(query);
        }

        public void Delete(int id)
        {
            db.Update($"delete from types where id = {id}");
        }

        public void Update(int id, Generation g)
        {

            var query = $"update generations set generation = '{g.Generations}' where id = {id};";

            db.Update(query);

        }

        /*
         *         
        public GenerationsDao(IConfiguration config) : base(config) { }

        public List<Generation> GetAll()
        {
            return db.Read("SELECT * FROM generations;")
                     .Select(result => FromDictionary(result))
                     .ToList();
        }

        public Generation GetById(int id)
        {
            return FromDictionary
            (
                db.ReadOne($"SELECT * FROM generations WHERE id = {id};")
            );
        }

        private Generation FromDictionary(Dictionary<string, string> result)
        {
            return new Generation
            {
                Id = int.Parse(result["id"]),
                Gen = int.Parse(result["generation"])
            };
        }
         */
    }
}
