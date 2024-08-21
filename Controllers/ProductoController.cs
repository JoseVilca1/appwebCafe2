using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using appwebCafe2.Data;
using appwebCafe2.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace appwebCafe2.Controllers
{
    public class ProductoController: Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ProductoService _productoService;
        public ProductoController(ApplicationDbContext context, ProductoService productoService)
        {
            _context = context;
            _productoService = productoService;
        }
        public async Task<IActionResult> Index()
        {
            var productos = await _productoService.GetAllProductos();
            return productos != null ? 
                View(productos):
                Problem("DataProductos esta vacio");
        }

    }     
            
}