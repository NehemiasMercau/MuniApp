using System;
using System.Collections.Generic;

namespace MuniApp.Negocio.entidades;

public partial class Pago
{
    public int PagoId { get; set; }

    public string? Referencia { get; set; }

    public string? PagoReferencia { get; set; }

    public DateTime? Fecha { get; set; }

    public string? Hora { get; set; }

    public int? PersonaEntidadDeutaDetalleId { get; set; }

    public int? PagoTipoId { get; set; }

    public int? EstadoPagoId { get; set; }

    public bool? Activo { get; set; }

    public int? PagoDetalleId { get; set; }

    public decimal? Monto { get; set; }

    public decimal? MontoNeto { get; set; }

    public int? CobroDetalleId { get; set; }

    public virtual CobroDetalle? CobroDetalle { get; set; }

    public virtual EstadoPago? EstadoPago { get; set; }

    public virtual PagoDetalle? PagoDetalle { get; set; }

    public virtual PagoTipo? PagoTipo { get; set; }

    public virtual PersonaEntidadDeudaDetalle? PersonaEntidadDeutaDetalle { get; set; }
}
