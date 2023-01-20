using System;
using System.Collections.Generic;

namespace MuniApp.Negocio.entidades;

public partial class ActualizacionCobroDetalle
{
    public int idActRelacion { get; set; }

    public int? idAct { get; set; }

    public int? CobroDetalleId { get; set; }

    public virtual CobroDetalle? CobroDetalle { get; set; }

    public virtual ActualizacionEvent? idActNavigation { get; set; }
}
