using _04___KongtunesWEB.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _04___KongtunesWEB.Controllers
{
    public class AutoreController : Controller
    {
        public IActionResult ElencoJSON()
        {
            return Json(DAOAutore.GetInstance().Elenco());
        }

        public IActionResult NuovoAutore(Dictionary<string, string> parametri)
        {
            Autore a = new Autore();
            a.FromDictionary(parametri);


            if (DAOAutore.GetInstance().Salva(a))
                return Content("tutto ok");
            else
                return Content("errore: controlla la query...");
        }
    }
}
