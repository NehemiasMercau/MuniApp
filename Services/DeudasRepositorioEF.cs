using Microsoft.EntityFrameworkCore;
using MuniApp.Models;
using MuniApp.Negocio.entidades;

namespace MuniApp.Services;

public class DeudasRepositorioEF : IDeudas
{
    private readonly ODAMuniDBContext _context;
    public DeudasRepositorioEF(ODAMuniDBContext context)
    {
        _context = context;
    }

    public List<DeudasViewModels> getDeudasViewModels()
    {
        List<DeudasViewModels> listDeudasViewModels = new List<DeudasViewModels>();
        List<Deuda> listDeudasViewModelsAnio = _context.Deuda
        .Where(x => x.Activo == true)
        .Include(p => p.Anio)
        .Include(p => p.Rubro)
        .Include(p => p.PersonaTipo)
        .Include(p => p.PeriodoTipo)
        .Take(2).ToList();
        if (listDeudasViewModelsAnio.Count > 0)
        {
            listDeudasViewModels.AddRange(listDeudasViewModelsAnio
                .Select(x => new DeudasViewModels
                {
                    DeudaId = x.DeudaId,
                    Rubro = x.Rubro.Nombre,
                    Anio = x.Anio.Nombre,
                    Padron = (x.Padron != null) ? x.Padron : "",
                    PersonaTipo = x.PersonaTipo.Nombre,
                    PeriodoTipo = x.PeriodoTipo.Nombre,
                    Monto = (decimal)x.Monto,
                    Interes = (decimal)x.Interes,
                    DiaVencimiento = (x.DiaVencimientoReferencia != null) ? (int)x.DiaVencimientoReferencia : x.DiaVencimientoReferencia,
                    FechaVencimiento = (x.FechaVencimiento != null) ? x.FechaVencimiento.Value.ToString("dd/MM/yyyy") : "",
                    Observ = x.Observacion,
                    RubroId = (int)x.RubroId
                }));
        }

        return listDeudasViewModels;
    }
}