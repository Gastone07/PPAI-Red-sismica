using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_REDSISMICA.Entidades
{
    public class EstacionSismografica
    {
        private int codigoEstacion { get; set; }

        private string documentoCertificacionAdq { get; set; }

        private DateTime fechaSolicitudCertificacion { get; set; }

        private double latitud { get; set; }

        private double longitud { get; set; }   

        private string nombre { get; set; } 

        private int nroCerticacionAdquisicion { get; set; }  


        public EstacionSismografica(int codigoEstacion, string documentoCertificacionAdq, DateTime fechaSolicitudCertificacion, double latitud, double longitud, string nombre, int nroCerticacionAdquisicion)
        {
            this.codigoEstacion = codigoEstacion;
            this.documentoCertificacionAdq = documentoCertificacionAdq;
            this.fechaSolicitudCertificacion = fechaSolicitudCertificacion;
            this.latitud = latitud;
            this.longitud = longitud;
            this.nombre = nombre;
            this.nroCerticacionAdquisicion = nroCerticacionAdquisicion;
        }

        public string getNombre()
        {
            return this.nombre; // Retorna el nombre de la estacion sismografica
        }

    }
}
