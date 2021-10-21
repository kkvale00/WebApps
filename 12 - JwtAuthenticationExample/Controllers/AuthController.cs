using _12___JwtAuthenticationExample.DTOs;
using _12___JwtAuthenticationExample.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _12___JwtAuthenticationExample.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;
        public AuthController(IAuthService service) 
        {
            _service = service;

        }

        [HttpPost("signup")]
        public ActionResult Register([FromBody] UserRegistrationRequest userReg)
        {
            //TODO
            // lasciamo un attimo in sospeso, andiamo a definire una classe
            // che descriva i dati che mandera l'utente in fase di registrazione
            // dobbiamo creare una classe il cui unicpo scopo e quello di fare 
            // da contenitore di dati in fase di scambio tra server e client
            // e/o viceversa, le classi di questo tipo non vengono considerati dei modeli
            // ma sono dei DTO(DataTrasferObject)

            //Model validation dotnet (validazione automatizzata degli oggeti che arrivano)
            if (_service.Register(userReg.Username,userReg.Password))
            {
                return Ok("Registration completed");
            }
            return BadRequest("User already exists");
        }

        [HttpPost("login")]
        public ActionResult<string> Login([FromBody] UserRegistrationRequest user)
        {
            // visto che nel service viene effettuato throw di un'eccezione
            // qualora il login non risulta essere stato effettuato con successo
            // usiamo direttamente un try/catch
            try
            {
                // se va tutto a buon fine verra resittuito il token(TODO)
                return Ok(_service.Login(user.Username, user.Password));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }

        





    }
}
