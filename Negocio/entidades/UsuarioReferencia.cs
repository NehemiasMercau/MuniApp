using System;
using System.Collections.Generic;

namespace MuniApp.Negocio.entidades;

public partial class UsuarioReferencia
{
    public int UsuarioRefId { get; set; }

    public string AspNetUsersId { get; set; } = null!;

    public bool? Activo { get; set; }

    public virtual ICollection<Arqueo> ArqueoUsuarioFinalizo { get; } = new List<Arqueo>();

    public virtual ICollection<Arqueo> ArqueoUsuarioIncio { get; } = new List<Arqueo>();

    public virtual ICollection<AspNetUsers> AspNetUsers { get; } = new List<AspNetUsers>();

    public virtual ICollection<Cobro> Cobro { get; } = new List<Cobro>();

    public virtual ICollection<PersonaEntidadDeudaDetalle> PersonaEntidadDeudaDetalle { get; } = new List<PersonaEntidadDeudaDetalle>();
}
