using DronesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DronesApi.Datos
{
    public class MedicamentosList
    {
        static public List<Medicamentos> lis_medicamentos = new List<Medicamentos>();

        static public void Agregar_Medicamentos(Medicamentos new_Dron)
        {
            lis_medicamentos.Add(new_Dron);
        }
    }
}
