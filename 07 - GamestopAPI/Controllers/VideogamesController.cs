using _07___GamestopAPI.Models;
using _07___GamestopAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _07___GamestopAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VideogamesController : ControllerBase
    {
        private readonly IVideogameService _videogameService;
        private readonly ILogger<VideogamesController> _logger;

        /*why costruttore
         * cosi come abbiamo dovuto passare la sua dipendenza rispetto al DbContext
         * anche al controller applichiamo lo stesso principio.
         * Non deve essere il controller a crearsi in modo ajtonomo la dipendenza,
         * ma farselo passare dal costruttore
         */
        public VideogamesController(IVideogameService videogameService,
            ILogger<VideogamesController> logger)
        {
            //dependency injection: la possibilita di fornire in qualche modo
            //le dipendenze dell'oggetto(tramite costruttore)
            _videogameService = videogameService;
            _logger = logger;            
        }

        [HttpGet]
        public List<Videogame> GetAll([FromQuery] string title) //videogames?title=pippo
        {
            if (string.IsNullOrEmpty(title))
            {
                //verifico cosa sta succedno nell'app
                _logger.LogInformation("chiamata http GET su videogames");
                return _videogameService.GetAll();
            }
            
            _logger.LogInformation("chiamata http GET con query {Title}", title);
            return _videogameService.GetAllByTitle(title);
        }

    }
}
