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
    public class ProveedoresController1 : ApiController
    {
        // GET api/<controller>
        public List<Proveedores> Get()
        {
            return ProveedorData.Listar();
        }

        // GET api/<controller>/5
        public Proveedores Get(int id)
        {
            return ProveedorData.Obtener(id);
        }

        // POST api/<controller>
        public bool Post([FromBody] Proveedores oProveedores)
        {
            return ProveedorData.Registrar(oProveedores);
        }

        // PUT api/<controller>/5
        public bool Put([FromBody] Proveedores oProveedores)
        {
            return ProveedorData.Modificar(oProveedores);
        }

        // DELETE api/<controller>/5
        public bool Delete(int id)
        {
            return ProveedorData.Eliminar(id);
        }
    }
}