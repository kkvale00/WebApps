using _08___LibreriaAlice.Models;
using _08___LibreriaAlice.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<BookController> _log;

        public BookController(IBookService i,ILogger<BookController> logger)
        {
            _ibs = i;
            _log = logger;

        }

        //su Startup modifico la dependency injection

        [HttpGet]
        public List<Book> List()
        {
            _log.LogInformation("stamp the list of books");
            return _ibs.List();
        }

        [HttpGet("{id}")]
        public Book Search([FromRoute]int id)
        {
            _log.LogInformation($"searching book where id = {id}");
            return _ibs.Search(id);
        }

        [HttpPost]
        public void Add([FromBody] Book b)
        {
            _log.LogInformation("adding new book");
           _ibs.Add(b);
        }
        
        [HttpDelete("{id}")]
        public void Delete([FromRoute] int id)
        {
            _log.LogInformation($"deleting book where id = {id}");
            _ibs.Delete(id);
        }

        [HttpPut("{id}")]
        public void Update([FromRoute]int id, [FromBody] Book b)
        {
            _log.LogInformation($"updating book n {id}");
            _ibs.Update(id, b);
        }
    }
}
