using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassEntidades
{
    public class Conexion
    {
        public int IdConex { get; set; }
        public int Client { get; set; }
        public int Aut { get; set; }
        public int Marc { get; set; }
        public int Mecanic { get; set; }
        public string Fecha_Entra { get; set; }
        public string DescripcionFalla { get; set; }
    }
}
