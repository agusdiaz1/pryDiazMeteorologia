using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pryDiazMeteorologia
{
    public class Temperatura
    {
        public int IdLocalidad { get; set; }
        public DateTime Fecha { get; set; }
        public double TempMin { get; set; }
        public double TempMax { get; set; }
    }
}
