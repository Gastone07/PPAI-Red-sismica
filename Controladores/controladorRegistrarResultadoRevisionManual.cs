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
            // Simulamos la carga de base de datos porque aún no tenemos una base de datos real
            EventoSismico.esPendienteDeRevision(eventosSismicos);

            // Pasar la lista de eventos sísmicos a la pantalla
            pantalla.presentarEventosSismicosPendientesDeRevision(eventosSismicos);
            
        }

        public void tomarSeleccionEventoSismico(EventoSismico eventoSeleccionado)
        {
            // paso 7 caso de uso
            // busco el puntero de la para el estado bloqueado
            estadoBloqueado = buscarEstadoBloqueado(eventoSeleccionado);
            //busco el usuario logueado en ese momento
            usuarioLogeado = buscarUsuarioLogeado();


        }

        private Estado buscarEstadoBloqueado(EventoSismico eventoSeleccionado)
        {
            // Buscar el estado bloqueado en la lista de estados
            // Suponiendo que existe una lista estática de estados en la clase Estado
            // y que el estado bloqueado tiene nombreEstado = "Bloqueado" y ambito = "Estado"            
            return Estado.sosEstadoBloqueado();
        }

        private Usuario buscarUsuarioLogeado()
        {
            // Simulamos la búsqueda del usuario logueado
            return Sesion.obtenerUsuarioLogueado();
        }
    }
    
}