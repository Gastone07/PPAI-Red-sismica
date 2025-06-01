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
    }

}
