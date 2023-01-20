using System;
using System.Collections.Generic;

namespace MuniApp.Negocio.entidades;

public partial class PersonaTipo
{
    public int PersonaTipoId { get; set; }

    public string? Nombre { get; set; }

    public bool? Activo { get; set; }

    public virtual ICollection<Deuda> Deuda { get; } = new List<Deuda>();

    public virtual ICollection<Persona> Persona { get; } = new List<Persona>();
}
