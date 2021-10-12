using _09___PokemonAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utility;
namespace _09___PokemonAPI.Services
{
    public class DAOMove
    {
        private Database db;
        private static DAOMove _instance;

        private DAOMove() { db = new Database("pokemon"); }

        public static DAOMove GetInstance()
        {
            return _instance ??= new DAOMove();
        }

        public List<Move> GetAll()
        {
            var ris = new List<Move>();

            var query = "select * from moves";

            List<Dictionary<string, string>> righe = db.Read(query);

            foreach (var riga in righe)
            {
                Move m = new Move();
                m.FromDictionary(riga);

                ris.Add(m);
            }
            return ris;
        }
        public Move GetByID(int id)
        {
            var query = $"select * from moves where id = {id} ";

            Dictionary<string, string> riga = db.ReadOne(query);

            Move m = new Move();
            m.FromDictionary(riga);

            return m;
        }

        public void Add(Move m)
        {
            var query =
                 $"insert into moves (name,type,power,specialeffects) values" +
                 $"('{m.Name}','{m.Movetype}',{m.Power},'{m.SpecialEffects}');";
            db.Update(query);
        }

        public void Delete(int id)
        {
            db.Update($"delete from moves where id = {id}");
        }

        public void Update(int id, Move m)
        {

            var query = $"update moves set name = '{m.Name}',type ='{m.Movetype}'," +
                $"power = {m.Power},specialeffects = '{m.SpecialEffects}' where id = {id};";

            db.Update(query);

        }
    }
}
