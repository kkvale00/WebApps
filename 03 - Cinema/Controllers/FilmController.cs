using _03___Cinema.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _03___Cinema.Controllers
{
    public class FilmController : Controller
    {
        public IActionResult ElencoJSON()
        {
            return Json(DAOFilm.GetInstance().Elenco());
        }

        public IActionResult NuovoFilm(Dictionary<string, string> parametri)
        {
            Film f = new Film();
            f.FromDictionary(parametri);


            if (DAOFilm.GetInstance().Salva(f))
                return Content("sto tutto fatto");
            else
                return Content("manco uno sfaccimma di film sai scrivere ");
        }
    }
}
