using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DronesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public JsonResult Get()
        {

            return new JsonResult("La siguiente api la puede ejecutar utilizando la herramienta Postman. En ella se definen tres funcionalidades basica." +
                "Agregar un nuevo Dron que viene dada por la url api/Drones/agregar donde insertando un json se obtiene un nuevo Dron. " +
                "Agregar un nuevo Medicamento que viene dada por la url api/Medicamentos/agregar y tambien agregar un Dron cargado con un determinado medicamento usando el metodo pos" +
                "con la url api/DronCargado/agregar Luego de tener insertados estos campos se pueden ver varios metodos del tipo get como son api/Drones que muestra todos los drones disponible" +
                "api/Drones/id nos muestra el nivel de bateria del dron con el id enviado" +
                "Tenemos tambien api/DronCargado nos muestra los drones disponibles para ser cargados,o sea que estan activos y aun tienen capacidad" +
                " Por ultimo la url api/DronCargado/id Nos muestra el peso de todas las cargas del dron especificado");
        }
    }
}
