//using nome.namespace ci permette di utilizzare tutti gli elemtni di quel ns
using _05___DummyAPI.Models;
using _05___DummyAPI.Models.Services;
using _05___DummyAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _05___DummyAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase 
    {
        /*ControllerBase, 
        a differenza del normale non gestisce le View ma soltanto le risorse pure. 
        Andra a SERIALIZZARE gli oggetti restituti dai vari metodi MAPPATI
        in un formato "standard" cioe il JSON */

        private IProductService _productService = ScaffoldingProductService.GetInstance();

        /*HTTPGET
          serve a dire al framework che questo metodo dovra rispondere alle
         chiamate HTTP di tipo (verbo/metodo) GET */
        [HttpGet]
        public IEnumerable<Product> GetAll()
        {
            return _productService.GetAll();
        }

        /*HTTPOST
         fa in modo di far gestire a questo metodo tutte le chiamte POST
        */
        /*FROMBODY
         fa in modo che il body della chiamata venga passsata come parametro
         effettua anche la DESERIALIZZAZIONE del JSON trasformandolo
         in un oggetto C# 
         */
        [HttpPost]
        public IActionResult AddProduct([FromBody] Product newProduct)
        {
            
            _productService.AddProduct(newProduct);
            return Ok();
            //ok deriva da BAseController, permette di restituire in modo immediato
            //uno stato positivo della chiamata come risposta
        }
    }
}
