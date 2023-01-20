using System;
using System.Collections.Generic;

namespace MuniApp.Negocio.entidades;

public partial class PagoDetalle
{
    public int PagoDetalleId { get; set; }

    public long? collection_id { get; set; }

    public string? collection_status { get; set; }

    public string? external_reference { get; set; }

    public string? payment_type { get; set; }

    public long? merchant_order_id { get; set; }

    public string? preference_id { get; set; }

    public string? site_id { get; set; }

    public string? processing_mode { get; set; }

    public string? merchant_account_id { get; set; }

    public DateTime? Fecha { get; set; }

    public bool? Activo { get; set; }

    public decimal? total_paid_amount { get; set; }

    public decimal? net_received_amount { get; set; }

    public decimal? transaction_amount { get; set; }

    public string? SecuenciaId { get; set; }

    public int? PersonaId { get; set; }

    public virtual ICollection<Pago> Pago { get; } = new List<Pago>();

    public virtual Persona? Persona { get; set; }
}
