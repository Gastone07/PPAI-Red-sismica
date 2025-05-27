using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_REDSISMICA.Entidades
{
    internal class serieTemporal
    {
        public int condicionAlarma { get; set; }

        public DateTime fechaHoraInicioRegistroMuestras { get; set; }

        public DateTime fechaHoraRegistro { get; set; }

        public int frecuenciaMuestreo { get; set; }
    }
}
