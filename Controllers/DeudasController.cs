using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MuniApp.Models;
using MuniApp.Negocio.entidades;
using MuniApp.Services;

namespace MuniApp.Controllers
{
    public class DeudasController : Controller
    {
        private readonly IDeudas _repositorio;

        public DeudasController(IDeudas repositorio)
        {
            _repositorio = repositorio;
        }

        // GET: Deudas
        public IActionResult Index()
        {
            var listDeudasViewModels = _repositorio.getDeudasViewModels();
            return View(listDeudasViewModels);
        }

        // GET: Deudas/Details/5
        // public async Task<IActionResult> Details(int? id)
        // {
        //     if (id == null || _context.Deuda == null)
        //     {
        //         return NotFound();
        //     }

        //     var deuda = await _context.Deuda
        //         .Include(d => d.Anio)
        //         .Include(d => d.PeriodoTipo)
        //         .Include(d => d.PersonaTipo)
        //         .Include(d => d.Rubro)
        //         .FirstOrDefaultAsync(m => m.DeudaId == id);
        //     if (deuda == null)
        //     {
        //         return NotFound();
        //     }

        //     return View(deuda);
        // }

        // // GET: Deudas/Create
        // public IActionResult Create()
        // {
        //     ViewData["AnioId"] = new SelectList(_context.Anio, "AnioId", "AnioId");
        //     ViewData["PeriodoTipoId"] = new SelectList(_context.PeriodoTipo, "PeriodoTipoId", "PeriodoTipoId");
        //     ViewData["PersonaTipoId"] = new SelectList(_context.PersonaTipo, "PersonaTipoId", "PersonaTipoId");
        //     ViewData["RubroId"] = new SelectList(_context.Rubro, "RubroId", "RubroId");
        //     return View();
        // }

        // // POST: Deudas/Create
        // // To protect from overposting attacks, enable the specific properties you want to bind to.
        // // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Create([Bind("DeudaId,RubroId,AnioId,PeriodoTipoId,PersonaTipoId,Monto,Interes,DiaVencimientoReferencia,FechaVencimiento,Padron,UsuarioId,Observacion,Activo")] Deuda deuda)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         _context.Add(deuda);
        //         await _context.SaveChangesAsync();
        //         return RedirectToAction(nameof(Index));
        //     }
        //     ViewData["AnioId"] = new SelectList(_context.Anio, "AnioId", "AnioId", deuda.AnioId);
        //     ViewData["PeriodoTipoId"] = new SelectList(_context.PeriodoTipo, "PeriodoTipoId", "PeriodoTipoId", deuda.PeriodoTipoId);
        //     ViewData["PersonaTipoId"] = new SelectList(_context.PersonaTipo, "PersonaTipoId", "PersonaTipoId", deuda.PersonaTipoId);
        //     ViewData["RubroId"] = new SelectList(_context.Rubro, "RubroId", "RubroId", deuda.RubroId);
        //     return View(deuda);
        // }

        // // GET: Deudas/Edit/5
        // public async Task<IActionResult> Edit(int? id)
        // {
        //     if (id == null || _context.Deuda == null)
        //     {
        //         return NotFound();
        //     }

        //     var deuda = await _context.Deuda.FindAsync(id);
        //     if (deuda == null)
        //     {
        //         return NotFound();
        //     }
        //     ViewData["AnioId"] = new SelectList(_context.Anio, "AnioId", "AnioId", deuda.AnioId);
        //     ViewData["PeriodoTipoId"] = new SelectList(_context.PeriodoTipo, "PeriodoTipoId", "PeriodoTipoId", deuda.PeriodoTipoId);
        //     ViewData["PersonaTipoId"] = new SelectList(_context.PersonaTipo, "PersonaTipoId", "PersonaTipoId", deuda.PersonaTipoId);
        //     ViewData["RubroId"] = new SelectList(_context.Rubro, "RubroId", "RubroId", deuda.RubroId);
        //     return View(deuda);
        // }

        // // POST: Deudas/Edit/5
        // // To protect from overposting attacks, enable the specific properties you want to bind to.
        // // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Edit(int id, [Bind("DeudaId,RubroId,AnioId,PeriodoTipoId,PersonaTipoId,Monto,Interes,DiaVencimientoReferencia,FechaVencimiento,Padron,UsuarioId,Observacion,Activo")] Deuda deuda)
        // {
        //     if (id != deuda.DeudaId)
        //     {
        //         return NotFound();
        //     }

        //     if (ModelState.IsValid)
        //     {
        //         try
        //         {
        //             _context.Update(deuda);
        //             await _context.SaveChangesAsync();
        //         }
        //         catch (DbUpdateConcurrencyException)
        //         {
        //             if (!DeudaExists(deuda.DeudaId))
        //             {
        //                 return NotFound();
        //             }
        //             else
        //             {
        //                 throw;
        //             }
        //         }
        //         return RedirectToAction(nameof(Index));
        //     }
        //     ViewData["AnioId"] = new SelectList(_context.Anio, "AnioId", "AnioId", deuda.AnioId);
        //     ViewData["PeriodoTipoId"] = new SelectList(_context.PeriodoTipo, "PeriodoTipoId", "PeriodoTipoId", deuda.PeriodoTipoId);
        //     ViewData["PersonaTipoId"] = new SelectList(_context.PersonaTipo, "PersonaTipoId", "PersonaTipoId", deuda.PersonaTipoId);
        //     ViewData["RubroId"] = new SelectList(_context.Rubro, "RubroId", "RubroId", deuda.RubroId);
        //     return View(deuda);
        // }

        // // GET: Deudas/Delete/5
        // public async Task<IActionResult> Delete(int? id)
        // {
        //     if (id == null || _context.Deuda == null)
        //     {
        //         return NotFound();
        //     }

        //     var deuda = await _context.Deuda
        //         .Include(d => d.Anio)
        //         .Include(d => d.PeriodoTipo)
        //         .Include(d => d.PersonaTipo)
        //         .Include(d => d.Rubro)
        //         .FirstOrDefaultAsync(m => m.DeudaId == id);
        //     if (deuda == null)
        //     {
        //         return NotFound();
        //     }

        //     return View(deuda);
        // }

        // // POST: Deudas/Delete/5
        // [HttpPost, ActionName("Delete")]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> DeleteConfirmed(int id)
        // {
        //     if (_context.Deuda == null)
        //     {
        //         return Problem("Entity set 'ODAMuniDBContext.Deuda'  is null.");
        //     }
        //     var deuda = await _context.Deuda.FindAsync(id);
        //     if (deuda != null)
        //     {
        //         _context.Deuda.Remove(deuda);
        //     }

        //     await _context.SaveChangesAsync();
        //     return RedirectToAction(nameof(Index));
        // }

        // private bool DeudaExists(int id)
        // {
        //     return (_context.Deuda?.Any(e => e.DeudaId == id)).GetValueOrDefault();
        // }
    }
}
