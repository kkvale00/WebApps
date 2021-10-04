using _04___KongtunesWEB.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _04___KongtunesWEB.Controllers
{
    public class AlbumController : Controller
    {
        public IActionResult ElencoJSON()
        {
            return Json(DAOAlbum.GetInstance().Elenco());
        }

        public IActionResult NuovoAlbum(Dictionary<string, string> parametri)
        {
            Album a = new Album();
            a.FromDictionary(parametri);


            if (DAOAlbum.GetInstance().Salva(a))
                return Content("tutto ok");
            else
                return Content("errore: controlla la query...");
        }

    }
}
