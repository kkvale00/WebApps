using _03___Cinema.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _03___Cinema.Controllers
{
    public class UtenteController : Controller
    {
        public IActionResult ElencoJSON()
        {
            return Json(DAOUtente.GetInstance().Elenco());
        }

        public IActionResult NuovoUtente(Dictionary<string, string> parametri)
        {
            Utente u = new Utente();
            u.FromDictionary(parametri);


            if (DAOUtente.GetInstance().Salva(u))
                return Content("sto tutto fatto");
            else
                return Content("manco uno sfaccimma di utente sai scrivere ");
        }
    }
}
