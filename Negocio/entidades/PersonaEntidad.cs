using System;
using System.Collections.Generic;

namespace MuniApp.Negocio.entidades;

public partial class PersonaEntidad
{
    public int PersonaEntidadId { get; set; }

    public int? PersonaId { get; set; }

    public int? EntidadId { get; set; }

    public bool? Activo { get; set; }

    public virtual ICollection<Domicilio> Domicilio { get; } = new List<Domicilio>();

    public virtual Entidad? Entidad { get; set; }

    public virtual Persona? Persona { get; set; }

    public virtual ICollection<PersonaEntidadDeudaDetalle> PersonaEntidadDeudaDetalle { get; } = new List<PersonaEntidadDeudaDetalle>();
}
