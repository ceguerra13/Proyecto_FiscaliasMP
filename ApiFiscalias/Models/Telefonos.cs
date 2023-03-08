using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiFiscalias.Models
{
    public class Telefonos
    {
        public int Id_Fiscalia { get; set; }
        public int Id_Telefonos { get; set; }
        public string Nombre_Fiscalia { get; set; }
        public string Ubicacion { get; set; }
        public decimal Numero { get; set; }
        public decimal Extension { get; set; }
    }
}