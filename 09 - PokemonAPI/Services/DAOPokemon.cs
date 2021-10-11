﻿using _09___PokemonAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utility;
namespace _09___PokemonAPI.Services
{
    public class DAOPokemon
    {
        public Database db;
        public static DAOPokemon _instance;

        public DAOPokemon() { db = new Database("pokemon"); }

        public static DAOPokemon GetInstance()
        {
            return _instance ??= new DAOPokemon();
        }

        public List<Pokemon> GetAll()
        {
            var ris = new List<Pokemon>();

            var query = 
            "select pokemons.id,pokemons.name,pokemons.weigth,pokemons.generationid as generation,types.type as pokemontype," +
            "moves.name as move,moves.type as movetype, moves.power,moves.specialeffects from pokemons inner join pokemontypes " +
            "on pokemons.id=pokemontypes.pokemonid inner join types on pokemontypes.typeid=types.id inner join pokemonmoveset on " +
            "pokemons.id=pokemonmoveset.pokemonid inner join moves on pokemonmoveset.moveid = moves.id;";
            

            List<Dictionary<string, string>> righe = db.Read(query);

            foreach (var riga in righe)
            {
                Pokemon p = new Pokemon();
                p.FromDictionary(riga);

                ris.Add(p);
            }
            return ris;
        }
        public Pokemon GetByID(int id)
        {
            var query = $"select * from pokemons where id = {id} ";

            Dictionary<string, string> riga = db.ReadOne(query);
              
            Pokemon c = new Pokemon();
            c.FromDictionary(riga);

            return c;
        }

        public void Add(Pokemon p)
        {
            var query =
                 $"insert into pokemons (name,weigth,generation,type) values" +
                 $"('{p.Name}',{p.Weigth},'{p.Generation}','{p.Types}');";
            db.Update(query);
        }

        public void Delete(int id)
        {
            db.Update($"delete from pokemons where id = {id}");
        }

        public void Update(int id,Pokemon p)
        {
            var query = $"update pokemons set name = '{p.Name}', {p.Weigth}, '{p.Generation}' where id = {id}; ";


            db.Update(query);


        }

    }
}
