using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_REDSISMICA.Entidades
{
    internal class ClasificacionSismo
    {
        public int kmProfundidadDesde { get; set; }
        public int kmProfundidadHasta { get; set; }
        public string nombre { get; set; }


        public ClasificacionSismo(int kmProfundidadDesde, int kmProfundidadHasta, string nombre)
        {
            this.kmProfundidadDesde = kmProfundidadDesde;
            this.kmProfundidadHasta = kmProfundidadHasta;
            this.nombre = nombre;
        }
    }
}
