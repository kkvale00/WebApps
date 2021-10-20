using _10._1___PokemonAPIv3.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _10._1___PokemonAPIv3.Data
{
    public class MovesDao : Dao
    {
        public MovesDao(IConfiguration config) : base(config) { }


        public List<Move> GetAll()
        {
            var results = db.Read("SELECT * FROM moves;");

            return results.Select(result => FromDictionary(result))
                          .ToList();
        }

        public Move GetById(int id)
        {
            return FromDictionary(db.ReadOne($"SELECT * FROM moves WHERE id = {id};"));
        }

        private Move FromDictionary(Dictionary<string, string> result)
        {
            if (result is null)
            {
                return null;
            }

            return new Move
            {
                Id = int.Parse(result["id"]),
                Name = result["name"],
                Power = int.Parse(result["power"]),
                SpecialEffects = result["special_effects"],
                Type = result["type"]
            };
        }
    }
}
