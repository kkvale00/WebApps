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
            new Videogame{Id=1,Title="The Legend of Zelda"}
        };
        public List<Videogame> FindAll()
        {
            return _videogames;
        }



    }
}
