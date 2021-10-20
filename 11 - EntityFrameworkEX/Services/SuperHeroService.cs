using _11___EntityFrameworkEX.Data;
using _11___EntityFrameworkEX.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _11___EntityFrameworkEX.Services
{
    public class SuperHeroService : ISuperHeroService
    {
        private readonly DataContext _ctx;

        //tramite DipendencyInjection ci facciamo passare un oggetto di tipo DataContext
        public SuperHeroService(DataContext ctx)
        {
            _ctx = ctx;
        }
        public SuperHero AddNew(SuperHero newsuperhero)
        {
            // per persistere un nuovod ato andiamoa  rpendere il dbset
            // di riferimento, usando il metodo Addd
            // ci restiuscisce poi il nuovo oggetto che e stato salvato con l'ID
            var addedObj =_ctx.SuperHeroes.Add(newsuperhero);
            // di default EF non andra a salvare le modifche sul DB, fin quando
            // non viene salvato il metodo SaveChanges, effettuando un rollback automatico
            // in fase di test
            _ctx.SaveChanges();
            return addedObj.Entity;
        }

        public SuperHero DeleteById(int id)
        {
            //thanks to linq vado a trovare l'entity da rimuovere
            var toberemoved = _ctx.SuperHeroes.FirstOrDefault(hero => hero.Id == id);
            if (toberemoved is null)
            {
                return toberemoved;
            }
            
            //per mezzo del metodo remove, a cui passo l'oggetto dal DB
            _ctx.SuperHeroes.Remove(toberemoved);
            // salvare 
            _ctx.SaveChanges();
            // restituisco in quanto richiesto dalla firma del metodo
            return toberemoved;
        }

        public List<SuperHero> GetAll()
        {
            //questa proprieta, recuperata dall datacontext, ci permette
            //di effettuare le varie operazioni sugli oggetti SUPERHEROES

            return _ctx.SuperHeroes.Include(p => p.Moveset).ToList();
            // dal DBSet uso il metodo ToList()
            // che effettua una select dal DB
            // e restituisce la lista degli oggetti
            // effettuando tutte le operazioni di ORM
            // EF usa le API di Linq per fornire le implementazioni
        }

        public SuperHero GetByID(int id)
        {
            return _ctx.SuperHeroes.FirstOrDefault(hero => hero.Id == id);
        }
    }
}
