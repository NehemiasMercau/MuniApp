using System;
using System.Collections.Generic;

namespace MuniApp.Negocio.entidades;

public partial class Domicilio
{
    public int DomicilioId { get; set; }

    public int? PersonaEntidadId { get; set; }

    public int? PersonaId { get; set; }

    public string? Barrio { get; set; }

    public string? Calle { get; set; }

    public int? Altura { get; set; }

    public int? Piso { get; set; }

    public int? Dpto { get; set; }

    public bool? Activo { get; set; }

    public virtual Persona? Persona { get; set; }

    public virtual PersonaEntidad? PersonaEntidad { get; set; }
}
