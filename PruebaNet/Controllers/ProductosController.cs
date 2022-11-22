using PruebaNet.Backend;
using PruebaNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PruebaNet.Controllers
{
    public class ProductosController : ApiController
    {
        // GET api/<controller>
        public List<Productos> Get()
        {
            return ProductoData.Listar();
        }

        // GET api/<controller>/5
        public Productos Get(int id)
        {
            return ProductoData.Obtener(id);
        }

        // POST api/<controller>
        public bool Post([FromBody] Productos oProductos)
        {
            return ProductoData.Registrar(oProductos);
        }

        // PUT api/<controller>/5
        public bool Put([FromBody] Productos oProductos)
        {
            return ProductoData.Modificar(oProductos);
        }

        // DELETE api/<controller>/5
        public bool Delete(int id)
        {
            return ProductoData.Eliminar(id);
        }
    }
}