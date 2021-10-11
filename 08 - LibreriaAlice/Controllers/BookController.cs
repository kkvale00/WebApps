using _08___LibreriaAlice.Models;
using _08___LibreriaAlice.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _08___LibreriaAlice.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        private readonly IBookService _ibs;

        public BookController(IBookService i)
        {
            _ibs = i;
        }

        //su Startup modifico la dependency injection

        [HttpGet]
        public List<Book> List()
        {
            return _ibs.List();
        }

        [HttpGet("{id}")]
        public Book Search([FromRoute]int id)
        {
            return _ibs.Search(id);
        }

        [HttpPost]
        public void Add([FromBody] Book b)
        {
           _ibs.Add(b);
        }
        
        [HttpDelete("{id}")]
        public void Delete([FromRoute] int id)
        {
            _ibs.Delete(id);
        }

        [HttpPut("{id}")]
        public void Update([FromRoute]int id, [FromBody] Book b)
        {
            _ibs.Update(id, b);
        }

    }
}
