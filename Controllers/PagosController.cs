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
    public class PagosController : Controller
    {
        private readonly ODAMuniDBContext _context;

        public PagosController(ODAMuniDBContext context)
        {
            _context = context;
        }

        // GET: Pagos
        public async Task<IActionResult> Index()
        {
            var oDAMuniDBContext = _context.Pago.Include(p => p.CobroDetalle).Include(p => p.EstadoPago).Include(p => p.PagoDetalle).Include(p => p.PagoTipo).Include(p => p.PersonaEntidadDeutaDetalle);
            return View(await oDAMuniDBContext.ToListAsync());
        }

        // GET: Pagos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pago == null)
            {
                return NotFound();
            }

            var pago = await _context.Pago
                .Include(p => p.CobroDetalle)
                .Include(p => p.EstadoPago)
                .Include(p => p.PagoDetalle)
                .Include(p => p.PagoTipo)
                .Include(p => p.PersonaEntidadDeutaDetalle)
                .FirstOrDefaultAsync(m => m.PagoId == id);
            if (pago == null)
            {
                return NotFound();
            }

            return View(pago);
        }

        // GET: Pagos/Create
        public IActionResult Create()
        {
            ViewData["CobroDetalleId"] = new SelectList(_context.CobroDetalle, "CobroDetalleId", "CobroDetalleId");
            ViewData["EstadoPagoId"] = new SelectList(_context.EstadoPago, "EstadoPagoId", "EstadoPagoId");
            ViewData["PagoDetalleId"] = new SelectList(_context.PagoDetalle, "PagoDetalleId", "PagoDetalleId");
            ViewData["PagoTipoId"] = new SelectList(_context.PagoTipo, "PagoTipoId", "PagoTipoId");
            ViewData["PersonaEntidadDeutaDetalleId"] = new SelectList(_context.PersonaEntidadDeudaDetalle, "PersonaEntidadDeudaDetalleId", "PersonaEntidadDeudaDetalleId");
            return View();
        }

        // POST: Pagos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PagoId,Referencia,PagoReferencia,Fecha,Hora,PersonaEntidadDeutaDetalleId,PagoTipoId,EstadoPagoId,Activo,PagoDetalleId,Monto,MontoNeto,CobroDetalleId")] Pago pago)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pago);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CobroDetalleId"] = new SelectList(_context.CobroDetalle, "CobroDetalleId", "CobroDetalleId", pago.CobroDetalleId);
            ViewData["EstadoPagoId"] = new SelectList(_context.EstadoPago, "EstadoPagoId", "EstadoPagoId", pago.EstadoPagoId);
            ViewData["PagoDetalleId"] = new SelectList(_context.PagoDetalle, "PagoDetalleId", "PagoDetalleId", pago.PagoDetalleId);
            ViewData["PagoTipoId"] = new SelectList(_context.PagoTipo, "PagoTipoId", "PagoTipoId", pago.PagoTipoId);
            ViewData["PersonaEntidadDeutaDetalleId"] = new SelectList(_context.PersonaEntidadDeudaDetalle, "PersonaEntidadDeudaDetalleId", "PersonaEntidadDeudaDetalleId", pago.PersonaEntidadDeutaDetalleId);
            return View(pago);
        }

        // GET: Pagos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pago == null)
            {
                return NotFound();
            }

            var pago = await _context.Pago.FindAsync(id);
            if (pago == null)
            {
                return NotFound();
            }
            ViewData["CobroDetalleId"] = new SelectList(_context.CobroDetalle, "CobroDetalleId", "CobroDetalleId", pago.CobroDetalleId);
            ViewData["EstadoPagoId"] = new SelectList(_context.EstadoPago, "EstadoPagoId", "EstadoPagoId", pago.EstadoPagoId);
            ViewData["PagoDetalleId"] = new SelectList(_context.PagoDetalle, "PagoDetalleId", "PagoDetalleId", pago.PagoDetalleId);
            ViewData["PagoTipoId"] = new SelectList(_context.PagoTipo, "PagoTipoId", "PagoTipoId", pago.PagoTipoId);
            ViewData["PersonaEntidadDeutaDetalleId"] = new SelectList(_context.PersonaEntidadDeudaDetalle, "PersonaEntidadDeudaDetalleId", "PersonaEntidadDeudaDetalleId", pago.PersonaEntidadDeutaDetalleId);
            return View(pago);
        }

        // POST: Pagos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PagoId,Referencia,PagoReferencia,Fecha,Hora,PersonaEntidadDeutaDetalleId,PagoTipoId,EstadoPagoId,Activo,PagoDetalleId,Monto,MontoNeto,CobroDetalleId")] Pago pago)
        {
            if (id != pago.PagoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pago);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PagoExists(pago.PagoId))
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
            ViewData["CobroDetalleId"] = new SelectList(_context.CobroDetalle, "CobroDetalleId", "CobroDetalleId", pago.CobroDetalleId);
            ViewData["EstadoPagoId"] = new SelectList(_context.EstadoPago, "EstadoPagoId", "EstadoPagoId", pago.EstadoPagoId);
            ViewData["PagoDetalleId"] = new SelectList(_context.PagoDetalle, "PagoDetalleId", "PagoDetalleId", pago.PagoDetalleId);
            ViewData["PagoTipoId"] = new SelectList(_context.PagoTipo, "PagoTipoId", "PagoTipoId", pago.PagoTipoId);
            ViewData["PersonaEntidadDeutaDetalleId"] = new SelectList(_context.PersonaEntidadDeudaDetalle, "PersonaEntidadDeudaDetalleId", "PersonaEntidadDeudaDetalleId", pago.PersonaEntidadDeutaDetalleId);
            return View(pago);
        }

        // GET: Pagos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pago == null)
            {
                return NotFound();
            }

            var pago = await _context.Pago
                .Include(p => p.CobroDetalle)
                .Include(p => p.EstadoPago)
                .Include(p => p.PagoDetalle)
                .Include(p => p.PagoTipo)
                .Include(p => p.PersonaEntidadDeutaDetalle)
                .FirstOrDefaultAsync(m => m.PagoId == id);
            if (pago == null)
            {
                return NotFound();
            }

            return View(pago);
        }

        // POST: Pagos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pago == null)
            {
                return Problem("Entity set 'ODAMuniDBContext.Pago'  is null.");
            }
            var pago = await _context.Pago.FindAsync(id);
            if (pago != null)
            {
                _context.Pago.Remove(pago);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PagoExists(int id)
        {
          return (_context.Pago?.Any(e => e.PagoId == id)).GetValueOrDefault();
        }
    }
}
