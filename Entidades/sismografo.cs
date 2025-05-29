using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_REDSISMICA.Entidades
{
    public class Sismografo
    {
        public DateTime fechaAdquisicion { get; set; }

        public int identificador { get; set; }

        public int nroSerie { get; set; }

        public Sismografo(DateTime fechaAdquisicion, int identificador, int nroSerie)
        {
            this.fechaAdquisicion = fechaAdquisicion;
            this.identificador = identificador;
            this.nroSerie = nroSerie;
        }
    }
}
