using _05___DummyAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _05___DummyAPI.Services
{
    //definire un contratto per tutte le classi che impletano:
    //fornire le operazioni CRUD sugli oggetti di tipo Person
    interface IPersonService
    {
        List<Person> GetAll();
        Person GetByID(int id);
        void AddPerson(Person person);
        void UpdatePerson(int id, Person person);
        void DeletePerson(int id);
    }
}
