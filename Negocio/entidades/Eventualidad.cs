using System;
using System.Collections.Generic;

namespace MuniApp.Negocio.entidades;

public partial class Eventualidad
{
    public int EventualidadId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripción { get; set; }

    public DateTime Fecha { get; set; }

    public decimal? Monto { get; set; }

    public bool? Activo { get; set; }

    public virtual ICollection<CobroDetalle> CobroDetalle { get; } = new List<CobroDetalle>();
}
