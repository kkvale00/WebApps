using _02___BibliotecaWEB.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _02___BibliotecaWEB.Controllers
{
    public class AutoreController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Elenco()
        {
            return View(DAOAutore.GetInstance().Elenco());
        }

        public IActionResult Cerca(int id)
        {
            Autore ris = DAOAutore.GetInstance().Cerca(id);

            if (ris != null)
                return View(ris);
            else
                return null;
        }

        public IActionResult FormNuovoAutore()
        {
            return View();
        }

        public IActionResult NuovoAutore(Dictionary<string, string> parametri)
        {
            Autore a = new Autore();
            a.FromDictionary(parametri);


            DAOAutore.GetInstance().Insert(a);

            return Redirect("/Autore/Elenco");
        }

        public IActionResult Delete(int id)
        {
            if (DAOAutore.GetInstance().Delete(id))
                return Redirect("/Autore/Elenco");
            else
                return Redirect("/Errori/ProblemaCancellazione");
        }

        public IActionResult FormModificaAutore(int id)
        {
            Autore daModificare = DAOAutore.GetInstance().Cerca(id);

            return View(daModificare);
        }

        public IActionResult ModificaAutore(Dictionary<string, string> parametri)
        {
            Autore daModificare = new Autore();
            daModificare.FromDictionary(parametri);

            if (DAOAutore.GetInstance().Update(daModificare))
                return Redirect("/Autore/Elenco");
            else
                return Content("mi fai impazzire diocan manco una cristo di query..");
        }
    }
}
