using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//la classe Person si trova nel namespace DummyAPI.Model
namespace _05___DummyAPI.Model
{
    //per utilizzare questa classe al di fuori di questo namespace 
    //devo fare using DummyAPI.Models
    public class Person
    {
        //nella maggior aprte dei casi in una classe Entity/Model
        //non c'e quyasi mai business logic (non ha metodi che effettuano calcoli, anche se potrebbe)
        //Business Logic = tutta la parte del codice il cui scopo e' andare a fornire le implementazioni per far funzionare il cuore dell'applicazione stessa / algoritmi che operano su quei dati 
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

    }
}
