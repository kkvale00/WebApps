using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _01___AziendaWeb.Controllers
{
    public class HomeController : Controller
    {
        //un URL in ASP.NET e' composto in questa maniera:

        //INDIRIZZOIP:PORTA/{controller}/{action}/{eventuali altri parametri}
        //INDIRIZZO E PORTA SONO OBBLIGATORI, WE ALWAYS NEED THEM
        
        //se gli eventuali altri parametri sono assenti fa niente
        //se la action e assente viene considerata = Index
        //se il contrroller e assente viene considerato = Home
        //action e controller di default si possono modificare


        // localhost:44306/Home
       public IActionResult Index()
        {
            //Quando questa action verrà richiamata automaticamente View() andrà
            //a pescare la vista che si trova in:
            //Views/{controller}/{action}
            //Views/Home/Index.cshtml

            return View();
        }

        // localhost:44306/Home/About
        public string About()
        {
            return "Pagina con le nostre informazioni";
        }
    }
}
