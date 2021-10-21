using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _12___JwtAuthenticationExample.Models
{
    public class User
    {
        /*USER MODEL
         * modello rappresenta i dati dell'utente che verranno utilizzati nell'api
         */
        public int Id { get; set; }
        public string Username { get; set; }
        /*HASH = 
                valore che non puo essere ricavato(in teoria)
                nel db salviamo solo il valore della password Hashed
                dato A => B non posso risalire ad A
                solo ripassando ad A lo stesso algoritmo di Hash, ottengo siempre B */
        public byte[] PasswordHash { get; set; }
        /*SALT = 
                il salt serve ad aggiungere un valore c
                che non c'entra con la pw, in modo che due utente non abbiano
                lo stesso HASH value, in caso di password uguali
                ES: pw: 1923 + 'salt' = 1923+'fozza_napoli'
         */
        public byte[] PasswordSalt { get; set; }
        /*LOGIN
         * quando c'e' un login :noi prendiamo la password(hash),
         * recuperiamo l'hash, li uniamo. Applichiamo l'hash e vediamo
         * se corrisponde esattamente al valore Hash salvato nel DB
         */






    }
}
