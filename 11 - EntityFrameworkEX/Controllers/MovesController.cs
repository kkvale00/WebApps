using _11___EntityFrameworkEX.Models;
using _11___EntityFrameworkEX.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _11___EntityFrameworkEX.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MovesController : ControllerBase
    {
        private readonly IMovesService _service;

        // Dipendency Injection del nostro service
        public MovesController(IMovesService service)
        {
            _service = service;
        }
        [HttpGet]
        public Moves[] GetAll()
        {
            return _service.GetAll().ToArray();
        }

        [HttpGet("{id}")]
        public Moves GetById([FromRoute]int id)
        {
            return _service.GetByID(id);
        }

        [HttpPost]
        public Moves Post([FromBody] Moves moves)
        {
            return _service.AddNew(moves);
        }

        [HttpDelete("{id}")]
        public Moves Delete([FromRoute]int id)
        {
            return _service.DeleteById(id);
        }

        [HttpPut("{id}")]
        public Moves Update([FromRoute] int id, [FromBody] Moves moves)
        {
            return _service.Update(id, moves);
        }
    }
}
