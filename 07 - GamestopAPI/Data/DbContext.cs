using _07___GamestopAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _07___GamestopAPI.Data
{
    public class DbContext
    {
        /*un DBCONTEXT
          e praticamente un oggetto che sara in grado di accedere al DB
          e fornirmi attraverso ORM i dati sottoforma di oggetti
          fare cmq in scaffolding per comodita
         */
        private List<Videogame> _videogames = new List<Videogame>
        {
            new Videogame{Id=1,Title="The Legend of Zelda"},
            new Videogame{Id=2,Title="Pokemon Platino"},
            new Videogame{Id=3,Title="Dragonball Budokai Tenkaichi 3"},
            new Videogame{Id=4,Title="GTA San Andreas"},
            new Videogame{Id=5,Title="Red Dead Redemption"},
        };
        public List<Videogame> FindAll()
        {
            return _videogames;
        }
        public List<Videogame> FindByTitle(string title)
        {
            var ris = new List<Videogame>();

            foreach (var t in _videogames)
                if (t.Title.Contains(title))
                {
                    ris.Add(t);
                }
                else
                    return null;

            return ris;
        }
    }
}
