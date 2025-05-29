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

        public MuestraSismica(DateTime fechaHoraMuestra)
        {
            this.fechaHoraMuestra = fechaHoraMuestra;
        }
    }

}
