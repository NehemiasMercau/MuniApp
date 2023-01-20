using System;
using System.Collections.Generic;

namespace MuniApp.Negocio.entidades;

public partial class Periodo
{
    public int PeriodoId { get; set; }

    public string? Nombre { get; set; }

    public int? PeriodoTipoId { get; set; }

    public int? Mes { get; set; }

    public bool? Activo { get; set; }

    public virtual ICollection<DeudaDetalle> DeudaDetalle { get; } = new List<DeudaDetalle>();

    public virtual PeriodoTipo? PeriodoTipo { get; set; }
}
