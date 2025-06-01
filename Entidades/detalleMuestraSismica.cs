using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_REDSISMICA.Entidades
{
    public class DetalleMuestraSismica
    {
        public double valor { get; set; }

        private TipoDeDato tipoDeDato;
        public DetalleMuestraSismica(double valor, TipoDeDato tipoDeDato)
        {
            this.valor = valor;
            this.tipoDeDato = tipoDeDato;
        }
    }
}
