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
    public class MedicamentosController : ControllerBase
    {
       
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(MedicamentosList.lis_medicamentos);
        }


        [HttpPost("agregar")]
        public IActionResult Post([FromBody] Medicamentos nuevo_medicamento)
        {
            requisito(nuevo_medicamento);
            MedicamentosList.Agregar_Medicamentos(nuevo_medicamento);
            return CreatedAtAction(nameof(Post), nuevo_medicamento);
        }


        private IActionResult requisito(Medicamentos nuevo_medicamento)
        {
            if (!(MedicamentosList.lis_medicamentos.Find(p => p.Codigo == nuevo_medicamento.Codigo) == null))
            {
                return BadRequest($"El Codigo del medicamento {nuevo_medicamento.Codigo} coincide con otro ya inscrito");

            }
            for (int i = 0; i < nuevo_medicamento.Nombre.Length; i++)
            {
                if(!char.IsLetterOrDigit (nuevo_medicamento.Nombre[i]))
                {
                    if (!(nuevo_medicamento.Nombre[i] == '-' || nuevo_medicamento.Nombre[i] == '_'))
                    { return BadRequest($"Nombre del medicamento {nuevo_medicamento.Nombre} no permitido"); }
                }
            }

            for (int i = 0; i < nuevo_medicamento.Codigo.Length; i++)
            {
                if (!(char.IsDigit(nuevo_medicamento.Codigo[i]) || char.IsUpper(nuevo_medicamento.Codigo[i]) || nuevo_medicamento.Codigo[i] == '-' || nuevo_medicamento.Codigo[i] == '_'))
                {
                    return BadRequest($"Codigo del medicamento {nuevo_medicamento.Codigo} no permitido"); 
                }
            }

            return Ok("");
        }

    }
}