using System;
using System.Collections.Generic;

namespace MuniApp.Negocio.entidades;

public partial class Auditoria
{
    public int AuditoriaId { get; set; }

    public bool? Activo { get; set; }

    public string? Nombre { get; set; }

    public DateTime? Fecha { get; set; }
}
