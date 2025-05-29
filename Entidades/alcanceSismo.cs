using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_REDSISMICA.Entidades
{
    internal class AlcanceSismo
    {
        public string descripcion { get; set; }
        public string nombre { get; set; }

        public AlcanceSismo(string nombre, string descripcion)
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
        }
    }



}
