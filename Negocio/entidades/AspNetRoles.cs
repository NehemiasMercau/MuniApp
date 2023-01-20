using System;
using System.Collections.Generic;

namespace MuniApp.Negocio.entidades;

public partial class AspNetRoles
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public virtual ICollection<AspNetUserRoles> AspNetUserRoles { get; } = new List<AspNetUserRoles>();
}
