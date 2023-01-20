using System;
using System.Collections.Generic;

namespace MuniApp.Negocio.entidades;

public partial class PeriodoTipo
{
    public int PeriodoTipoId { get; set; }

    public string? Nombre { get; set; }

    public int? Division { get; set; }

    public bool? Activo { get; set; }

    public virtual ICollection<Deuda> Deuda { get; } = new List<Deuda>();

    public virtual ICollection<Periodo> Periodo { get; } = new List<Periodo>();
}
