using System;
using System.Collections.Generic;

namespace MuniApp.Negocio.entidades;

public partial class PersonaEstado
{
    public int PersonaEstadoId { get; set; }

    public string? Nombre { get; set; }

    public bool? Activo { get; set; }

    public virtual ICollection<Persona> Persona { get; } = new List<Persona>();
}
