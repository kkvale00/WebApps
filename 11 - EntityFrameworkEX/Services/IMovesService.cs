using _11___EntityFrameworkEX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _11___EntityFrameworkEX.Services
{
    public interface IMovesService
    {
        Moves[] GetAll();
        Moves GetByID(int id);

        Moves AddNew(Moves newMoves);
        Moves DeleteById(int id);

        Moves Update(int id, Moves moves);
    }
}
