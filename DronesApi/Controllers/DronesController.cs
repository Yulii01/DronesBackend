using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DronesApi.Datos;
using DronesApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DronesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DronesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get ()
            {
            return Ok(DronesList.lis_dron);
            }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var p = DronesList.lis_dron.Find(lmbda => lmbda.numero_serie == id);
            return Ok(p.Capacidad_Bateria + "%");
        }

        [HttpPost("agregar")]
        public IActionResult Post([FromBody] Dron nuevo_dron)
        {
            requisitos(nuevo_dron);
           DronesList.Agregar_Drones(nuevo_dron);
            return CreatedAtAction(nameof(Post), nuevo_dron);
        }

      
        private IActionResult requisitos(Dron nuevo_dron)
        {
            if(!(DronesList.lis_dron.Find(p=> p.numero_serie== nuevo_dron.numero_serie)==null))
            {
              return BadRequest($"El nuemro de serie {nuevo_dron.numero_serie} coincide con otro ya inscrito");

            }
            if (nuevo_dron.numero_serie.Length>100 || nuevo_dron.peso_limite>500)
            {
                return BadRequest($"El nuemro de serie {nuevo_dron.numero_serie} o el peso maximo del dron {nuevo_dron.peso_limite} son superior a lo permitido");
            }
            if(nuevo_dron.Capacidad_Bateria<25)
            {
                nuevo_dron.estado = "Cargando";
            }

            return Ok("");
        }

       


}
}