using System;
using System.Collections.Generic;

namespace MuniApp.Negocio.entidades;

public partial class Persona
{
    public int PersonaId { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public int? PersonaTipoId { get; set; }

    public string? CUIT { get; set; }

    public string? RazonSocial { get; set; }

    public long? Telefono { get; set; }

    public DateTime? FechaAlta { get; set; }

    public int? PersonaEstadoId { get; set; }

    public bool? ActualizoDeuda { get; set; }

    public DateTime? FechaUltimaActualizacion { get; set; }

    public string? Email { get; set; }

    public long? DNI { get; set; }

    public bool? Activo { get; set; }

    public virtual ICollection<Cobro> Cobro { get; } = new List<Cobro>();

    public virtual ICollection<Domicilio> Domicilio { get; } = new List<Domicilio>();

    public virtual ICollection<PagoDetalle> PagoDetalle { get; } = new List<PagoDetalle>();

    public virtual ICollection<PersonaEntidad> PersonaEntidad { get; } = new List<PersonaEntidad>();

    public virtual ICollection<PersonaEntidadDeudaDetalle> PersonaEntidadDeudaDetalle { get; } = new List<PersonaEntidadDeudaDetalle>();

    public virtual PersonaEstado? PersonaEstado { get; set; }

    public virtual PersonaTipo? PersonaTipo { get; set; }
}
