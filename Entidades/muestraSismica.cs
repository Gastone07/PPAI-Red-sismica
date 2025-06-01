using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_REDSISMICA.Entidades
{
    public class MuestraSismica
    {
        public DateTime fechaHoraMuestra { get; set; }

        private List<DetalleMuestraSismica> detallesMuestrasSismicas = new List<DetalleMuestraSismica>();

        public MuestraSismica(DateTime fechaHoraMuestra, List<DetalleMuestraSismica> detallesMuestrasSismicas)
        {
            this.fechaHoraMuestra = fechaHoraMuestra;
            this.detallesMuestrasSismicas = detallesMuestrasSismicas;

        }

        public TipoDeDato getDatos()
        {
            if (detallesMuestrasSismicas == null || detallesMuestrasSismicas.Count == 0)
            {
                throw new InvalidOperationException("No hay detalles de muestra sismica asociados a la muestra.");
            }
            else
            {
                foreach (var detalle in detallesMuestrasSismicas)
                {
                    return detalle.getTipoDato(); // Obtiene los datos de la muestra sismica
                }
            }
            throw new InvalidOperationException("No hay detalles de muestra sismica validos.");
        }
    }

}
