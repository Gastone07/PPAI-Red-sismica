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

    private OrigenDeGeneracion origenDeGeneracion;

    private AlcanceSismo alcance;

    private ClasificacionSismo clasificacion;

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


    public static CambioEstado buscarCambioEstadoAbierto(EventoSismico evento, List<CambioEstado> cambioEstadoEvento)
    {
       return CambioEstado.sosActual(evento, cambioEstadoEvento);// busco el cambio de estado abierto del evento sismico
    }

    public void crearCambioEstado(Estado estado, DateTime fechaHoraInicio)
    {
        //creo el nuevo cambio de estado del evento sismico
        CambioEstado = new CambioEstado(fechaHoraInicio, null, estado);

        this.CambioEstado = CambioEstado; // Actualiza el cambio de estado del evento sismico

        //TENGO QUE HACER SET ESTADO
        this.setEstado(estado); // Actualiza el estado actual del evento sismico

    }

    public void setEstado(Estado estado)     
    {
        this.estadoActual = estado; // Actualiza el estado actual del evento sismico
    }

    public void getDetallesEventoSismico()
    {
        //buscar alcance origen y clasificacion del evento sismico
        this.origenDeGeneracion.getNombre();
        this.alcance.getNombre();
        this.clasificacion.getNombre();
    }
}

