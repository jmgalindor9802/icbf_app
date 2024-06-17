using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using icbf_app.Models;

namespace icbf_app.Controllers
{
    public class RegistroAvanceAcademicoController : Controller
    {
        private readonly IcbfAppContext _context;

        public RegistroAvanceAcademicoController(IcbfAppContext context)
        {
            _context = context;
        }

        // GET: RegistroAvanceAcademico
        public async Task<IActionResult> Index()
        {
            var icbfAppContext = _context.RegistrosAvanceAcademicos.Include(r => r.IdNinoNavigation);
            return View(await icbfAppContext.ToListAsync());
        }

        // GET: RegistroAvanceAcademico/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registroAvanceAcademico = await _context.RegistrosAvanceAcademicos
                .Include(r => r.IdNinoNavigation)
                .FirstOrDefaultAsync(m => m.IdAvance == id);
            if (registroAvanceAcademico == null)
            {
                return NotFound();
            }

            return View(registroAvanceAcademico);
        }

        // GET: RegistroAvanceAcademico/Create
        public IActionResult Create()
        {
            ViewData["IdNino"] = new SelectList(_context.Ninos, "IdNino", "IdNino");
            return View();
        }

        // POST: RegistroAvanceAcademico/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAvance,IdNino,AnioEscolarAvance,NivelAvance,NotaAvance,DescripcionAvance,FechaEntregaAvance")] RegistroAvanceAcademico registroAvanceAcademico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registroAvanceAcademico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdNino"] = new SelectList(_context.Ninos, "IdNino", "IdNino", registroAvanceAcademico.IdNino);
            return View(registroAvanceAcademico);
        }

        // GET: RegistroAvanceAcademico/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registroAvanceAcademico = await _context.RegistrosAvanceAcademicos.FindAsync(id);
            if (registroAvanceAcademico == null)
            {
                return NotFound();
            }
            ViewData["IdNino"] = new SelectList(_context.Ninos, "IdNino", "IdNino", registroAvanceAcademico.IdNino);
            return View(registroAvanceAcademico);
        }

        // POST: RegistroAvanceAcademico/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAvance,IdNino,AnioEscolarAvance,NivelAvance,NotaAvance,DescripcionAvance,FechaEntregaAvance")] RegistroAvanceAcademico registroAvanceAcademico)
        {
            if (id != registroAvanceAcademico.IdAvance)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registroAvanceAcademico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistroAvanceAcademicoExists(registroAvanceAcademico.IdAvance))
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
            ViewData["IdNino"] = new SelectList(_context.Ninos, "IdNino", "IdNino", registroAvanceAcademico.IdNino);
            return View(registroAvanceAcademico);
        }

        // GET: RegistroAvanceAcademico/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registroAvanceAcademico = await _context.RegistrosAvanceAcademicos
                .Include(r => r.IdNinoNavigation)
                .FirstOrDefaultAsync(m => m.IdAvance == id);
            if (registroAvanceAcademico == null)
            {
                return NotFound();
            }

            return View(registroAvanceAcademico);
        }

        // POST: RegistroAvanceAcademico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var registroAvanceAcademico = await _context.RegistrosAvanceAcademicos.FindAsync(id);
            if (registroAvanceAcademico != null)
            {
                _context.RegistrosAvanceAcademicos.Remove(registroAvanceAcademico);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistroAvanceAcademicoExists(int id)
        {
            return _context.RegistrosAvanceAcademicos.Any(e => e.IdAvance == id);
        }
    }
}
