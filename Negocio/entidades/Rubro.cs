using System;
using System.Collections.Generic;

namespace MuniApp.Negocio.entidades;

public partial class Rubro
{
    public int RubroId { get; set; }

    public string? Nombre { get; set; }

    public bool? Activo { get; set; }

    public virtual ICollection<Deuda> Deuda { get; } = new List<Deuda>();

    public virtual ICollection<Entidad> Entidad { get; } = new List<Entidad>();
}
