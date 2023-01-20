using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MuniApp.Negocio.entidades;

namespace MuniApp.Controllers
{
    public class PeriodosController : Controller
    {
        private readonly ODAMuniDBContext _context;

        public PeriodosController(ODAMuniDBContext context)
        {
            _context = context;
        }

        // GET: Periodos
        public async Task<IActionResult> Index()
        {
            var oDAMuniDBContext = _context.Periodo.Include(p => p.PeriodoTipo);
            return View(await oDAMuniDBContext.ToListAsync());
        }

        // GET: Periodos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Periodo == null)
            {
                return NotFound();
            }

            var periodo = await _context.Periodo
                .Include(p => p.PeriodoTipo)
                .FirstOrDefaultAsync(m => m.PeriodoId == id);
            if (periodo == null)
            {
                return NotFound();
            }

            return View(periodo);
        }

        // GET: Periodos/Create
        public IActionResult Create()
        {
            ViewData["PeriodoTipoId"] = new SelectList(_context.PeriodoTipo, "PeriodoTipoId", "PeriodoTipoId");
            return View();
        }

        // POST: Periodos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PeriodoId,Nombre,PeriodoTipoId,Mes,Activo")] Periodo periodo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(periodo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PeriodoTipoId"] = new SelectList(_context.PeriodoTipo, "PeriodoTipoId", "PeriodoTipoId", periodo.PeriodoTipoId);
            return View(periodo);
        }

        // GET: Periodos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Periodo == null)
            {
                return NotFound();
            }

            var periodo = await _context.Periodo.FindAsync(id);
            if (periodo == null)
            {
                return NotFound();
            }
            ViewData["PeriodoTipoId"] = new SelectList(_context.PeriodoTipo, "PeriodoTipoId", "PeriodoTipoId", periodo.PeriodoTipoId);
            return View(periodo);
        }

        // POST: Periodos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PeriodoId,Nombre,PeriodoTipoId,Mes,Activo")] Periodo periodo)
        {
            if (id != periodo.PeriodoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(periodo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PeriodoExists(periodo.PeriodoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["PeriodoTipoId"] = new SelectList(_context.PeriodoTipo, "PeriodoTipoId", "PeriodoTipoId", periodo.PeriodoTipoId);
            return View(periodo);
        }

        // GET: Periodos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Periodo == null)
            {
                return NotFound();
            }

            var periodo = await _context.Periodo
                .Include(p => p.PeriodoTipo)
                .FirstOrDefaultAsync(m => m.PeriodoId == id);
            if (periodo == null)
            {
                return NotFound();
            }

            return View(periodo);
        }

        // POST: Periodos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Periodo == null)
            {
                return Problem("Entity set 'ODAMuniDBContext.Periodo'  is null.");
            }
            var periodo = await _context.Periodo.FindAsync(id);
            if (periodo != null)
            {
                _context.Periodo.Remove(periodo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PeriodoExists(int id)
        {
          return (_context.Periodo?.Any(e => e.PeriodoId == id)).GetValueOrDefault();
        }
    }
}
