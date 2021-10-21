using _12___JwtAuthenticationExample.Data;
using _12___JwtAuthenticationExample.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _12___JwtAuthenticationExample.Services
{
    public class AuthService : IAuthService
    {
        private readonly DataContext _ctx;
        public AuthService(DataContext ctx)
        {
            _ctx = ctx;
        }

        /* JTW=
         * al logino con soccesso il metodo restituira il
           JWT => una stringa che corrispodne al token
            che l'utente dovra rimandare ogni volta
            per risultare autorizzato nelle varie parti securizzate della nostra API
        */
        public string Login(string username, string password)
        {
            var user = _ctx.Users.FirstOrDefault(user => user.Username == username);

            if (user is null)
            {
                //se non essite alcun utente con quell'username 
                // non e avvenuto con successo
                    throw new Exception("404: User Not Found");
                //per praticita uso une ccezione generica ma si potrebbe
                // pensare di adottare un'eccezione custom piu descrittiva
            }
                //faccio un check sulla passwor inserita dall'utente
                //paragonando il valroe hashed con quello salvato in DB
                //per mezzo del salt sempre salvato su DB
            if (VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                // ci affidiamoa d un metodo il cui unico compito e di generare il token
                // a partire dell'utente che ha effetuato con successo
                // il login
                return CreateToken(user);
            }
            throw new Exception("Bad Credential");
        }

        private string CreateToken(User user)
        {
            // andiamo a definite le parti del payload, nello specifico
            // le parti per andre ad identificare l'identita dell'utente
            // questa lista contiene le info dell'utente
            var claims = new List<Claim>
            {
                // nel nostro sistema il modo in cui identifichiamo univocamente
                // l'utente e per mezzo del suo id
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username)
            };

            // Conviene esternalizzare la chiave segreta
            var secret = "super secret very very long long men pikachu";
            // questos ecret e importante per validare il token dell'utente
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDesciptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDesciptor);

            //TODO restituire il token generato
            return string.Empty;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            // questa volta a differenza di prima, gli passo io il salt
            // in modo da applicare l'hash utilizazndo quella che ho nel DB
            // corrispondente all'utente che si sta autenticando
            using(var hms = new HMACSHA512(passwordSalt))
            {
                // vado ad applicare l'hash alla password inserita dall'utente
                var hash = hms.ComputeHash(Encoding.UTF8.GetBytes(password));

                // devo vedere se il contenuto e identico all'hash
                // che e stato salvato nel db
                return hash.SequenceEqual(passwordHash);
                // sfruttiamo linq per effettuare un paragone dei vari valori
                // contenuti nei due array, invce di farlo manualmente
            }
        }

        public bool Register(string username, string password)
        {
            /*STEP 1:
              1) controllo se l'username e' gia usato
                 per mezzo di un metodo HELPER
            * Vantaggi: Metodo register piu conciso e possibilita
            *           di modificare in un secondo momento senza modificare
            *           il metodo register
            */
            if(UserExists(username))
            {
                // restiuisco false per dire che la registrazione non e avvenuta
                // con succeso
                return false;
            }
            /*STEP 2
             * 2) certi che l'username non sia stato gia usato
             * effettuiamo il salvataggio su DB, 
             * passandogli l'HASH E SALT della passwrod
             * perche e con lom stesso salt che viene applciato l'hash
             */
            var (hash,salt) = HashPassword(password);
            /*STEP 3
             * 3) procediamo ad effettuare la persistenza con il Dbset 
             * andando a creare manualmente l'oggetto di tipo User
             */
            _ctx.Users.Add(
                new User
                {
                    Username = username,
                    PasswordHash = hash,
                    PasswordSalt = salt

                }
               );
            _ctx.SaveChanges();
            return true;

        }
        private (byte[] passwordHash, byte[] passwordSalt) HashPassword(string password)
        {
            /*qui otteniamo l'HASH con HMACSHA512
             HMACSHA512 e un oggetto di una classe che implementa l'interfaccia
             IDisposable, gli oggetti delle classi che implmentano quest'ultima
             devono essere "messi via", ci sono diversi modi per farlo
             possiamo usare using in modo das sbarazzarci in automatico
             questo oggetto una volta terminato il blocco deifnito da using
             altrimenti dovrei farlo in modo manuale
             */
            using (var hms = new HMACSHA512())
            {
                // hms.Dispose(); non serve fare .Dispose()
                // in quanto verra cestinato automaticamente una volta terminato
                // il bloggo di using
                // sil salt ce lo fornisce hmacsha512 = chiave
                // l'algoritmo utilizza la key per applicare il salt in fase di hashing
                var salt = hms.Key;
               
                // per l'hash dobbiamo computarla, ma dobbiamo prima di tutto
                // ricavare il buffer (byte[]) dalla stringa
                // abbiamo la classe encoding che gestisce le varie codifiche di un testo
                // visto la nostra password viaggia su http, sara per froza utf-8
                var hash = hms.ComputeHash(Encoding.UTF8.GetBytes(password));
                // restituisce nell'ordien giusto i due valori attraverso TUPLE
                return (hash,salt); 
            }
        }

        private bool UserExists(string username)
        {
            // Se nella tabella (con LINQ) trovo qualche susername anonimo
            // restiuisco TRUE
            return _ctx.Users.Any(suser => suser.Username == username);



        }

        /*TUPLE=
         * un potenziale output da un metodo non singolo
         * grazie a tuple abbiamo la possibilita di restituire entrambi i valori
         */

    }
}
