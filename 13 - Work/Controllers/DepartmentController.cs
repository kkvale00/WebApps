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
    public class DepartmentController : ControllerBase
    {
        private readonly InterfaceService<Department> _service;

        public DepartmentController(InterfaceService<Department> service)
        {
            _service = service;
        }

        [HttpGet]
        public List<Department> Get()
        {
            return _service.List();
        }

        [HttpGet("{id}")]
        public Department Get(int id)
        {
            return _service.GetByid(id);
        }

        [HttpPost]
        public Department Add([FromBody] Department Department)
        {
            return _service.AddNew(Department);
        }

        [HttpPut("{id}")]
        public Department Update([FromRoute] int id, [FromBody] Department Department)
        {
            return _service.Update(id, Department);
        }

        [HttpDelete("{id}")]
        public Department Delete(int id)
        {
            return _service.Delete(id);
        }
    }
}
