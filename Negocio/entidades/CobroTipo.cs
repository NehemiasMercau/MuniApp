using System;
using System.Collections.Generic;

namespace MuniApp.Negocio.entidades;

public partial class CobroTipo
{
    public int CobroTipoId { get; set; }

    public string? Nombre { get; set; }

    public bool? Activo { get; set; }

    public virtual ICollection<CobroRelacion> CobroRelacion { get; } = new List<CobroRelacion>();
}
