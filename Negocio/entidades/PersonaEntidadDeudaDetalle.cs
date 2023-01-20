using System;
using System.Collections.Generic;

namespace MuniApp.Negocio.entidades;

public partial class PersonaEntidadDeudaDetalle
{
    public int PersonaEntidadDeudaDetalleId { get; set; }

    public int? PersonaEntidadId { get; set; }

    public int? PersonaId { get; set; }

    public int? DeudaDetalleId { get; set; }

    public bool Pagado { get; set; }

    public DateTime? FechaPago { get; set; }

    public bool? Mora { get; set; }

    public int? MoraDias { get; set; }

    public decimal? Importe { get; set; }

    public decimal? Recargo { get; set; }

    public bool? PrePago { get; set; }

    public bool? Anulado { get; set; }

    public bool? Activo { get; set; }

    public int? UsuarioIdAnulo { get; set; }

    public virtual ICollection<CobroDetalle> CobroDetalle { get; } = new List<CobroDetalle>();

    public virtual DeudaDetalle? DeudaDetalle { get; set; }

    public virtual ICollection<Pago> Pago { get; } = new List<Pago>();

    public virtual Persona? Persona { get; set; }

    public virtual PersonaEntidad? PersonaEntidad { get; set; }

    public virtual UsuarioReferencia? UsuarioIdAnuloNavigation { get; set; }
}
