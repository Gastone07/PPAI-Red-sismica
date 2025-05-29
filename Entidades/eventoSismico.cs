using PPAI_REDSISMICA.Entidades;
using System;
using System.Collections.Generic;

public class EventoSismico
{
    public DateTime FechaHoraFin { get; set; }
    public DateTime FechaHoraOcurrencia { get; set; }
    public double LatitudEpicentro { get; set; }
    public double LatitudHipocentro { get; set; }
    public double LongitudEpicentro { get; set; }
    public double LongitudHipocentro { get; set; }
    public double ValorMagnitud { get; set; }
    public CambioEstado CambioEstado { get; set; }
    public Estado estadoActual { get; set; }

    public EventoSismico(
        DateTime fechaHoraOcurrencia,
        DateTime fechaHoraFin,
        double latitudEpicentro,
        double longitudEpicentro,
        double latitudHipocentro,
        double longitudHipocentro,
        double valorMagnitud,
        CambioEstado cambioEstado,
        Estado estadoActual)
    {
        FechaHoraOcurrencia = fechaHoraOcurrencia;
        FechaHoraFin = fechaHoraFin;
        LatitudEpicentro = latitudEpicentro;
        LongitudEpicentro = longitudEpicentro;
        LatitudHipocentro = latitudHipocentro;
        LongitudHipocentro = longitudHipocentro;
        ValorMagnitud = valorMagnitud;
        CambioEstado = cambioEstado;
        this.estadoActual = estadoActual;
    }

    public static void esPendienteDeRevision(List<EventoSismico> eventosSismicos)
    {
        crearEventosInicio(eventosSismicos);
    }

    private static void crearEventosInicio(List<EventoSismico> eventosSismicos)
    {
        eventosSismicos.Clear();

        var estadoNoRevisado = new Estado("evento", "NoRevisado");
        var estadoRevisado = new Estado("evento", "Revisado");

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
                new DateTime(2024, 6, 12, 14, 45, 0),
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
                new DateTime(2024, 6, 23, 9, 30, 0),
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
                new DateTime(2024, 6, 19, 22, 20, 0),
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
                new DateTime(2024, 6, 29, 14, 5, 0),
                estadoNoRevisado
            ),
            estadoNoRevisado
        ));

        // Simulamos la búsqueda en BD y ordenamos por fecha de ocurrencia  
        eventosSismicos = eventosSismicos
            .OrderBy(e => e.FechaHoraOcurrencia).ToList();
    }
}

