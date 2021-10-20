using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utility;

namespace _10._1___PokemonAPIv3
{
    public abstract class Dao
    {
        protected readonly Database db;
        public Dao(IConfiguration config)
        {
            db = new Database(config["Db:Name"]);
        }
    }
}
