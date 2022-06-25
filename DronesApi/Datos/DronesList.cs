using DronesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DronesApi.Datos
{
    public class DronesList
    {
       static public  List<Dron> lis_dron = new List<Dron>();

      static  public void Agregar_Drones(Dron new_Dron)
        {
            lis_dron.Add(new_Dron);
        }
    }
   
}
