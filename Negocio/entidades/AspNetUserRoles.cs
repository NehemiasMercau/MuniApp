using System;
using System.Collections.Generic;

namespace MuniApp.Negocio.entidades;

public partial class AspNetUserRoles
{
    public string UserId { get; set; } = null!;

    public string RoleId { get; set; } = null!;

    public virtual AspNetRoles Role { get; set; } = null!;
}
