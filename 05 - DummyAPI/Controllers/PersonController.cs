using _05___DummyAPI.Model;
using _05___DummyAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _05___DummyAPI.Controllers
{
    //i controller gestiscono INPUT/OUTPUT, questi controller
    //gestiscono chiamate attraverso il protocollo http(usando la rete ed uno specifico protocolo)

    [Route("[controller]")]
    //route serve per mappare le chiamate che arrivano su "/nomeController"
    [ApiController]//questa classe e un controller che gestisce risorse
    public class PersonController : ControllerBase
    {
        /*HTTPGET
         gestisce tutte le chiamate di tipo Get
        [HttpGet]
        public string HelloWorld()
        {
            //la risposta che mandiamo al client della chiamata http
            return "forza napoli";
        }
        */
        //assegno ad un nostro campo l 'istanze(singleton) del service(nostro "DAO" fittizio)
        private IPersonService _personService = ScaffoldingPersonService.GetIstance();
        //l'utilizzo di un interfaccia serve ad avere un livello di protezione
        //rispetto all'implementazione concreta
        //in futuro potro sostituire la classe che uso con un altra che implementa lo stesso contratto
        [HttpGet]
        public List<Person> Get()
        {
            // COMPUTAZIONE fatta dalla parte MODEL
            var res = _personService.GetAll();

            //output
            return res;
        }//noi gestiamo direttamente oggetti C#, ci pensa asp.net core a convertire
         //questi oggetti in stringhe JSON

        [HttpPost]
        public void AddNewPerson(
            //[FromBody] dice esplicitamente da dove arriva il valore
            [FromBody] Person person)//i client manderanno stringhe JSON che saranno convertiti in oggett C# dal framework
        {
            _personService.AddPerson(person);
        }

        //i percorsi definiti dalla graffe sono elementi dinamici(wildcard)
        //servono  afare in mood da accettare qualasiasi valore e quel valore potra
        //essere utilizzato per diversi scopi: corrispondera all'id della risora richeista
        [HttpGet("{id}")]
        public Person GetById([FromRoute] int id)
        {
            return _personService.GetByID(id);
        }

        [HttpDelete("{id}")]
        public void DeleteByID([FromRoute] int id)
        {
            _personService.DeletePerson(id);
        }

        //la differenza del put rispetto al resto e che e leggermente piu complesso
        // devo andare a recuperare due informazioni diverse in due parti diverse
        //della chiamata http
        [HttpPut("{id}")]
        public void UpdatePerson([FromRoute] int id, [FromBody] Person person)
        {
            _personService.UpdatePerson(id, person);
        }
    }
}
