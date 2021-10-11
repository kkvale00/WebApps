using _08___LibreriaAlice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _08___LibreriaAlice.Services
{
    public class DAOBook : IBookService
    {
        public List<Book> books = new List<Book>
        {
            new Book(){Id=1,Title="It",Author="King",Genre="Horror",Price=10.40},
            new Book(){Id=2,Title="Lo Hobbit",Author="Tolkien",Genre="Fantasy",Price=9.50},
            new Book(){Id=3,Title="Io sono Dio",Author="Faletti",Genre="Romanzo",Price=11.10},
            new Book(){Id=4,Title="1984",Author="Orwell",Genre="Romanzo",Price=6.80},
            new Book(){Id=5,Title="Anna Karenina",Author="Tolstoj",Genre="Romanzo",Price=5.20}
        };

        public void Add(Book l)
        {
            books.Add(l);
        }

        public void Delete(int id)
        {
            var index = books.FindIndex(l => l.Id == id);
            books.RemoveAt(index);
            //if(id > 0)
             //books.RemoveAll(b => b.Id == id);
        }

        public List<Book> List()
        {
            return books;
        }

        public Book Search(int id)
        {
            return books.Where(l => l.Id == id).FirstOrDefault();
        }

        public void Update(int id, Book l)
        {
            var index = books.FindIndex(b => b.Id == id);

            books[index] = l;
        }
    }
}
