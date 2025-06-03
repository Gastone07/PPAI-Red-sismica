using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_REDSISMICA.Entidades
{
    public class Sesion
    {
        private Usuario usuario { get; set; }
        private DateTime fechaHoraInicio { get; set; }
        private DateTime? fechaHoraFin { get; set; }
        
        public Sesion(Usuario usuario, DateTime fechaHoraInicio, DateTime? fechaHoraFin)
        {
            this.usuario = usuario;
            this.fechaHoraInicio = fechaHoraInicio;
            this.fechaHoraFin = fechaHoraFin;
        }

        public static Usuario obtenerUsuarioLogueado(List<Sesion> listadoSesiones)
        {
            foreach (var sesion in listadoSesiones)
            {
                if (sesion.fechaHoraFin == null)
                {
                    return Usuario.obtenerLogueado(sesion.usuario); // Retorna el usuario encontrado
                }
            }
            return new Usuario(); // Si no se encuentra el usuario
            //return Usuario.obtenerLogueado(listadoSesiones);
        }
    }
}
