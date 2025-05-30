using PPAI_REDSISMICA.Entidades;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Documents;
using Vistas;

namespace Controladores
{
    public class controladorRegistrarResultadoRevisionManual
    {
        #region aributos

        public readonly pantallaRegistrarResultadoRevisionManual pantalla;
        // Declarar una variable que contenga un listado de eventos sísmicos
        public List<EventoSismico> eventosSismicos = new List<EventoSismico>();

        public Estado estadoBloqueado = new Estado();  

        public Usuario usuarioLogeado = new Usuario();

        private List<Estado> listadoEstado = new List<Estado>();

        private List<Sesion> listadoSesiones = new List<Sesion>();

        private DateTime fechaHoraActual;
        #endregion
        //Paso 1 del Caso de Uso
        public controladorRegistrarResultadoRevisionManual(pantallaRegistrarResultadoRevisionManual pan)
        {
            this.pantalla = pan;
        }

       public void registrarResultadoDeRevisionManual()
        {
            //paso 3 del Caso de Uso
            buscarEventosAutoDetectado();
            
        }

        public void buscarEventosAutoDetectado()
        {
            //cargamos los objetos para trabajar
            persistencia();

            // filtramos los eventos que son NoRevisados
            eventosSismicos =  EventoSismico.esPendienteDeRevision(eventosSismicos);

            // Pasar la lista de eventos sísmicos a la pantalla
            pantalla.presentarEventosSismicosPendientesDeRevision(eventosSismicos);
            
        }

        public void tomarSeleccionEventoSismico(EventoSismico eventoSeleccionado)
        {
            // paso 7 caso de uso
            // busco el puntero de la para el estado bloqueado
            estadoBloqueado = buscarEstadoBloqueado(listadoEstado);
            //busco el usuario logueado en ese momento
            usuarioLogeado = buscarUsuarioLogeado();

            fechaHoraActual = DateTime.Now;

            buscarCambioEstadoAbierto(eventoSeleccionado);



        }

        public Estado buscarEstadoBloqueado(List<Estado> listadoEstado)
        {
            // y que el estado bloqueado tiene nombreEstado = "Bloqueado" y ambito = "Estado"            
            return Estado.sosEstadoBloqueado(listadoEstado);
        }

        private Usuario buscarUsuarioLogeado()
        {
            // Simulamos la búsqueda del usuario logueado
            return Sesion.obtenerUsuarioLogueado(listadoSesiones);
        }

        private void buscarCambioEstadoAbierto(EventoSismico eventoSeleccionado)
        {
            //cambio estado del evento para bloquearlo PASO 8 del caso de uso
            CambioEstado.sosActual(eventoSeleccionado);
        }
        

        private void persistencia()
        {
            eventosSismicos.Clear();

            //Estados
            var estadoNoRevisado = new Estado("evento", "NoRevisado");
            var estadoRevisado = new Estado("evento", "Revisado");
            var estadoBloqueado = new Estado("evento", "BloqueadoEnRevision");
            var estadoBloqueado2 = new Estado("sismografo", "SismografoBloqueado");
            var estadoBloqueado3 = new Estado("sismografo", "SismografoDisponible");

            listadoEstado.Add(estadoNoRevisado);
            listadoEstado.Add(estadoRevisado);
            listadoEstado.Add(estadoBloqueado);
            listadoEstado.Add(estadoBloqueado2);
            listadoEstado.Add(estadoBloqueado3);

            // Usuario
            var usuario1 = new Usuario("12345", "Serna");
            var usuario2 = new Usuario("bocaboca", "Roman");

            var sesion1 = new Sesion(usuario2, DateTime.Now.AddHours(-1), DateTime.Now);
            var sesionActual = new Sesion(usuario1, DateTime.Now);

            listadoSesiones.Add(sesion1);
            listadoSesiones.Add(sesionActual);


            // Eventos Sísmicos
            eventosSismicos.Add(new EventoSismico(
                new DateTime(2024, 6, 11, 14, 30, 0),
                new DateTime(2024, 6, 11, 14, 45, 0),
                34.6037,
                58.3816,
                34.6040,
                58.3820,
                5.2,
                new CambioEstado(
                    new DateTime(2024, 6, 12, 14, 30, 0),
                    DateTime.Now,
                    estadoNoRevisado
                ),
                estadoNoRevisado
            ));
            eventosSismicos.Add(new EventoSismico(
                new DateTime(2024, 6, 23, 9, 15, 0),
                new DateTime(2024, 6, 23, 9, 30, 0),
                31.4201,
                64.1888,
                31.4210,
                64.1895,
                4.8,
                new CambioEstado(
                    new DateTime(2024, 6, 23, 9, 15, 0),
                    DateTime.Now,
                    estadoNoRevisado
                ),
                estadoNoRevisado
            ));
            eventosSismicos.Add(new EventoSismico(
                new DateTime(2024, 6, 19, 22, 5, 0),
                new DateTime(2024, 6, 19, 22, 20, 0),
                32.9471,
                60.6505,
                32.9480,
                60.6510,
                6.1,
                new CambioEstado(
                    new DateTime(2024, 6, 19, 22, 5, 0),
                    DateTime.Now,
                    estadoNoRevisado
                ),
                estadoNoRevisado
            ));
            eventosSismicos.Add(new EventoSismico(
                new DateTime(2024, 6, 29, 3, 50, 0),
                new DateTime(2024, 6, 29, 14, 5, 0),
                24.7821,
                65.4232,
                24.7830,
                65.4240,
                5.7,
                new CambioEstado(
                    new DateTime(2024, 6, 29, 3, 50, 0),
                    DateTime.Now,
                    estadoNoRevisado
                ),
                estadoNoRevisado
            ));
            //evetos "revisados"
            eventosSismicos.Add(new EventoSismico(
               new DateTime(2024, 6, 29, 3, 50, 0),
               new DateTime(2024, 6, 29, 14, 5, 0),
               24.7821,
               65.4232,
               24.7830,
               65.4240,
               5.7,
               new CambioEstado(
                   new DateTime(2024, 6, 29, 3, 50, 0),
                   new DateTime(2024, 6, 29, 14, 5, 0),
                   estadoRevisado
               ),
               estadoRevisado
           ));
            eventosSismicos.Add(new EventoSismico(
               new DateTime(2025, 6, 29, 3, 50, 0),
               new DateTime(2025, 6, 29, 14, 5, 0),
               24.7821,
               65.4232,
               24.7830,
               65.4240,
               5.7,
               new CambioEstado(
                   new DateTime(2024, 6, 29, 3, 50, 0),
                   new DateTime(2024, 6, 29, 14, 5, 0),
                   estadoRevisado
               ),
               estadoRevisado
           ));


            // Simulamos la búsqueda en BD y ordenamos por fecha de ocurrencia  
            eventosSismicos = eventosSismicos
                .OrderBy(e => e.FechaHoraOcurrencia).ToList();
        }
    }
    
}