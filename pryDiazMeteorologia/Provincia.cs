using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pryDiazMeteorologia
{
    public class Provincia
    {
        public int IdProvincia { get; set; }
        public string NombreProvincia { get; set; }
        public List<Localidad> Localidades { get; set; } = new List<Localidad>();
    }
}
