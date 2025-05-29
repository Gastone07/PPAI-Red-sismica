using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_REDSISMICA.Entidades
{
    public class CambioEstado
    {
        public DateTime fechaHoraInicio { get; set; }
        public DateTime fechaHoraFin { get; set; }
        public Estado estado { get; set; }

        public CambioEstado(DateTime fechaHoraInicio, DateTime fechaHoraFin, Estado estado)
        {
            this.fechaHoraInicio = fechaHoraInicio;
            this.fechaHoraFin = fechaHoraFin;
            this.estado = estado;
        }
    }
}
