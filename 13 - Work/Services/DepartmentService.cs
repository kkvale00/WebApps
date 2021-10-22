using _13___Work.Data;
using _13___Work.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _13___Work.Services
{
    public class DepartmentService : InterfaceService<Department>
    {
        private readonly DataContext _dtc;
        public DepartmentService(DataContext dtc)
        {
            _dtc = dtc;
        }

        public List<Department> List()
        {
            return _dtc.Departments.Include(p => p.Employees).Include(p => p.Managers).ToList();
        }

        public Department GetByid(int id)
        {
            return _dtc.Departments.Include(p => p.Employees).Include(p => p.Managers).FirstOrDefault(p => p.Id == id);
        }
        public Department AddNew(Department newT)
        {
            var add = _dtc.Departments.Add(newT).Entity;

            _dtc.SaveChanges();

            return add;
        }
        public Department Delete(int id)
        {
            var del = _dtc.Departments.FirstOrDefault(d => d.Id == id);

            _dtc.Remove(del);

            _dtc.SaveChanges();

            return del;
        }

        public Department Update(int id, Department ediT)
        {
            var toupdate = _dtc.Departments.Update(ediT);

            _dtc.SaveChanges();

            return toupdate.Entity;
        }
    }
}
