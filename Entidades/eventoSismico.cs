using PPAI_REDSISMICA.Entidades;
using System;

public class EventoSismico
{
    public DateTime FechaHoraFin { get; set; }
    public DateTime FechaHoraOcurrencia { get; set; }
    public double LatitudEpicentro { get; set; }
    public double LatitudHipocentro { get; set; }
    public double LongitudEpicentro { get; set; }
    public double LongitudHipocentro { get; set; }
    public double ValorMagnitud { get; set; }
    public required CambioEstado CambioEstado { get; set; }
    public Estado estadoActual { get; set; }

    public static void esPendienteDeRevision(List<EventoSismico> eventosSismicos)
    {
        crearEventosInicio(eventosSismicos);
    }

    private static void crearEventosInicio(List<EventoSismico> eventosSismicos)
    {
        eventosSismicos.Clear();

        var estadoNoRevisado = new Estado { ambito = "evento", nombreEstado = "NoRevisado" };
        var estadoRevisado = new Estado { ambito = "evento", nombreEstado = "Revisado" };

        eventosSismicos.Add(new EventoSismico
        {
            FechaHoraOcurrencia = new DateTime(2024, 6, 11, 14, 30, 0),
            FechaHoraFin = new DateTime(2024, 6, 11, 14, 45, 0),
            LatitudEpicentro = 34.6037,
            LongitudEpicentro = 58.3816,
            LatitudHipocentro = 34.6040,
            LongitudHipocentro = 58.3820,
            ValorMagnitud = 5.2,
            CambioEstado = new CambioEstado
            {
                fechaHoraInicio = new DateTime(2024, 6, 12, 14, 30, 0),
                fechaHoraFin = new DateTime(2024, 6, 12, 14, 45, 0),
                estado = estadoNoRevisado
            },
            estadoActual = estadoNoRevisado
        });
        eventosSismicos.Add(new EventoSismico
        {
            FechaHoraOcurrencia = new DateTime(2024, 6, 23, 9, 15, 0),
            FechaHoraFin = new DateTime(2024, 6, 23, 9, 30, 0),
            LatitudEpicentro = 31.4201,
            LongitudEpicentro = 64.1888,
            LatitudHipocentro = 31.4210,
            LongitudHipocentro = 64.1895,
            ValorMagnitud = 4.8,
            CambioEstado = new CambioEstado
            {
                fechaHoraInicio = new DateTime(2024, 6, 2, 9, 15, 0),
                fechaHoraFin = new DateTime(2024, 6, 2, 9, 30, 0),
                estado = estadoNoRevisado
            },
            estadoActual = estadoNoRevisado
        });
        eventosSismicos.Add(new EventoSismico
        {
            FechaHoraOcurrencia = new DateTime(2024, 6, 19, 22, 5, 0),
            FechaHoraFin = new DateTime(2024, 6, 19, 22, 20, 0),
            LatitudEpicentro = 32.9471,
            LongitudEpicentro = 60.6505,
            LatitudHipocentro = 32.9480,
            LongitudHipocentro = 60.6510,
            ValorMagnitud = 6.1,
            CambioEstado = new CambioEstado
            {
                fechaHoraInicio = new DateTime(2024, 6, 3, 22, 5, 0),
                fechaHoraFin = new DateTime(2024, 6, 3, 22, 20, 0),
                estado = estadoNoRevisado
            },
            estadoActual = estadoNoRevisado
        });
        eventosSismicos.Add(new EventoSismico
        {
            FechaHoraOcurrencia = new DateTime(2024, 6, 29, 3, 50, 0),
            FechaHoraFin = new DateTime(2024, 6, 29, 14, 5, 0),
            LatitudEpicentro = 24.7821,
            LongitudEpicentro = 65.4232,
            LatitudHipocentro = 24.7830,
            LongitudHipocentro = 65.4240,
            ValorMagnitud = 5.7,
            CambioEstado = new CambioEstado
            {
                fechaHoraInicio = new DateTime(2024, 6, 14, 3, 50, 0),
                fechaHoraFin = new DateTime(2024, 6, 4, 14, 5, 0),
                estado = estadoNoRevisado
            },
            estadoActual = estadoNoRevisado
        });

        /*eventosSismicos.Add(new EventoSismico
        {
            FechaHoraOcurrencia = new DateTime(2024, 6, 5, 11, 0, 0),
            FechaHoraFin = new DateTime(2024, 6, 5, 11, 15, 0),
            LatitudEpicentro = -38.4161,
            LongitudEpicentro = -63.6167,
            LatitudHipocentro = -38.4170,
            LongitudHipocentro = -63.6175,
            ValorMagnitud = 4.5,
            CambioEstado = new CambioEstado
            {
                fechaHoraInicio = new DateTime(2024, 6, 5, 11, 0, 0),
                fechaHoraFin = new DateTime(2024, 6, 5, 11, 15, 0),
                estado = estadoRevisado
            },
            estadoActual = estadoRevisado
        });
        */

        //simulamos la busqueda en bd y ordenamos por fecha de ocurrencia
        eventosSismicos = eventosSismicos
            .OrderBy(e => e.FechaHoraOcurrencia).ToList();
    }
}

