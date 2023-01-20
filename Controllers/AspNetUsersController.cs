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
    public class AspNetUsersController : Controller
    {
        private readonly ODAMuniDBContext _context;

        public AspNetUsersController(ODAMuniDBContext context)
        {
            _context = context;
        }

        // GET: AspNetUsers
        public async Task<IActionResult> Index()
        {
            var oDAMuniDBContext = _context.AspNetUsers.Include(a => a.Perfil).Include(a => a.Usuario);
            return View(await oDAMuniDBContext.ToListAsync());
        }

        // GET: AspNetUsers/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.AspNetUsers == null)
            {
                return NotFound();
            }

            var aspNetUsers = await _context.AspNetUsers
                .Include(a => a.Perfil)
                .Include(a => a.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aspNetUsers == null)
            {
                return NotFound();
            }

            return View(aspNetUsers);
        }

        // GET: AspNetUsers/Create
        public IActionResult Create()
        {
            ViewData["PerfilId"] = new SelectList(_context.Perfil, "PerfilId", "PerfilId");
            ViewData["UsuarioId"] = new SelectList(_context.UsuarioReferencia, "UsuarioRefId", "UsuarioRefId");
            return View();
        }

        // POST: AspNetUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName,Nombre,Apellido,CUIL,PerfilId,UsuarioId")] AspNetUsers aspNetUsers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aspNetUsers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PerfilId"] = new SelectList(_context.Perfil, "PerfilId", "PerfilId", aspNetUsers.PerfilId);
            ViewData["UsuarioId"] = new SelectList(_context.UsuarioReferencia, "UsuarioRefId", "UsuarioRefId", aspNetUsers.UsuarioId);
            return View(aspNetUsers);
        }

        // GET: AspNetUsers/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.AspNetUsers == null)
            {
                return NotFound();
            }

            var aspNetUsers = await _context.AspNetUsers.FindAsync(id);
            if (aspNetUsers == null)
            {
                return NotFound();
            }
            ViewData["PerfilId"] = new SelectList(_context.Perfil, "PerfilId", "PerfilId", aspNetUsers.PerfilId);
            ViewData["UsuarioId"] = new SelectList(_context.UsuarioReferencia, "UsuarioRefId", "UsuarioRefId", aspNetUsers.UsuarioId);
            return View(aspNetUsers);
        }

        // POST: AspNetUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName,Nombre,Apellido,CUIL,PerfilId,UsuarioId")] AspNetUsers aspNetUsers)
        {
            if (id != aspNetUsers.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aspNetUsers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AspNetUsersExists(aspNetUsers.Id))
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
            ViewData["PerfilId"] = new SelectList(_context.Perfil, "PerfilId", "PerfilId", aspNetUsers.PerfilId);
            ViewData["UsuarioId"] = new SelectList(_context.UsuarioReferencia, "UsuarioRefId", "UsuarioRefId", aspNetUsers.UsuarioId);
            return View(aspNetUsers);
        }

        // GET: AspNetUsers/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.AspNetUsers == null)
            {
                return NotFound();
            }

            var aspNetUsers = await _context.AspNetUsers
                .Include(a => a.Perfil)
                .Include(a => a.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aspNetUsers == null)
            {
                return NotFound();
            }

            return View(aspNetUsers);
        }

        // POST: AspNetUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.AspNetUsers == null)
            {
                return Problem("Entity set 'ODAMuniDBContext.AspNetUsers'  is null.");
            }
            var aspNetUsers = await _context.AspNetUsers.FindAsync(id);
            if (aspNetUsers != null)
            {
                _context.AspNetUsers.Remove(aspNetUsers);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AspNetUsersExists(string id)
        {
          return (_context.AspNetUsers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
