using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_REDSISMICA.Entidades
{
    public class SerieTemporal
    {
        public int condicionAlarma { get; set; }

        public DateTime fechaHoraInicioRegistroMuestras { get; set; }

        public DateTime fechaHoraRegistro { get; set; }

        public int frecuenciaMuestreo { get; set; }

        public SerieTemporal(int condicionAlarma, DateTime fechaHoraInicioRegistroMuestras, DateTime fechaHoraRegistro, int frecuenciaMuestreo)
        {
            this.condicionAlarma = condicionAlarma;
            this.fechaHoraInicioRegistroMuestras = fechaHoraInicioRegistroMuestras;
            this.fechaHoraRegistro = fechaHoraRegistro;
            this.frecuenciaMuestreo = frecuenciaMuestreo;
        }

        
    }
}
