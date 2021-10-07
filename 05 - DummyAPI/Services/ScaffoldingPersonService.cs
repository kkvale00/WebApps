using _05___DummyAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _05___DummyAPI.Services
{
    //uns ervizio e un elemento che mi fornisce business logic
    //per una parte dell'applicazione
    public class ScaffoldingPersonService : IPersonService
    {
        //implementazione del Singleton
        private static ScaffoldingPersonService _istance;
        public static ScaffoldingPersonService GetIstance()
        {
            /*??
             if(_istance == null)
               _istance = new Scaf...()
            return istance
            con il ?? si implica che non deve esistere(==null)
             */

            return _istance ??= new ScaffoldingPersonService();
        }

        private List<Person> _people = new List<Person>
        {
            new Person{
                Id=1,Name="Mario",Age=25
            },
            new Person{
                Id=2,Name="Paola",Age=22
            },
            new Person{
                Id=3,Name="Francesca",Age=35
            }
        };

        private int _lastId = 4;
        public void AddPerson(Person person)
        {
            person.Id = _lastId++;
            _people.Add(person);
            //Console.WriteLine($"Added a new person with name {person.Name}");
        }

        public void DeletePerson(int id)
        {
            //quando e -1 = non esiste l'oggeto ricercato
            var indexp = _people.FindIndex(p => p.Id == id);

            if (indexp >= 0)
                _people.RemoveAt(indexp);

            // _people.RemoveAll(p => p.Id == id);y
        }

        public List<Person> GetAll()
        {
            return _people;
        }

        public Person GetByID(int id)
        {
            /*foreach(var p in _people)
            {
                if(p.Id == id)
                    return p
            }
            return null;*/
            return _people.Where(p => p.Id == id).FirstOrDefault();
        }

        public void UpdatePerson(int id, Person person)
        {
           var indexof = _people.FindIndex(p => p.Id == id);
            if(indexof >= 0)
            {
                person.Id = id;
                _people[indexof] = person;
            }

        }
    }
}
