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

        private List<CambioEstado> listadoCambiosEstado = new List<CambioEstado>();

        private CambioEstado cambioEstadoAbierto = new CambioEstado();
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

            buscarCambioEstadoAbierto(eventoSeleccionado, listadoCambiosEstado);



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

        // paso 8 del caso de uso seria nuestro revisar()
        private void buscarCambioEstadoAbierto(EventoSismico eventoSeleccionado, List<CambioEstado> cambioEstados)
        {
            //cambio estado del evento para bloquearlo PASO 8 del caso de uso
            cambioEstadoAbierto = EventoSismico.buscarCambioEstadoAbierto(eventoSeleccionado, cambioEstados);

            //seteo fechaHoraFin del cambio de estado abierto
            cambioEstadoAbierto.setFechaHoraFin(fechaHoraActual);
            eventoSeleccionado.crearCambioEstado(estadoBloqueado, fechaHoraActual);
            //fin paso 8
            buscarDetallesEventoSismico(eventoSeleccionado);
        }

        // paso 9 del caso
        public void buscarDetallesEventoSismico(EventoSismico eventoSeleccionado)
        {
            eventoSeleccionado.getDetallesEventoSismico();
            obtenerDatosSeriesTemporal(eventoSeleccionado);

        }
        public void obtenerDatosSeriesTemporal(EventoSismico eventoSeleccionado)
        {
            eventoSeleccionado.buscarSeriesTermporal();
        }
        private void persistencia()
        {
            eventosSismicos.Clear();

            //tipo dato
            var tipoDato1 = new TipoDeDato("Velocidad Onda", "Km/seg", 8.0);
            var tipoDato2 = new TipoDeDato("Frecuencia de onda", "Hz", 15.0);
            var tipoDato3 = new TipoDeDato("Longitud", "Km/ciclo", 1.0);
            
            //Detalle muestra sismica 

            var detalleMuestra1 = new DetalleMuestraSismica(7,tipoDato1);
            var detalleMuestra2 = new DetalleMuestraSismica(10, tipoDato2);
            var detalleMuestra3 = new DetalleMuestraSismica(0.7, tipoDato3);
            
            var detalleMuestra4 = new DetalleMuestraSismica(7.02, tipoDato1);
            var detalleMuestra5 = new DetalleMuestraSismica(10, tipoDato2);
            var detalleMuestra6 = new DetalleMuestraSismica(0.69, tipoDato3);

            var detalleMuestra7 = new DetalleMuestraSismica(6.99, tipoDato1);
            var detalleMuestra8 = new DetalleMuestraSismica(10.01, tipoDato2);
            var detalleMuestra9 = new DetalleMuestraSismica(0.7, tipoDato3);

            var detalleMuestra10 = new DetalleMuestraSismica(5.01, tipoDato1);
            var detalleMuestra11 = new DetalleMuestraSismica(9.82, tipoDato2);
            var detalleMuestra12 = new DetalleMuestraSismica(0.33, tipoDato3);

            var detalleMuestra13 = new DetalleMuestraSismica(7.36, tipoDato1);
            var detalleMuestra14 = new DetalleMuestraSismica(6.12, tipoDato2);
            var detalleMuestra15 = new DetalleMuestraSismica(0.14, tipoDato3);



            //Muestra sismica 

            var muestraSismica1 = new MuestraSismica(
                new DateTime(2024, 6, 11, 14, 30, 0),
                [detalleMuestra1,
                detalleMuestra2,
                detalleMuestra3]
            );
            
            var muestraSismica2 = new MuestraSismica(
                new DateTime(2024, 6, 11, 14, 35, 0),
                [detalleMuestra4,
                detalleMuestra5,
                detalleMuestra6]
            );

            var muestraSismica3 = new MuestraSismica(
                new DateTime(2024, 6, 11, 14, 40, 0),
                [detalleMuestra7,
                detalleMuestra8,
                detalleMuestra9]
            );
            

            var muestraSismica4 = new MuestraSismica(
                new DateTime(2024, 6, 11, 14, 45, 0),
                [detalleMuestra10,
                detalleMuestra11,
                detalleMuestra12]
            );

            var muestraSismica5 = new MuestraSismica(
                new DateTime(2024, 8, 12, 14, 50, 0),
                [detalleMuestra13,
                detalleMuestra14,
                detalleMuestra15]
            );

            //Series temporales(solo una de momento)

            var serieTemporal1 = new SerieTemporal( false, DateTime.Now, DateTime.Now, 50, [muestraSismica1, muestraSismica2, muestraSismica3]);
            var serieTemporal2 = new SerieTemporal( false, DateTime.Now, DateTime.Now, 50, [muestraSismica4]);
            var serieTemporal3 = new SerieTemporal( false, DateTime.Now, DateTime.Now, 50, [muestraSismica5]);


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

            // Cambios de Estado

            var cambioEstado1 = new CambioEstado(
                new DateTime(2024, 6, 11, 14, 30, 0),
                new DateTime(2024, 6, 11, 14, 45, 0),
                estadoNoRevisado
            );
            var cambioEstado2 = new CambioEstado(
                new DateTime(2024, 6, 23, 9, 15, 0),
                new DateTime(2024, 6, 23, 9, 30, 0),
                estadoNoRevisado
            );
            var cambioEstado3 = new CambioEstado(
                new DateTime(2024, 6, 19, 22, 5, 0),
                new DateTime(2024, 6, 19, 22, 20, 0),
                estadoNoRevisado
            );
            var cambioEstado4 = new CambioEstado(
                new DateTime(2024, 6, 29, 3, 50, 0),
                new DateTime(2024, 6, 29, 14, 5, 0),
                estadoNoRevisado
            );
            var cambioEstado5 = new CambioEstado(
                new DateTime(2024, 6, 29, 3, 50, 0),
                new DateTime(2024, 6, 29, 14, 5, 0),
                estadoRevisado
            );
            var cambioEstado6 = new CambioEstado(
                new DateTime(2025, 6, 29, 3, 50, 0),
                new DateTime(2025, 6, 29, 14, 5, 0),
                estadoRevisado
            );
            
            listadoCambiosEstado.Add(cambioEstado1);
            listadoCambiosEstado.Add(cambioEstado2);
            listadoCambiosEstado.Add(cambioEstado3);
            listadoCambiosEstado.Add(cambioEstado4);
            listadoCambiosEstado.Add(cambioEstado5);
            listadoCambiosEstado.Add(cambioEstado6);

            // Usuario
            var usuario1 = new Usuario("12345", "Serna");
            var usuario2 = new Usuario("bocaboca", "Roman");

            var sesion1 = new Sesion(usuario2, DateTime.Now.AddHours(-1), DateTime.Now);
            var sesionActual = new Sesion(usuario1, DateTime.Now,null);

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
                cambioEstado1,
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
               cambioEstado2,
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
                cambioEstado3,
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
                cambioEstado4,
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
               cambioEstado5,
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
               cambioEstado6,
               estadoRevisado
           ));
           

            // Simulamos la búsqueda en BD y ordenamos por fecha de ocurrencia  
            eventosSismicos = eventosSismicos
                .OrderBy(e => e.FechaHoraOcurrencia).ToList();
        }
    }
    
}