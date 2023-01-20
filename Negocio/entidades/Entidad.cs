using System;
using System.Collections.Generic;

namespace MuniApp.Negocio.entidades;

public partial class Entidad
{
    public int EntidadId { get; set; }

    public string? Nombre { get; set; }

    public int? RubroId { get; set; }

    public bool? Activo { get; set; }

    public virtual ICollection<PersonaEntidad> PersonaEntidad { get; } = new List<PersonaEntidad>();

    public virtual Rubro? Rubro { get; set; }
}
