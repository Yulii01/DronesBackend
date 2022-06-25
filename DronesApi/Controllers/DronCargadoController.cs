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
    public class DronCargadoController : ControllerBase
    {
        public static List<Drones_Cargados> drones_Cargados = new List<Drones_Cargados>();


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Drones_Disponbles());
        }

        //Metodo get que recibe un parametro 
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var dron = DronesCargados_list.lis_drones_cargados.Find(p => p.IdDrone == id);
            if(dron == null)
            {
                return BadRequest("El id del dron es incorrecto");
            }
            int carga = Calcular_Carga(id);
            return Ok(new Drones_Cargados { IdDrone = dron.IdDrone,Cantidad=carga });
        }

        //Metodo post url api/DronCargado/agregar

        [HttpPost("agregar")]
        public IActionResult Post([FromBody] Drones_Cargados nuevo_dron_cargado)
        {
            requisitos(nuevo_dron_cargado);
            DronesCargados_list.Agregar_Drones_Cargados(nuevo_dron_cargado);
            return CreatedAtAction(nameof(Post), nuevo_dron_cargado);
        }


        //Metodo que define los comportamientos establecidos para la inserccion de un nuevo elemento
        private IActionResult requisitos(Drones_Cargados nuevo_dron)
        {
            var drone = DronesList.lis_dron.Find(p => p.numero_serie == nuevo_dron.IdDrone);
            var medicamento = MedicamentosList.lis_medicamentos.Find(p => p.Nombre == nuevo_dron.MedicamentosId);

            if (drone == null || medicamento == null)
            {
                return BadRequest($"El medicamento {nuevo_dron.MedicamentosId} o el dron {nuevo_dron.IdDrone} no existen");
            }

            int carga = Calcular_Carga(nuevo_dron.IdDrone);
            if (carga+nuevo_dron.Cantidad>drone.peso_limite)
            {
                return BadRequest($"El Dron no soporta el peso de la carga");
            }

            //comprobar si al cargar el dron este tiene aun capacidad
            if(carga + nuevo_dron.Cantidad == drone.peso_limite)
            {
               var index = DronesList.lis_dron.FindIndex(p => p.numero_serie == nuevo_dron.IdDrone);
                DronesList.lis_dron[index].estado = "Entregando Carga";
            }

            return Ok("");


        }

        //mostrar los drones disponibles para cargas
        private List<Dron> Drones_Disponbles()
        {
            var drones = from drone in DronesList.lis_dron
                         where drone.estado == "cargado" || drone.estado == "Cargado"
                         select (new Dron { numero_serie = drone.numero_serie, estado = drone.estado, Capacidad_Bateria = drone.Capacidad_Bateria, peso = drone.peso, peso_limite = drone.peso_limite });

            return drones.ToList();
        }

        //Un dron puede ser cargado varias veces sin llenar su almacenaje por lo que es necesario saber cuanto ya a almacenado
        private int Calcular_Carga(string id)
         { 
            var x = from drones in DronesList.lis_dron
                   join drones_cargados in DronesCargados_list.lis_drones_cargados
                   on drones.numero_serie equals drones_cargados.IdDrone
                    where drones.numero_serie == id
                   select new Tuple<string, int, int>(drones.numero_serie, drones.peso_limite, drones_cargados.Cantidad);



            int count = 0;
            int peso_Max = 1000;
            foreach (var item in x)
            {
                count += item.Item3;
                peso_Max = item.Item2;
            }
            return count;
        }
    } }