namespace MuniApp.Models;

public class DeudasViewModels
{
    public int DeudaId { get; set; }
    public string? Rubro { get; set; }
    public int RubroId { get; set; }
    public string? Anio { get; set; }
    public string? PersonaTipo { get; set; }
    public string? PeriodoTipo { get; set; }
    public decimal Monto { get; set; }
    public decimal Interes { get; set; }
    public Nullable<int> DiaVencimiento { get; set; }
    public string? FechaVencimiento { get; set; }

    public string? Padron { get; set; }
    public string? Observ { get; set; }
}