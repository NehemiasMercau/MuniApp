using System;
using System.Collections.Generic;

namespace MuniApp.Negocio.entidades;

public partial class PagoTipo
{
    public int PagoTipoId { get; set; }

    public string? Nombre { get; set; }

    public bool? Activo { get; set; }

    public virtual ICollection<Pago> Pago { get; } = new List<Pago>();
}
