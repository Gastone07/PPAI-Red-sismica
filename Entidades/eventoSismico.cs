using PPAI_REDSISMICA.Entidades;
using System;
using System.Collections.Generic;

public class EventoSismico
{
    private DateTime FechaHoraFin { get; set; }
    private DateTime FechaHoraOcurrencia { get; set; }
    private double LatitudEpicentro { get; set; }
    private double LatitudHipocentro { get; set; }
    private double LongitudEpicentro { get; set; }
    private double LongitudHipocentro { get; set; }
    private double ValorMagnitud { get; set; }
    private CambioEstado CambioEstado { get; set; }
    private Estado estadoActual { get; set; }

    private OrigenDeGeneracion origenDeGeneracion { get; set; }
    private AlcanceSismo alcance { get; set; }
    private ClasificacionSismo clasificacion { get; set; }

    private List<SerieTemporal>? seriesTemporales = new List<SerieTemporal>();

    public EventoSismico(
        DateTime fechaHoraOcurrencia,
        DateTime fechaHoraFin,
        double latitudEpicentro,
        double longitudEpicentro,
        double latitudHipocentro,
        double longitudHipocentro,
        double valorMagnitud,
        CambioEstado cambioEstado,
        Estado estadoActual,
        List<SerieTemporal>? seriesTemporales,
        AlcanceSismo alcanceSismo,
        OrigenDeGeneracion origenDeGeneracionSismo,
        ClasificacionSismo clasificacionSismo)
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
        this.seriesTemporales = seriesTemporales;
        this.alcance = alcanceSismo;
        this.origenDeGeneracion = origenDeGeneracionSismo;
        this.clasificacion = clasificacionSismo;
    }

    public EventoSismico()
    {
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

    public CambioEstado crearCambioEstado(Estado estado, DateTime fechaHoraInicio)
    {
        //creo el nuevo cambio de estado del evento sismico
        CambioEstado = new CambioEstado(fechaHoraInicio, null, estado);

        this.CambioEstado = CambioEstado; // Actualiza el cambio de estado del evento sismico

        //TENGO QUE HACER SET ESTADO
        this.setEstado(estado); // Actualiza el estado actual del evento sismico

        return CambioEstado; // Retorna el cambio de estado creado

    }

    public void setEstado(Estado estado)     
    {
        this.estadoActual = estado; // Actualiza el estado actual del evento sismico
    }

    public (string origen, string alcance, string clasificacion) getDetallesEventoSismico()
    {
        return(
            this.alcance.getNombre(),
            this.origenDeGeneracion.getNombre(),
            this.clasificacion.getNombre());
    }

    public void buscarSeriesTemporal(List<SerieTemporal> seriesVisitadas, 
                                        List<MuestraSismica> muestrasVisitadas, 
                                        List<DetalleMuestraSismica> detallesVisitados, 
                                        List<(DetalleMuestraSismica, TipoDeDato)> tipoDatoPorDetalle)
    {
        if (seriesTemporales == null || seriesTemporales.Count == 0)
        {
            throw new InvalidOperationException("No hay series temporales asociadas al evento sismico.");
        }
        else 
        {
            foreach (var serieTemporal in seriesTemporales)
            {
                seriesVisitadas.Add(serieTemporal);
                serieTemporal.getDatos(muestrasVisitadas, detallesVisitados, tipoDatoPorDetalle);
                //serieTemporal.getDatos(); // Obtiene los datos de la serie temporal
            }
        }
        //throw new InvalidOperationException("No hay series temporales validas.");
    }

    public CambioEstado GetCambioEstado()
    {
        return CambioEstado;
    }
}

