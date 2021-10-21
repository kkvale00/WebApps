using _11___EntityFrameworkEX.Data;
using _11___EntityFrameworkEX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _11___EntityFrameworkEX.Services
{
    public class MovesService : IMovesService
    {
        private readonly DataContext _dtc;

        public MovesService(DataContext dtc)
        {
            _dtc = dtc;
        }
        public Moves AddNew(Moves newMove)
        {
            var add = _dtc.Add(newMove);

            _dtc.SaveChanges();

            return add.Entity;
        }

        public Moves DeleteById(int id)
        {
            var del = _dtc.Moveset.FirstOrDefault(p => p.Id == id);

            _dtc.Moveset.Remove(del);

            _dtc.SaveChanges();

            return del;
        }

        public Moves[] GetAll()
        {
            return _dtc.Moveset.ToArray();
        }

        public Moves GetByID(int id)
        {
            var who = _dtc.Moveset.FirstOrDefault(p => p.Id == id);

            return who;

        }
        public Moves Update(int id, Moves moves)
        {
            var update = _dtc.Moveset.Update(moves);
            _dtc.SaveChanges();

            return update.Entity;
        }
    }
}
