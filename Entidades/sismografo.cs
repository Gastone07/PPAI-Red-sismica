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

        private EstacionSismografica estacionSismografica;

        public Sismografo(DateTime fechaAdquisicion, int identificador, int nroSerie, EstacionSismografica estacionSismografica)
        {
            this.fechaAdquisicion = fechaAdquisicion;
            this.identificador = identificador;
            this.nroSerie = nroSerie;
            this.estacionSismografica = estacionSismografica;
        }

        public string getNombreEstacion()
        {
            return this.estacionSismografica.getNombre(); // Obtiene el nombre de la estacion sismografica
        }
    }
}
