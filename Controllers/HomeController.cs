using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using appwebCafe2.Models;

namespace appwebCafe2.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        ViewData["Message"] = "Enviando mensajes desde el controller"; // envia msj a la parte fronted
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    //ESTAMOS CREANDO UN FORMULARIO PARA CAFE

    public IActionResult Formulario() // ESE NOMBRE TIENE QUE SER IGUAL AL NOMBRE DE LA CARPETA HOME, QUE HAS CREADO
    {
        ViewData["msj"] = "Registrate el producto";
        return View();
    }

            [HttpPost]
    public IActionResult Crear(Producto producto)
    {
        if (ModelState.IsValid)
        {
            // Aquí podrías guardar el producto en la base de datos
            // Por ejemplo: _context.Productos.Add(producto); _context.SaveChanges();

            ViewData["msj"] = "Producto creado con éxito!"+producto.Nombre;
            return View("Formulario",producto);
        }
        
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
