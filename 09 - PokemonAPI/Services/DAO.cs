using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utility;

namespace _09___PokemonAPI.Services
{
    public abstract class DAO
    {
        protected readonly Database db;
        public DAO(IConfiguration config)
        {
            db = new Database(config["Db:Name"]);
        }

        //si puo usare come classe padre pedr richimarla
        //ad ogni DAO facendo un base nel costruttore

    }
}
