using System;
using System.Collections.Generic;

namespace MuniApp.Negocio.entidades;

public partial class Perfil
{
    public int PerfilId { get; set; }

    public string? Nombre { get; set; }

    public bool? Activo { get; set; }

    public virtual ICollection<AspNetUsers> AspNetUsers { get; } = new List<AspNetUsers>();
}
