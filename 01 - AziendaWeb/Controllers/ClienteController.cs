using _01___AziendaWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _01___AziendaWeb.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ElencoCliente()
        {
            return View(DAOCliente.GetInstance().ElencoClienti());
        }

        public IActionResult CercaCliente(int id)
        {
            Cliente ris = DAOCliente.GetInstance().CercaCliente(id);

            if (ris != null)
                return View(ris);
            else
                return View("ClienteNonTrovato.html");
        }

        public IActionResult FormNuovoCliente()
        {
            return View();
        }

        public IActionResult NuovoCliente(Dictionary<string, string> parametri)
        {
            Cliente c = new Cliente();
            c.FromDictionary(parametri);

            
            DAOCliente.GetInstance().Salva(c);

            return Redirect("/Cliente/Elenco");
        }



        public IActionResult Elimina(int id)
        {
            if (DAOCliente.GetInstance().Elimina(id))
                return Redirect("/Cliente/Elenco");
            else
                return Redirect("/Errori/ProblemaCancellazione");
        }

    }
}
