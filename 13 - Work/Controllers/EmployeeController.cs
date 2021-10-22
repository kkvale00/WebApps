using _13___Work.Models;
using _13___Work.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _13___Work.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly InterfaceService<Employee> _service;

        public EmployeeController(InterfaceService<Employee> service)
        {
            _service = service;
        }

        [HttpGet]
        public List<Employee> Get()
        {
            return _service.List();
        }

        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            return _service.GetByid(id);
        }

        [HttpPost]
        public Employee Add([FromBody] Employee employee)
        {
            return _service.AddNew(employee);
        }

        [HttpPut("{id}")]
        public Employee Update([FromRoute]int id, [FromBody] Employee employee)
        {
            return _service.Update(id, employee);
        }

        [HttpDelete("{id}")]
        public Employee Delete(int id)
        {
            return _service.Delete(id);
        }
    }
}
