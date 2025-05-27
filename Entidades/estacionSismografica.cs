using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_REDSISMICA.Entidades
{
    internal class estacionSismografica
    {
        public int codigoEstacion { get; set; }

        public string documentoCertificacionAdq { get; set; }

        public DateTime fechaSolicitudCertificacion { get; set; }

        public int latitud { get; set; }

        public int longitud { get; set; }   

        public string nombre { get; set; } 

        public int nroCerticacionAdquisicion { get; set; }  


    }
}
