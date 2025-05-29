using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_REDSISMICA.Entidades
{
    public class TipoDeDato
    {
        public string denominacion { get; set; }

        public string nombreUnidadMedida { get; set; }

        public int valorUmbral { get; set; }

        public TipoDeDato(string denominacion, string nombreUnidadMedida, int valorUmbral)
        {
            this.denominacion = denominacion;
            this.nombreUnidadMedida = nombreUnidadMedida;
            this.valorUmbral = valorUmbral;
        }
    }
}
