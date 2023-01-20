using System;
using System.Collections.Generic;

namespace MuniApp.Negocio.entidades;

public partial class Deuda
{
    public int DeudaId { get; set; }

    public int? RubroId { get; set; }

    public int? AnioId { get; set; }

    public int? PeriodoTipoId { get; set; }

    public int? PersonaTipoId { get; set; }

    public decimal? Monto { get; set; }

    public decimal? Interes { get; set; }

    public int? DiaVencimientoReferencia { get; set; }

    public DateTime? FechaVencimiento { get; set; }

    public string? Padron { get; set; }

    public int? UsuarioId { get; set; }

    public string? Observacion { get; set; }

    public bool? Activo { get; set; }

    public virtual Anio? Anio { get; set; }

    public virtual ICollection<DeudaDetalle> DeudaDetalle { get; } = new List<DeudaDetalle>();

    public virtual PeriodoTipo? PeriodoTipo { get; set; }

    public virtual PersonaTipo? PersonaTipo { get; set; }

    public virtual Rubro? Rubro { get; set; }
}
