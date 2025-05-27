using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Documents;
using Vistas;

namespace Controladores
{
    public class controladorRegistrarResultadoRevisionManual
    {
        #region aributos

        private readonly pantallaRegistrarResultadoRevisionManual pantalla;
        // Declarar una variable que contenga un listado de eventos sísmicos
        private List<eventoSismico> eventosSismicos = new List<eventoSismico>();

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
            //simulamos la carga de base de datos porque aun no tenemos una base de datos real
            crearEventosInicio();

            


        }

        public void crearEventosInicio()
        {
            eventosSismicos.Add(new EventoSismico
            {
                FechaHoraOcurrencia = new DateTime(2024, 6, 1, 14, 30, 0),
                FechaHoraFin = new DateTime(2024, 6, 1, 14, 45, 0),
                LatitudEpicentro = -34.6037,
                LongitudEpicentro = -58.3816,
                LatitudHipocentro = -34.6040,
                LongitudHipocentro = -58.3820,
                ValorMagnitud = 5.2
            });
            eventosSismicos.Add(new EventoSismico
            {
                FechaHoraOcurrencia = new DateTime(2024, 6, 2, 9, 15, 0),
                FechaHoraFin = new DateTime(2024, 6, 2, 9, 30, 0),
                LatitudEpicentro = -31.4201,
                LongitudEpicentro = -64.1888,
                LatitudHipocentro = -31.4210,
                LongitudHipocentro = -64.1895,
                ValorMagnitud = 4.8
            });
            eventosSismicos.Add(new EventoSismico
            {
                FechaHoraOcurrencia = new DateTime(2024, 6, 3, 22, 5, 0),
                FechaHoraFin = new DateTime(2024, 6, 3, 22, 20, 0),
                LatitudEpicentro = -32.9471,
                LongitudEpicentro = -60.6505,
                LatitudHipocentro = -32.9480,
                LongitudHipocentro = -60.6510,
                ValorMagnitud = 6.1
            });
            eventosSismicos.Add(new EventoSismico
            {
                FechaHoraOcurrencia = new DateTime(2024, 6, 4, 3, 50, 0),
                FechaHoraFin = new DateTime(2024, 6, 4, 4, 5, 0),
                LatitudEpicentro = -24.7821,
                LongitudEpicentro = -65.4232,
                LatitudHipocentro = -24.7830,
                LongitudHipocentro = -65.4240,
                ValorMagnitud = 5.7
            });


        }


    }
    
}