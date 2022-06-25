using DronesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DronesApi.Datos
{

    //Al ser una app de muestra sencilla no se impleta una base de datos en sql serve sino que se simulan las tablas de la base de datos mediante listas estaticas
    public class DronesCargados_list
    {
        static public List<Drones_Cargados> lis_drones_cargados = new List<Drones_Cargados>();

        static public void Agregar_Drones_Cargados(Drones_Cargados new_Dron)
        {
            lis_drones_cargados.Add(new_Dron);
        }
    }
}
