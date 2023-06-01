using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP5.Models;

namespace TP5.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
           return View(Index);
    }

      public IActionResult Index()
    {
           return View(Tutorial);
    }
    public IActionResult Comenzar()
{

    EstadoJuego estadoJuego = ObtenerEstadoJuego();

    
    int siguienteHabitacion = estadoJuego.ObtenerSiguienteHabitacion();


    return View("Habitacion", new { sala = siguienteHabitacion });
}

 public IActionResult Habitacion(int sala, string clave)
    {

    EstadoJuego estadoJuego = ObtenerEstadoJuego();


    if (estadoJuego.SalaActual != sala)
    {
  
        return View("Habitacion", new { sala = estadoJuego.SalaActual });
    }
  
    if (estadoJuego.VerificarClave(sala, clave))
    {
     
        int siguienteHabitacion = estadoJuego.ObtenerSiguienteHabitacion();

       
        if (siguienteHabitacion == -1)
        {
            return View("Victoria");
        }

        return View("Habitacion", new { sala = siguienteHabitacion });
    }
    else
    {
        ViewBag.Error = "La respuesta escrita fue incorrecta";
        return View("Habitacion", new { sala = sala });



    }



    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
