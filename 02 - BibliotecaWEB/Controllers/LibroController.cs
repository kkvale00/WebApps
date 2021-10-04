using _02___BibliotecaWEB.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _02___BibliotecaWEB.Controllers
{
    public class LibroController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Elenco()
        {
            return View(DAOLibro.GetInstance().Elenco());
        }

        public IActionResult Cerca(int id)
        {
            Libro ris = DAOLibro.GetInstance().Cerca(id);

            if (ris != null)
                return View(ris);
            else
                return null;
        }

        public IActionResult FormNuovoLibro()
        {
            return View();
        }

        public IActionResult NuovoLibro(Dictionary<string, string> parametri)
        {
            Libro l = new Libro();
            l.FromDictionary(parametri);


            DAOLibro.GetInstance().Insert(l);

            return Redirect("/Libro/Elenco");
        }

        public IActionResult Delete(int id)
        {
            if (DAOLibro.GetInstance().Delete(id))
                return Redirect("/Libro/Elenco");
            else
                return Redirect("/Errori/ProblemaCancellazione");
        }

        public IActionResult FormModificaLibro(int id)
        {
            Libro daModificare = DAOLibro.GetInstance().Cerca(id);

            return View(daModificare);
        }

        public IActionResult ModificaLibro(Dictionary<string, string> parametri)
        {
            Libro daModificare = new Libro();
            daModificare.FromDictionary(parametri);

            if (DAOLibro.GetInstance().Update(daModificare))
                return Redirect("/Libro/Elenco");
            else
                return Content("mi fai impazzire diocan manco una cristo di query..");
        }
    }
}
