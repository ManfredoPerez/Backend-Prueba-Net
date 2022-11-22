using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaNet.Models
{
    public class Productos
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string marca { get; set; }
        public int precio { get; set; }
        public string descripcion { get; set; }
        public DateTime fecha { get; set; }
        public string tipo { get; set; }
    }
}