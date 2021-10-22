using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _13___Work.Services
{
    public interface InterfaceService<T>
    {
        public List<T> List();
        public T GetByid(int id);
        public T Delete(int id);
        public T Update(int id, T ediT);
        public T AddNew(T newT);
    }
}
