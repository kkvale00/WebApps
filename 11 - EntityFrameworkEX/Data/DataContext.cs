using _11___EntityFrameworkEX.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _11___EntityFrameworkEX.Data
{
    public class DataContext : DbContext
    {
        // questa classe avra in gestione tutti i dati dell'api
        // la facciamo figlia di DBcontext che ci fornira gli strumenti
        // per operare sui dati degli oggetti della classi 
        // che specificheremo all'interno della nostra classe

        // il costruttore della nostra classe deve passare un paramettro
        // al costruttore della classe padre
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            // il framework passera al costruttore le options
            // che noi ripassiamo al costruttore padre
        }

        // all'interno di questa classe definiamo delle proprieta che corrispondono
        // a degli oggetti che sono ing rado di effettuare orm 
        // su un determinato modello
        public DbSet<SuperHero> SuperHeroes { get; set; }
        // per ogni modello su cui abbiamo bisogno di far persistenza
        // bastera definire un'altra proprieta DbSet<ClasseModello> per ogni classe

    }
}
