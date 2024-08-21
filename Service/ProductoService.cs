//nos permite poder recuperar los datos, es como crear un método ó una clase aparte de toda la logica del controller 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using appwebCafe2.Data;
using appwebCafe2.Models;
using Microsoft.EntityFrameworkCore;

namespace appwebCafe2.Service
{
    public class ProductoService
    {
        private readonly ILogger<ProductoService> _logger;
        private readonly ApplicationDbContext _context;
        //crear el contrusctor
        public ProductoService(ILogger<ProductoService> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        //crear un método
        public async Task<List<Producto>?> GetAllProductos()
        {
            if(_context.DataProducto==null)
            {
                return null;
            }
            /*va a tener todos los productos que existe en la tabla*/
            return await _context.DataProducto.ToListAsync();
        }

        
    }
}