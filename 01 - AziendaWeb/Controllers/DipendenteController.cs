using _01___AziendaWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _01___AziendaWeb.Controllers
{
    public class DipendenteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

            //localhost:44306/Dipendente/Elenco
        public IActionResult Elenco()
        {
            return View(DAODipendente.GetInstance().ElencoDipendenti());
        }



        //public string Elenco()
        //{
        //    DAODipendente dd = new DAODipendente();

        //    string ris = "";

        //    foreach (Dipendente dip in dd.ElencoDipendenti())
        //        ris += dip.ToString();

        //    return ris;
        //}

        //localhost:44306/Dipendente/Cerca/1
        public IActionResult Cerca(int id)
        {
            Dipendente ris = DAODipendente.GetInstance().CercaDipendente(id);

            if (ris != null)
                return View(ris);
            else
                return View("DipendenteNonTrovato.html");
        }

        //attraverso questa action l'utente arrivera alla pagina x inserire un nuovo dipendente
        public IActionResult FormNuovoDipendente()
        {
            return View();
        }

        public IActionResult NuovoDipendente(Dictionary<string,string> parametri)
        {
            //Creare un Dipendente utilizzando i parametri che mi sono arrivati
            Dipendente d = new Dipendente();
            d.FromDictionary(parametri);

            //Chiamo il DAODipendente per salvare il mio Dipendente appena creato
            DAODipendente.GetInstance().Salva(d);

            //Una volta che termino il salvataggio reindirizzo il mio utente
            //all'URL per vedere l'elenco dei dipendenti
            return Redirect("/Dipendente/Elenco");
        }

        //^^^^^^^^^^^^^^^^\\
        /*===TEST PER VDERE CHE PARAMETRI MI ENTRANO===

            string ris = "mi sono arrivati sti dati \n\n";
            
            foreach (string k in parametri.Keys)
                ris += $"{k}: {parametri[k]} \n";
            
            return Content(ris);
        */

        public IActionResult Elimina(int id)
        {
            if (DAODipendente.GetInstance().Elimina(id))
                return Redirect("/Dipendente/Elenco");
            else
                return Redirect("/Errori/ProblemaCancellazione");
        }

        public IActionResult FormModificaDipendente(int id)
        {
            Dipendente daModificare = DAODipendente.GetInstance().CercaDipendente(id);

            return View(daModificare);
        }

        public IActionResult ModificaDipendente(Dictionary<string,string> parametri)
        {
            Dipendente daModificare = new Dipendente();
            daModificare.FromDictionary(parametri);

            if (DAODipendente.GetInstance().Modifica(daModificare))
                return Redirect("/Dipendente/Elenco");
            else
                return Content("mi fai impazzire diocan manco una cristo di query..");



        }
    }
}
