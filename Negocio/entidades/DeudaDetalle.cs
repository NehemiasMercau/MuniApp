using System;
using System.Collections.Generic;

namespace MuniApp.Negocio.entidades;

public partial class DeudaDetalle
{
    public int DeudaDetalleId { get; set; }

    public int? DeudaId { get; set; }

    public decimal? Importe { get; set; }

    public decimal? Recargo { get; set; }

    public DateTime? FechaVencimiento { get; set; }

    public int? PeriodoId { get; set; }

    public bool? Activo { get; set; }

    public virtual Deuda? Deuda { get; set; }

    public virtual Periodo? Periodo { get; set; }

    public virtual ICollection<PersonaEntidadDeudaDetalle> PersonaEntidadDeudaDetalle { get; } = new List<PersonaEntidadDeudaDetalle>();
}
