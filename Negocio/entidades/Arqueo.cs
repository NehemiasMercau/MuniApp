using System;
using System.Collections.Generic;

namespace MuniApp.Negocio.entidades;

public partial class Arqueo
{
    public int ArqueoId { get; set; }

    public DateTime FechaInicio { get; set; }

    public string HoraInicio { get; set; } = null!;

    public string? HoraFin { get; set; }

    public DateTime? FechaFin { get; set; }

    public decimal? Total { get; set; }

    public decimal? Faltante { get; set; }

    public decimal? Sobrante { get; set; }

    public string? Observaciones { get; set; }

    public bool Abierto { get; set; }

    public decimal? Iniciado { get; set; }

    public decimal? Finalizado { get; set; }

    public decimal? TotalEfectivo { get; set; }

    public int? UsuarioIncioId { get; set; }

    public int? UsuarioFinalizoId { get; set; }

    public bool? Activo { get; set; }

    public virtual ICollection<Cobro> Cobro { get; } = new List<Cobro>();

    public virtual UsuarioReferencia? UsuarioFinalizo { get; set; }

    public virtual UsuarioReferencia? UsuarioIncio { get; set; }
}
