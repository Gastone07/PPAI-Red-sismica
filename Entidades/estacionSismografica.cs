using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_REDSISMICA.Entidades
{
    public class EstacionSismografica
    {
        public int codigoEstacion { get; set; }

        public string documentoCertificacionAdq { get; set; }

        public DateTime fechaSolicitudCertificacion { get; set; }

        public int latitud { get; set; }

        public int longitud { get; set; }   

        public string nombre { get; set; } 

        public int nroCerticacionAdquisicion { get; set; }  


        public EstacionSismografica(int codigoEstacion, string documentoCertificacionAdq, DateTime fechaSolicitudCertificacion, int latitud, int longitud, string nombre, int nroCerticacionAdquisicion)
        {
            this.codigoEstacion = codigoEstacion;
            this.documentoCertificacionAdq = documentoCertificacionAdq;
            this.fechaSolicitudCertificacion = fechaSolicitudCertificacion;
            this.latitud = latitud;
            this.longitud = longitud;
            this.nombre = nombre;
            this.nroCerticacionAdquisicion = nroCerticacionAdquisicion;
        }

    }
}
