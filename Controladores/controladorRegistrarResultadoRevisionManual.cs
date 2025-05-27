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

            // Si existiera bd, llamamos al modelo y traemos la lista ya ordenada.
        }

    }
    
}