using System;
using System.Collections.Generic;

namespace MuniApp.Negocio.entidades;

public partial class Cobro
{
    public int CobroId { get; set; }

    public int ArqueoId { get; set; }

    public decimal Total { get; set; }

    public DateTime Fecha { get; set; }

    public int PersonaId { get; set; }

    public decimal? Descuento { get; set; }

    public decimal? Recargo { get; set; }

    public decimal? Final { get; set; }

    public int? UsuarioId { get; set; }

    public bool? Activo { get; set; }

    public string? SecuenciaId { get; set; }

    public virtual Arqueo Arqueo { get; set; } = null!;

    public virtual ICollection<CobroDetalle> CobroDetalle { get; } = new List<CobroDetalle>();

    public virtual ICollection<CobroRelacion> CobroRelacion { get; } = new List<CobroRelacion>();

    public virtual Persona Persona { get; set; } = null!;

    public virtual UsuarioReferencia? Usuario { get; set; }
}
