using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _12___JwtAuthenticationExample.Services
{
    public interface IAuthService
    {
        /* REGISTER
         * si puo non solo chiedere semplicemente due dati
           bensi creare un modello dove definire le informazioni 
           di registrazioni dell'utente */
        bool Register(string username, string password);
        string Login(string username, string password);
        /*^^^^^^
         * per il ritorno per il momentoi mettiamo string Login.
         */



    }
}
