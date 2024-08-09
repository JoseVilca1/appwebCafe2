using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace appwebCafe2.Models
{
    public class Producto
    {
        public int Id {get;set;}
        public string? Nombre {get;set;}
        public Decimal? Precio {get;set;}
        public string? ImagenUrl {get;set;}
        public string? Descripcion {get;set;}
    }
}