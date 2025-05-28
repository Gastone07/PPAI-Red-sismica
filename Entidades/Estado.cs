using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_REDSISMICA.Entidades
{
    public class Estado
    {
        public string ambito { get; set; }
        public string nombreEstado { get; set; }

        public static Estado sosEstadoBloqueado()
        {
            // Simulamos la búsqueda del estado bloqueado en una lista de estados
            // En un caso real, esto podría ser una consulta a una base de datos o una lista estática
            return new Estado { ambito = "Estado", nombreEstado = "Bloqueado" };
        }

    }
}
