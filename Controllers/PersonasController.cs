using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using MuniApp.Models;
using MuniApp.Negocio.entidades;
using MuniApp.Negocio.enumeradores;
using MuniApp.Negocio.gestores;
using ODAMuniApi.Models;

namespace MuniApp.Controllers
{
    public class PersonasController : Controller
    {
        private readonly ODAMuniDBContext _context;

        public PersonasController(ODAMuniDBContext context)
        {
            _context = context;
        }

        // GET: Personas
        public async Task<IActionResult> Index()
        {
            ViewData["PersonaId"] = new SelectList(_context.Persona, "PersonaId", "RazonSocial");
            PersonaViewModel pvm = new PersonaViewModel();
            //pvm.listPersona = _context.Persona.Where(x => x.Activo == true).Take(50).ToList();        
            // var oDAMuniDBContext = _context.Persona.Include(p => p.PersonaEstado).Include(p => p.PersonaTipo);
            // return View(await oDAMuniDBContext.ToListAsync());
            return View(pvm);
        }

        // [HttpGet]
        // public IActionResult GetPersonasFiltro(int cant, int PersonaId)
        // {
        //     Console.WriteLine(cant);
        //     Console.WriteLine(PersonaId);
        //     List<Persona> listPersonas;
        //     if (cant == 0)
        //     {
        //         listPersonas = _context.Persona
        //             .Include(p => p.PersonaEstado)
        //             .Include(p => p.PersonaTipo)
        //             .Where(x => x.Activo == true && x.PersonaId == PersonaId)
        //             .OrderByDescending(x => x.PersonaId)
        //             .ToList();
        //     }
        //     else
        //     {
        //         listPersonas = _context.Persona
        //         .Include(p => p.PersonaEstado)
        //         .Include(p => p.PersonaTipo)
        //         .Where(x => x.Activo == true)
        //         .OrderByDescending(x => x.PersonaId)
        //         .Take((int)cant).ToList();
        //     }
        //     Console.WriteLine(listPersonas.Count);
        //     return PartialView("_Index", listPersonas);

        // }


        [HttpGet]
        public IActionResult GetPersonasFiltro(int cant, int PersonaId)
        {
            Console.WriteLine(cant);
            Console.WriteLine(PersonaId);
            List<Persona> listPersonas;
            if (cant == 0)
            {
                listPersonas = _context.Persona
                    .Include(p => p.PersonaEstado)
                    .Include(p => p.PersonaTipo)
                    .Where(x => x.Activo == true && x.PersonaId == PersonaId)
                    .OrderByDescending(x => x.PersonaId)
                    .ToList();
            }
            else
            {
                listPersonas = _context.Persona
                .Include(p => p.PersonaEstado)
                .Include(p => p.PersonaTipo)
                .Where(x => x.Activo == true)
                .OrderByDescending(x => x.PersonaId)
                .Take((int)cant).ToList();
            }
            Console.WriteLine(listPersonas.Count);

            var myViewData = new ViewDataDictionary(new Microsoft.AspNetCore.Mvc.ModelBinding.EmptyModelMetadataProvider(), new Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary()) { { "_Index", listPersonas } };
            myViewData.Model = listPersonas;

            PartialViewResult result = new PartialViewResult()
            {
                ViewName = "_Index",
                ViewData = myViewData,
            };

            return result;
            // return PartialView("_Index", listPersonas);

        }

        // GET: Personas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Persona == null)
            {
                return NotFound();
            }

            var persona = await _context.Persona
                .Include(p => p.PersonaEstado)
                .Include(p => p.PersonaTipo)
                .FirstOrDefaultAsync(m => m.PersonaId == id);
            if (persona == null)
            {
                return NotFound();
            }

            return View(persona);
        }

        // GET: Personas/Create
        public IActionResult Create()
        {
            ViewData["PersonaEstadoId"] = new SelectList(_context.PersonaEstado, "PersonaEstadoId", "Nombre");
            ViewData["PersonaTipoId"] = new SelectList(_context.PersonaTipo.Where(x => x.PersonaTipoId != (int)PersonaTipoE.Entidad && x.PersonaTipoId != (int)PersonaTipoE.Particular), "PersonaTipoId", "Nombre");
            return View();
        }

        // POST: Personas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Email,Nombre,Apellido,DNI,PersonaTipoId,CUIT,RazonSocial,Telefono,FechaAlta,PersonaEstadoId,Activo")] PersonaViewModelCustom oPersonaViewModelCustom)
        {
            if (ModelState.IsValid)
            {
                Persona oPersonaRepetida = GestorPersona.getPersonaByCUIT(oPersonaViewModelCustom.CUIT);
                if (oPersonaRepetida != null)
                {
                    ModelState.AddModelError("", "El CUIT/CUIL ingresado, ya se encuentra registrado");
                    ViewData["PersonaEstadoId"] = new SelectList(_context.PersonaEstado, "PersonaEstadoId", "Nombre", oPersonaViewModelCustom.PersonaEstadoId);
                    ViewData["PersonaTipoId"] = new SelectList(_context.PersonaTipo.Where(x => x.PersonaTipoId != (int)PersonaTipoE.Entidad && x.PersonaTipoId != (int)PersonaTipoE.Particular), "PersonaTipoId", "Nombre", oPersonaViewModelCustom.PersonaTipoId);
                    return View(oPersonaViewModelCustom);
                }
                oPersonaViewModelCustom.Activo = true;
                oPersonaViewModelCustom.FechaAlta = DateTime.Now;
                if (oPersonaViewModelCustom.PersonaEstadoId == null)
                {
                    oPersonaViewModelCustom.PersonaEstadoId = (int)PersonaEstadoE.Disponible;
                }
                Persona oPersona = new Persona();
                oPersona.Nombre = oPersonaViewModelCustom.Nombre.ToUpper();
                oPersona.Email = oPersonaViewModelCustom.Email;
                oPersona.Apellido = oPersonaViewModelCustom.Apellido.ToUpper();
                oPersona.PersonaTipoId = oPersonaViewModelCustom.PersonaTipoId;
                oPersona.CUIT = oPersonaViewModelCustom.CUIT;
                if (oPersonaViewModelCustom.RazonSocial != null)
                {
                    oPersona.RazonSocial = oPersonaViewModelCustom.RazonSocial.ToUpper();
                }
                else
                {
                    oPersona.RazonSocial = oPersona.Nombre + ", " + oPersona.Apellido;
                }

                oPersona.Telefono = oPersonaViewModelCustom.Telefono;
                oPersona.FechaAlta = oPersonaViewModelCustom.FechaAlta;
                oPersona.PersonaEstadoId = oPersonaViewModelCustom.PersonaEstadoId;
                oPersona.DNI = oPersonaViewModelCustom.DNI;
                oPersona.Activo = oPersonaViewModelCustom.Activo;
                _context.Persona.Add(oPersona);
                _context.SaveChanges();

                //Domicilio oDomicilio = db.Domicilio.Where(x => x.PersonaId == oPersona.PersonaId && x.Activo == true).FirstOrDefault();
                //if (oDomicilio == null)
                //{
                return RedirectToAction("CreateDomicilioPersona", "Domicilios", new { id = oPersona.PersonaId });
                // }
                //return RedirectToAction("Index");
            }


            ViewData["PersonaEstadoId"] = new SelectList(_context.PersonaEstado, "PersonaEstadoId", "Nombre", oPersonaViewModelCustom.PersonaEstadoId);
            ViewData["PersonaTipoId"] = new SelectList(_context.PersonaTipo.Where(x => x.PersonaTipoId != (int)PersonaTipoE.Entidad && x.PersonaTipoId != (int)PersonaTipoE.Particular), "PersonaTipoId", "Nombre", oPersonaViewModelCustom.PersonaTipoId);
            return View(oPersonaViewModelCustom);
        }

        // GET: Personas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Persona == null)
            {
                return NotFound();
            }

            var persona = await _context.Persona.FindAsync(id);
            if (persona == null)
            {
                return NotFound();
            }
            ViewData["PersonaEstadoId"] = new SelectList(_context.PersonaEstado, "PersonaEstadoId", "PersonaEstadoId", persona.PersonaEstadoId);
            ViewData["PersonaTipoId"] = new SelectList(_context.PersonaTipo, "PersonaTipoId", "PersonaTipoId", persona.PersonaTipoId);
            return View(persona);
        }

        // POST: Personas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PersonaId,Nombre,Apellido,PersonaTipoId,CUIT,RazonSocial,Telefono,FechaAlta,PersonaEstadoId,ActualizoDeuda,FechaUltimaActualizacion,Email,DNI,Activo")] Persona persona)
        {
            if (id != persona.PersonaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(persona);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonaExists(persona.PersonaId))
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
            ViewData["PersonaEstadoId"] = new SelectList(_context.PersonaEstado, "PersonaEstadoId", "PersonaEstadoId", persona.PersonaEstadoId);
            ViewData["PersonaTipoId"] = new SelectList(_context.PersonaTipo, "PersonaTipoId", "PersonaTipoId", persona.PersonaTipoId);
            return View(persona);
        }

        // GET: Personas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Persona == null)
            {
                return NotFound();
            }

            var persona = await _context.Persona
                .Include(p => p.PersonaEstado)
                .Include(p => p.PersonaTipo)
                .FirstOrDefaultAsync(m => m.PersonaId == id);
            if (persona == null)
            {
                return NotFound();
            }

            return View(persona);
        }

        // POST: Personas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Persona == null)
            {
                return Problem("Entity set 'ODAMuniDBContext.Persona'  is null.");
            }
            var persona = await _context.Persona.FindAsync(id);
            if (persona != null)
            {
                _context.Persona.Remove(persona);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonaExists(int id)
        {
            return (_context.Persona?.Any(e => e.PersonaId == id)).GetValueOrDefault();
        }
    }
}
