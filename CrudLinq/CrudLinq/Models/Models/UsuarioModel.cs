using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudLinq.Models.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
    }
}