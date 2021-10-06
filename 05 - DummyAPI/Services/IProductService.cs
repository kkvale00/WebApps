using _05___DummyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace _05___DummyAPI.Services
{
    interface IProductService
    {
        //il service deve fornire in qualche modo una lista di Product
        IEnumerable<Product> GetAll();
        Product GetById(int id);
        void AddProduct(Product product);
        void UpdateProduct(int id, Product product);
        void Delete(int id);

        //utilita dell'interfaccia permette di astrarre e mantenere un livello di "protezione"

    }
}
