using _07___GamestopAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        /*why costruttore
         * cosi come abbiamo dovuto passare la sua dipendenza rispetto al DbContext
         * anche al controller applichiamo lo stesso principio.
         * Non deve essere il controller a crearsi in modo ajtonomo la dipendenza,
         * ma farselo passare dal costruttore
         */
        public VideogamesController(IVideogameService videogameService)
        {
            _videogameService = videogameService;
        }




    }
}
