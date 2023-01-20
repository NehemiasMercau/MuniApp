using System;
using System.Collections.Generic;

namespace MuniApp.Negocio.entidades;

public partial class EventVieja
{
    public int idE { get; set; }

    public int? idEventVieja { get; set; }

    public string? Nombre { get; set; }

    public decimal? Monto { get; set; }
}
