using _05___DummyAPI.Models;
using _05___DummyAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace _05___DummyAPI.Models.Services
{
        /* scaffolding: 
           gestione dei dati direttamente a livello di codice
           in modo da avere un risultato immediato per mettere alla prova la nostra
           implementazione*/
    public class ScaffoldingProductService : IProductService
    {
        private static ScaffoldingProductService _instance;

        public static ScaffoldingProductService GetInstance()
        {
            if (_instance == null)
                _instance = new ScaffoldingProductService();

            return _instance;
        }



        //I campi private per convenzione dovrebbero inziare con _             
        private List<Product> _products = new List<Product>
        {
            new Product{
                Id=1,Name="Mouse da gaming",Category="Gaming",Price=19.99
            },
            new Product{
                Id=2,Name="Notebook",Category="Informatica",Price=1200.99
            },
            new Product{
                Id=3,Name="Caricabatteria type-c",Category="Accessori",Price=9.99
            },
        };

        public IEnumerable<Product> GetAll()
        {
            return _products;
        }
        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        /* ADDPRODUCT
          il prodotto che arriva al metodo molto probabilmente sara sprovvisto di ID 
          dobbiamo assegnarne uno noi */
        private int _lastId = 4;
        public void AddProduct(Product product)
        {
            product.Id = _lastId++;

            _products.Add(product);
        }
        public void UpdateProduct(int id, Product product)
        {
            throw new NotImplementedException();
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
