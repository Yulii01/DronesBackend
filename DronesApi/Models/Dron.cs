using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DronesApi.Models
{
    public class Dron
    {
        public string numero_serie { get; set; }
        public string peso { get; set; }
        public int peso_limite { get; set; }

        public int Capacidad_Bateria { get; set; }
        public string estado { get; set; }
    }
}
