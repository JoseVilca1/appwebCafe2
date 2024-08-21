using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using appwebCafe2.Models;
using Clase_semana6_modelo;
using Microsoft.ML;
using Microsoft.Extensions.ML;

namespace appwebCafe2.Controllers;

public class HomeController : Controller
{
    //mas que todo es para estar logeado
    private readonly ILogger<HomeController> _logger;
    //ponerte aca el PrectionEngine para poder tener una salida en HomeController en Create
    private readonly PredictionEnginePool<MLModel1.ModelInput,MLModel1.ModelOutput> _predictionEnginePool;
    //ahi tambien poner lo mismo
    public HomeController(ILogger<HomeController> logger,PredictionEnginePool<MLModel1.ModelInput,MLModel1.ModelOutput> predictionEnginePool)
    {
        _logger = logger;
        _predictionEnginePool = predictionEnginePool;
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
    public IActionResult Contacto()
    {
        return View();
    }
        [HttpPost]
    public async Task<IActionResult> Create(Contacto objContacto) //llamamos del Views:Contacto.cshtml y el objetivo de MOdels:Contacto.cs
    {
        MLModel1.ModelInput modelInput = new MLModel1.ModelInput()//MLModel1.Model sale del visual 2022 manchine learning de los sentimientos de su url
        { //ModelInput: es lo que das al modelo(las entradas) analiza el sentimiento y de ahi
            SENTIMIENTO_TEXT = objContacto.Mensaje
        };//ModelOutput: es lo que recibes del modelo(Las salidas) lanza comentario como positivo o negativo
        MLModel1.ModelOutput prediction= _predictionEnginePool.Predict(modelInput);//el predictionEnginePool viene de program.cs para poder hacer el modelo
        TempData["MessageCONTACTO"] =""; //mensaje que vamos a mandar a la vista
        if(prediction.PredictedLabel==1)
        {
            TempData["MessageCONTACTO"] ="El mensaje fue Positivo";
        } else 
        {
            TempData["MessageCONTACTO"] ="El mensaje fue Negativo";
        }                                
        ViewData["Sentimiento"] = prediction.PredictedLabel; //PredictedLabel: es la parte del 1 y 0 parte izquierdo para predecir
        //Mensaje resumen0 -0,5286096 0,9088967                       
        return View("~/Views/Home/Contacto.cshtml"); //mismo from te contacto
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
