using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_REDSISMICA.Entidades
{
    public class CambioEstado
    {
        private DateTime fechaHoraInicio { get; set; }

        private DateTime? fechaHoraFin { get; set; }
        private Estado estado { get; set; }

        public CambioEstado(DateTime fechaHoraInicio, DateTime? fechaHoraFin, Estado estado)
        {
            this.fechaHoraInicio = fechaHoraInicio;
            this.fechaHoraFin = fechaHoraFin;
            this.estado = estado;
        }

        public CambioEstado()
        {
            // Constructor por defecto
        }

        public static CambioEstado sosActual(EventoSismico evento, List<CambioEstado> cambioEstados)
        {

            foreach (var cambio in cambioEstados)
            {
                if (evento.CambioEstado == cambio) // Verifico cuales Cambios de estado son del evento seleccionado 
                {
                    return cambio; // Retorna el primer cambio de estado abierto encontrado
                }
            }
            return null; // Si no se encuentra un cambio de estado abierto
        }

        public void setFechaHoraFin(DateTime fecha)
        {
           fechaHoraFin = fecha;
        }

        
    }
}
