using System;
using System.Collections.Generic;

namespace MuniApp.Negocio.entidades;

public partial class ActualizacionEvent
{
    public int idAct { get; set; }

    public int? EventualidadIdNueva { get; set; }

    public int? EventualidadIdVieja { get; set; }

    public decimal? MontoNueva { get; set; }

    public decimal? MontoVieja { get; set; }

    public virtual ICollection<ActualizacionCobroDetalle> ActualizacionCobroDetalle { get; } = new List<ActualizacionCobroDetalle>();
}
