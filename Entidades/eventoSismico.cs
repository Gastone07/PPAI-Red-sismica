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

    public static List<EventoSismico> esPendienteDeRevision(List<EventoSismico> eventosSismicos)
    {
        var eventosPendientes = new List<EventoSismico>();
        foreach (var evento in eventosSismicos)
        {
            if (evento.estadoActual.nombreEstado == "NoRevisado")
            {
                eventosPendientes.Add(evento);
            }
        }
        return eventosPendientes;
    }

   
}

