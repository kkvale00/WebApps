using _07___GamestopAPI.Data;
using _07___GamestopAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _07___GamestopAPI.Services
{
    public class VideogameService : IVideogameService
    {
        /*readonly
         * vuol dire soltanto che qesto campo, non potra
         * cambiare valore(niente new)
         */
        private readonly DbContext _ctx;

        /*costruttore
         * non voglio iunstanziare manualmente il campo di tipo DBCONTEXT
         * perche le dipendenze degli elemnti devono essere fornite da altri
         * si utilizza il costruttore per far passare le dipendenze necessarie
         */

        public VideogameService(DbContext ctx)
        {
            _ctx = ctx;
        }

        public List<Videogame> GetAll()
        {
            return _ctx.FindAll();
        }

        public List<Videogame> GetAllByTitle(string title)
        {
            return _ctx.FindAll()
                        .Where
                        (
                            v => v.Title.ToLower().Contains(title.ToLower())
                        )
                        .ToList();
        }
    }
}
