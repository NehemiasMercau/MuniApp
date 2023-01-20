using System;
using System.Collections.Generic;

namespace MuniApp.Negocio.entidades;

public partial class DeudasMigracion
{
    public int? ID { get; set; }

    public int? Deuda { get; set; }

    public double? Rubro { get; set; }

    public double? Anio { get; set; }

    public string? Padron { get; set; }

    public double? PeriodoTipo { get; set; }

    public string? Periodos { get; set; }

    public double? PersonaTipo { get; set; }

    public string? CUIT { get; set; }

    public double? Monto { get; set; }

    public double? Interes { get; set; }

    public double? Dia { get; set; }

    public bool? Migrado { get; set; }
}
