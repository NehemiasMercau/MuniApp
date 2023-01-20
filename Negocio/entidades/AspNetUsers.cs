using System;
using System.Collections.Generic;

namespace MuniApp.Negocio.entidades;

public partial class AspNetUsers
{
    public string Id { get; set; } = null!;

    public string? Email { get; set; }

    public bool EmailConfirmed { get; set; }

    public string? PasswordHash { get; set; }

    public string? SecurityStamp { get; set; }

    public string? PhoneNumber { get; set; }

    public bool PhoneNumberConfirmed { get; set; }

    public bool TwoFactorEnabled { get; set; }

    public DateTime? LockoutEndDateUtc { get; set; }

    public bool LockoutEnabled { get; set; }

    public int AccessFailedCount { get; set; }

    public string UserName { get; set; } = null!;

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? CUIL { get; set; }

    public int? PerfilId { get; set; }

    public int UsuarioId { get; set; }

    public virtual ICollection<AspNetUserClaims> AspNetUserClaims { get; } = new List<AspNetUserClaims>();

    public virtual ICollection<AspNetUserLogins> AspNetUserLogins { get; } = new List<AspNetUserLogins>();

    public virtual Perfil? Perfil { get; set; }

    public virtual UsuarioReferencia Usuario { get; set; } = null!;
}
