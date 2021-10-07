using _06___DragonBallAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utility;
namespace _06___DragonBallAPI.Services
{
    public class ScaffoldingCharacterService : ICharacters
    {
        private Database db;
        private static ScaffoldingCharacterService _instance;

        private ScaffoldingCharacterService() { db = new Database("dragonball"); }

        public static ScaffoldingCharacterService GetInstance()
        {
            return _instance ??= new ScaffoldingCharacterService();
        }

        public List<Character> GetAll()
        {
            List<Character> ris = new List<Character>();

            string query = "select * from characters";

            List<Dictionary<string, string>> righe = db.Read(query);

            foreach (Dictionary<string, string> riga in righe)
            {
                Character c = new Character();
                c.FromDictionary(riga);

                ris.Add(c);
            }
            return ris;
        }

        public Character GetByID(int id)
        {
            string query = $"select * from characters where id = {id} ";

            Dictionary<string, string> riga = db.ReadOne(query);

            Character c = new Character();
            c.FromDictionary(riga);

            return c;
        }
        public void AddCharacter(Character c)
        {
            string query =
                 $"insert into characters (name,power,dob) values" +
                 $"('{c.Name}',{c.Power},'{c.Dob.Year}-{c.Dob.Month}-{c.Dob.Day}');";
           db.Update(query);
        }

        public void DeleteCharacter(int id)
        {
            db.Update($"delete from characters where id = {id}");
        }



        public void UpdateCharacter(int id, Character c)
        {
            string query = $"update characters set name = '{c.Name}',power = {c.Power},dob = '{c.Dob.Year}-{c.Dob.Month}-{c.Dob.Day}'";

            db.Update(query);
        }
    }
}
