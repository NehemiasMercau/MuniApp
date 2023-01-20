using System;
using System.Collections.Generic;

namespace MuniApp.Negocio.entidades;

public partial class Anio
{
    public int AnioId { get; set; }

    public string? Nombre { get; set; }

    public bool? Activo { get; set; }

    public virtual ICollection<Deuda> Deuda { get; } = new List<Deuda>();
}
