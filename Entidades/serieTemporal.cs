using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_REDSISMICA.Entidades
{
    public class SerieTemporal
    {
        private bool condicionAlarma { get; set; }

        private DateTime fechaHoraInicioRegistroMuestras { get; set; }

        private DateTime fechaHoraRegistro { get; set; }

        private int frecuenciaMuestreo { get; set; }

        private List<MuestraSismica> muestrasSismicas = new List<MuestraSismica>();

        public SerieTemporal(bool condicionAlarma, DateTime fechaHoraInicioRegistroMuestras, DateTime fechaHoraRegistro, int frecuenciaMuestreo, List<MuestraSismica> muestrasSismicas)
        {
            this.condicionAlarma = condicionAlarma;
            this.fechaHoraInicioRegistroMuestras = fechaHoraInicioRegistroMuestras;
            this.fechaHoraRegistro = fechaHoraRegistro;
            this.frecuenciaMuestreo = frecuenciaMuestreo;
            this.muestrasSismicas = muestrasSismicas;
        }

        public MuestraSismica getDatos()
        {
            if (muestrasSismicas == null || muestrasSismicas.Count == 0)
            {
                throw new InvalidOperationException("No hay muestras asociadas a la serie temporal.");
            }
            else
            {
                foreach (var muestra in muestrasSismicas)
                {
                    muestra.getDatos(); // Obtiene los datos de la serie temporal
                }
            }
            throw new InvalidOperationException("No hay muestras temporal validas.");
        }


    }
}
