using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cruds.Models
{
    public class PersonalModels
    {
        public int id { get; set; }
        public Char Cedula { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public int Telefono { get; set; }
    }
}