using _10._1___PokemonAPIv3.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _10._1___PokemonAPIv3.Data
{
    public class GenerationsDao : Dao
    {
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




    }
}
