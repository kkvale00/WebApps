using _13___Work.Models;
using _13___Work.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _13___Work.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly InterfaceService<Manager> _service;

        public ManagerController(InterfaceService<Manager> service)
        {
            _service = service;
        }

        [HttpGet]
        public List<Manager> Get()
        {
            return _service.List();
        }

        [HttpGet("{id}")]
        public Manager Get(int id)
        {
            return _service.GetByid(id);
        }

        [HttpPost]
        public Manager Add([FromBody] Manager Manager)
        {
            return _service.AddNew(Manager);
        }

        [HttpPut("{id}")]
        public Manager Update([FromRoute] int id, [FromBody] Manager Manager)
        {
            return _service.Update(id, Manager);
        }

        [HttpDelete("{id}")]
        public Manager Delete(int id)
        {
            return _service.Delete(id);
        }
    }
}
