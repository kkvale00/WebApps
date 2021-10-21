using _11___EntityFrameworkEX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _11___EntityFrameworkEX.Services
{
    public interface ISuperHeroService
    {

        List<SuperHero> GetAll();
        SuperHero GetByID(int id);
           // quando verra aggiunto un superoe voglio restiuire
           // l'oggetto che e stato appena salvato nel DB
           // IN UN SISTEMA REST se fanno un POST
           // dovrei restiuirgli l'oggetto che e stato appena creato
           // (lui lo manda senza ID e noi glielo inseriamo )
        SuperHero AddNew(SuperHero newsuperhero);


            // Restitusico l'oggetto che e stato appena eliminato
        SuperHero DeleteById(int id);

        SuperHero Update(int id, SuperHero superHero);

    }
}
