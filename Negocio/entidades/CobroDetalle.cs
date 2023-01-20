using System;
using System.Collections.Generic;

namespace MuniApp.Negocio.entidades;

public partial class CobroDetalle
{
    public int CobroDetalleId { get; set; }

    public int CobroId { get; set; }

    public int? PersonaEntidadDeudaDetalleId { get; set; }

    public int? EventualidadId { get; set; }

    public decimal Monto { get; set; }

    public bool? Activo { get; set; }

    public decimal? MontoUnitario { get; set; }

    public virtual ICollection<ActualizacionCobroDetalle> ActualizacionCobroDetalle { get; } = new List<ActualizacionCobroDetalle>();

    public virtual Cobro Cobro { get; set; } = null!;

    public virtual Eventualidad? Eventualidad { get; set; }

    public virtual ICollection<Pago> Pago { get; } = new List<Pago>();

    public virtual PersonaEntidadDeudaDetalle? PersonaEntidadDeudaDetalle { get; set; }
}
