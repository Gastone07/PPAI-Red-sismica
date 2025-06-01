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

        private readonly pantallaRegistrarResultadoRevisionManual pantalla;
        // Declarar una variable que contenga un listado de eventos s�smicos
        private List<EventoSismico> eventosSismicos = new List<EventoSismico>();

        private Estado estadoBloqueado = new Estado();

        private Usuario usuarioLogeado = new Usuario();

        private EventoSismico eventoSelec = new EventoSismico();

        private List<Estado> listadoEstado = new List<Estado>();

        private List<Sesion> listadoSesiones = new List<Sesion>();

        private DateTime fechaHoraActual;

        private List<CambioEstado> listadoCambiosEstado = new List<CambioEstado>();

        private CambioEstado cambioEstadoAbierto = new CambioEstado();

        private CambioEstado cambioEstadoNuevo = new CambioEstado();

        private string nombreAlcance = "";
        private string nombreClasificacion = "";
        private string nombreOrigen = "";

        private List<SerieTemporal> seriesVisitadas = new List<SerieTemporal>();
        private List<MuestraSismica> muestrasVisitadas = new List<MuestraSismica>();
        private List<DetalleMuestraSismica> detallesVisitados = new List<DetalleMuestraSismica>();
        private List<(DetalleMuestraSismica, TipoDeDato)> tipoDatoPorDetalle = new List<(DetalleMuestraSismica, TipoDeDato)>();

        private Estado estadoSeleccionado = new Estado();

        #endregion
        //Paso 1 del Caso de Uso
        public controladorRegistrarResultadoRevisionManual(pantallaRegistrarResultadoRevisionManual pan)
        {
            this.pantalla = pan;
        }

       public void registrarResultadoDeRevisionManual()
        {
            //paso 3 del Caso de Uso
            //cargamos los objetos para trabajar
            persistencia();

            buscarEventosAutoDetectado();
            
        }

        public void buscarEventosAutoDetectado()
        {

            // filtramos los eventos que son NoRevisados
            eventosSismicos =  EventoSismico.esPendienteDeRevision(eventosSismicos);

            // Pasar la lista de eventos s�smicos a la pantalla
            pantalla.presentarEventosSismicosPendientesDeRevision(eventosSismicos);
            
        }

        public void tomarSeleccionEventoSismico(EventoSismico eventoSeleccionado)
        {
            // paso 7 caso de uso
            // busco el puntero de la para el estado bloqueado
            eventoSelec = eventoSeleccionado; 
            estadoBloqueado = buscarEstadoBloqueado(listadoEstado);
            //busco el usuario logueado en ese momento
            usuarioLogeado = buscarUsuarioLogeado();

            fechaHoraActual = DateTime.Now;

            actualizarCambioEstado(eventoSeleccionado, listadoCambiosEstado);

        }

        public Estado buscarEstadoBloqueado(List<Estado> listadoEstado)
        {
            // y que el estado bloqueado tiene nombreEstado = "Bloqueado" y ambito = "Estado"            
            return Estado.sosEstadoBloqueado(listadoEstado);
        }

        private Usuario buscarUsuarioLogeado()
        {
            // Simulamos la b�squeda del usuario logueado
            return Sesion.obtenerUsuarioLogueado(listadoSesiones);
        }

        // paso 8 del caso de uso seria nuestro revisar()
        private void actualizarCambioEstado(EventoSismico eventoSeleccionado, List<CambioEstado> cambioEstados)
        {
            //cambio estado del evento para bloquearlo PASO 8 del caso de uso
            cambioEstadoAbierto = EventoSismico.buscarCambioEstadoAbierto(eventoSeleccionado, cambioEstados);

            //seteo fechaHoraFin del cambio de estado abierto
            cambioEstadoAbierto.setFechaHoraFin(fechaHoraActual);
            cambioEstadoNuevo = eventoSeleccionado.crearCambioEstado(estadoBloqueado, fechaHoraActual);
            listadoCambiosEstado.Add(cambioEstadoNuevo);

            //fin paso 8
            buscarDetallesEventoSismico(eventoSeleccionado);
        }

        // paso 9 del caso
        public void buscarDetallesEventoSismico(EventoSismico eventoSeleccionado)
        {
            //guardo los valores de los detalles del evento sismico
            (nombreAlcance, nombreClasificacion, nombreOrigen) = eventoSeleccionado.getDetallesEventoSismico();

            obtenerDatosSeriesTemporal(eventoSeleccionado);
            generarSismograma(seriesVisitadas, muestrasVisitadas, detallesVisitados, tipoDatoPorDetalle);

            pantalla.mostrarDetalleEventoSismico(nombreAlcance, nombreClasificacion, nombreOrigen, eventoSeleccionado.ValorMagnitud);

        }
        public void obtenerDatosSeriesTemporal(EventoSismico eventoSeleccionado)
        {
            //limpio las listas para evitar duplicados
            seriesVisitadas.Clear();
            muestrasVisitadas.Clear();
            detallesVisitados.Clear();
            tipoDatoPorDetalle.Clear();

            //FALTA ORDENAR POR ESTACION
            eventoSeleccionado.buscarSeriesTemporal(seriesVisitadas, muestrasVisitadas, detallesVisitados, tipoDatoPorDetalle);
        }

        public void generarSismograma(List<SerieTemporal> seriesVisitadas, 
                                        List<MuestraSismica> muestrasVisitadas, 
                                        List<DetalleMuestraSismica> detallesVisitados, 
                                        List<(DetalleMuestraSismica, TipoDeDato)> tipoDatoPorDetalle)
        {
            //Generar Sismograma
            //aca llamamos al CU externo

        }

        public void tomarOpcionGrilla(string opcionCombo, string alcance, string origen, double magnitud)
        {
            //paso 14 al 17 con alternativas
            if (opcionCombo == "Rechazar evento")
            {
                estadoSeleccionado = Estado.esRechazado(listadoEstado);
                cambioEstadoAbierto = EventoSismico.buscarCambioEstadoAbierto(eventoSelec, listadoCambiosEstado);
                cambioEstadoAbierto.setFechaHoraFin(fechaHoraActual);
                cambioEstadoNuevo = eventoSelec.crearCambioEstado(estadoSeleccionado, fechaHoraActual);
                listadoCambiosEstado.Add(cambioEstadoNuevo);
            }
            else if (opcionCombo == "Confirmar evento")
            {
                estadoSeleccionado = Estado.esConfirmado(listadoEstado);
                cambioEstadoAbierto = EventoSismico.buscarCambioEstadoAbierto(eventoSelec, listadoCambiosEstado);
                cambioEstadoAbierto.setFechaHoraFin(fechaHoraActual);
                cambioEstadoNuevo = eventoSelec.crearCambioEstado(estadoSeleccionado, fechaHoraActual);
                listadoCambiosEstado.Add(cambioEstadoNuevo);
            }
            else if (opcionCombo == "Solicitar revisi�n a experto")
            {
                estadoSeleccionado = Estado.esRevisadoExperto(listadoEstado);
                cambioEstadoAbierto = EventoSismico.buscarCambioEstadoAbierto(eventoSelec, listadoCambiosEstado);
                cambioEstadoAbierto.setFechaHoraFin(fechaHoraActual);
                cambioEstadoNuevo = eventoSelec.crearCambioEstado(estadoSeleccionado, fechaHoraActual);
                listadoCambiosEstado.Add(cambioEstadoNuevo);
            }
            else
            {
                // Manejar caso no v�lido
                throw new ArgumentException("Opci�n no v�lida");
            }
            buscarEventosAutoDetectado();
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


            //Estacion Sismografica
            EstacionSismografica estacion1 = new EstacionSismografica(1, "DocumentoCertificacion1", DateTime.Now, 48.99, 29.01, "La boca", 1);
            EstacionSismografica estacion2 = new EstacionSismografica(2, "DocumentoCertificacion2", DateTime.Now, 19.44, 07.58, "Capital", 2);

            //sismografo
            Sismografo sismografo1 = new Sismografo(DateTime.Now, 1, 1999, estacion1);
            Sismografo sismografo2 = new Sismografo(DateTime.Now, 2, 2000, estacion2);

            //Series temporales(solo una de momento)

            var serieTemporal1 = new SerieTemporal( false, DateTime.Now, DateTime.Now, 50, [muestraSismica1, muestraSismica2, muestraSismica3],sismografo1);
            var serieTemporal2 = new SerieTemporal( false, DateTime.Now, DateTime.Now, 50, [muestraSismica4],sismografo1);
            var serieTemporal3 = new SerieTemporal( false, DateTime.Now, DateTime.Now, 50, [muestraSismica5], sismografo2);


            //Estados
            var estadoNoRevisado = new Estado("evento", "NoRevisado");
            var estadoRevisado = new Estado("evento", "Revisado");
            var estadoBloqueado = new Estado("evento", "BloqueadoEnRevision");
            var estadoRechazado = new Estado("evento", "Rechazado");
            var estadoConfirmado = new Estado("evento", "Confirmado");
            var estadoRevisadoExperto = new Estado("evento", "RevisadoPorExperto");
            var estadoBloqueado2 = new Estado("sismografo", "SismografoBloqueado");
            var estadoBloqueado3 = new Estado("sismografo", "SismografoDisponible");

            listadoEstado.Add(estadoNoRevisado);
            listadoEstado.Add(estadoRevisado);
            listadoEstado.Add(estadoBloqueado);
            listadoEstado.Add(estadoBloqueado2);
            listadoEstado.Add(estadoBloqueado3);
            listadoEstado.Add(estadoRechazado);
            listadoEstado.Add(estadoConfirmado);
            listadoEstado.Add(estadoRevisadoExperto);

            //clasificacion
            ClasificacionSismo clasificacionSismo1 = new ClasificacionSismo(0, 70, "Superficial");
            ClasificacionSismo clasificacionSismo2 = new ClasificacionSismo(70, 300, "Intermedio");
            ClasificacionSismo clasificacionSismo3 = new ClasificacionSismo(300, 700, "profundo");

            //Origen de Generacion
            OrigenDeGeneracion origenGeneracion1 = new OrigenDeGeneracion("Tectonico", "Movimientos de las placas tect�nicas en la corteza terrestre, causados por la acumulaci�n y liberaci�n de energ�a en fallas geol�gicas");
            OrigenDeGeneracion origenGeneracion2 = new OrigenDeGeneracion("Volcanico", "Actividad volc�nica, como el movimiento de magma, gases o fracturamiento de roca en c�maras magm�ticas.");
            OrigenDeGeneracion origenGeneracion3 = new OrigenDeGeneracion("Inducido", "Actividades humanas, como la extracci�n de petr�leo o gas, la inyecci�n de fluidos en el subsuelo (fracking), la construcci�n de embalses o la miner�a.");

            // Crear Alcance Sismo
            AlcanceSismo alcanceSismo1 = new AlcanceSismo("Local", "Afecta una regi�n geogr�fica limitada, como una ciudad o un �rea metropolitana.");
            AlcanceSismo alcanceSismo2 = new AlcanceSismo("Regional", "Afectan una regi�n m�s amplia, abarcando decenas o cientos de kil�metros desde el epicentro.");
            AlcanceSismo alcanceSismo3 = new AlcanceSismo("Telurico", "Pueden sentirse a cientos o miles de kil�metros del epicentro, afectando grandes regiones o incluso pa�ses.");


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


            // Eventos S�smicos
            eventosSismicos.Add(new EventoSismico(
                new DateTime(2024, 6, 11, 14, 30, 0),
                new DateTime(2024, 6, 11, 14, 45, 0),
                34.6037,
                58.3816,
                34.6040,
                58.3820,
                5.2,
                cambioEstado1,
                estadoNoRevisado,
                [serieTemporal1],
                alcanceSismo1, origenGeneracion1, clasificacionSismo1
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
                estadoNoRevisado, [serieTemporal2, serieTemporal3],
                alcanceSismo2, origenGeneracion2, clasificacionSismo2

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
                estadoNoRevisado, null,
                alcanceSismo3, origenGeneracion3, clasificacionSismo3
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
                estadoNoRevisado, null,
                alcanceSismo1, origenGeneracion1, clasificacionSismo1
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
               estadoRevisado, null,
               alcanceSismo2, origenGeneracion2, clasificacionSismo2
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
               estadoRevisado, null,
               alcanceSismo3, origenGeneracion3, clasificacionSismo3    
           ));
           

            // Simulamos la b�squeda en BD y ordenamos por fecha de ocurrencia  
            eventosSismicos = eventosSismicos
                .OrderBy(e => e.FechaHoraOcurrencia).ToList();
        }
    }
    
}