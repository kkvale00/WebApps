using _08___LibreriaAlice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _08___LibreriaAlice.Services
{
    public interface IBookService
    {
        public List<Book> List();
        public Book Search(int id);
        public void Add(Book l);
        public void Update(Book l);
        public void Delete(int id);









    }
}
