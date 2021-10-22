using _13___Work.Data;
using _13___Work.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _13___Work.Services
{
    public class ManagerService : InterfaceService<Manager>
    {
        private readonly DataContext _dtc;
        public ManagerService(DataContext dtc)
        {
            _dtc = dtc;
        }
        public List<Manager> List()
        {
            return _dtc.Managers.ToList();
        }
        public Manager GetByid(int id)
        {
            return _dtc.Managers.FirstOrDefault(p => p.Id == id);
        }
        public Manager AddNew(Manager newT)
        {
            var add = _dtc.Managers.Add(newT);

            _dtc.SaveChanges();

            return add.Entity;
        }
        public Manager Delete(int id)
        {
            var todelete = _dtc.Managers.FirstOrDefault(e => e.Id == id);

            _dtc.Remove(todelete);

            _dtc.SaveChanges();

            return todelete;
        }
        public Manager Update(int id, Manager ediT)
        {
            var toupdate = _dtc.Managers.Update(ediT);

            _dtc.SaveChanges();

            return toupdate.Entity;
        }
    }
}
