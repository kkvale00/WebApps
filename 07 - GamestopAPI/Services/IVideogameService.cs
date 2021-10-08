using _07___GamestopAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _07___GamestopAPI.Services
{
    public interface IVideogameService
    {
        List<Videogame> GetAll();

        /// <summary>
        ///     Metodo che restiuisce la lista a partire dal titolo
        /// </summary>
        /// <param name="title">
        ///     Il titolo utilizzato per la ricerca
        /// </param>
        /// <returns>
        ///     la litsa filtrata attraverso la ricerca
        /// </returns>
        List<Videogame> GetAllByTitle(string title);






    }
}
