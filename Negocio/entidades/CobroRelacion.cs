using System;
using System.Collections.Generic;

namespace MuniApp.Negocio.entidades;

public partial class CobroRelacion
{
    public int CobroRelacionId { get; set; }

    public int CobroId { get; set; }

    public int CobroTipoId { get; set; }

    public decimal MontoCobrado { get; set; }

    public bool? Activo { get; set; }

    public virtual Cobro Cobro { get; set; } = null!;

    public virtual CobroTipo CobroTipo { get; set; } = null!;
}
