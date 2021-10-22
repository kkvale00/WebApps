using _13___Work.Data;
using _13___Work.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _13___Work.Services
{
    public class EmployeeService : InterfaceService<Employee>
    {
        private readonly DataContext _dtc;

        public EmployeeService(DataContext dtc)
        {
            _dtc = dtc;
        }
        public List<Employee> List()
        {
            return _dtc.Employees.ToList();
        }
        public Employee GetByid(int id)
        {
            return _dtc.Employees.FirstOrDefault(p => p.Id == id);
        }
        public Employee AddNew(Employee newT)
        {
            var add = _dtc.Employees.Add(newT);

            _dtc.SaveChanges();

            return add.Entity;
        }
        public Employee Delete(int id)
        {
            var todelete = _dtc.Employees.FirstOrDefault(e => e.Id == id);

            _dtc.Remove(todelete);

            _dtc.SaveChanges();

            return todelete;
        }
        public Employee Update(int id, Employee ediT)
        {
            var toupdate = _dtc.Employees.Update(ediT);

            _dtc.SaveChanges();

            return toupdate.Entity;
        }
    }
}
