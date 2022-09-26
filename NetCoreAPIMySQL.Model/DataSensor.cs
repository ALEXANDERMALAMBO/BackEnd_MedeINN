using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIMySQL.Model
{
    public class DataSensor
    {
        public int Id { get; set; }
        public string Humedad { get; set; }
        public string Temperatura { get; set; }
        public string Calidad_Aire { get; set; }
        public string Indice_Benzeno { get; set; }
        public string Fecha { get; set; }
    }
}
