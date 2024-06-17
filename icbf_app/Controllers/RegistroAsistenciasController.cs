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
    public class RegistroAsistenciasController : Controller
    {
        private readonly IcbfAppContext _context;

        public RegistroAsistenciasController(IcbfAppContext context)
        {
            _context = context;
        }

        // GET: RegistroAsistencias
        public async Task<IActionResult> Index()
        {
            var icbfAppContext = _context.RegistrosAsistencia.Include(r => r.IdNinoNavigation);
            return View(await icbfAppContext.ToListAsync());
        }

        // GET: RegistroAsistencias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registroAsistencia = await _context.RegistrosAsistencia
                .Include(r => r.IdNinoNavigation)
                .FirstOrDefaultAsync(m => m.IdRegistroAsistencia == id);
            if (registroAsistencia == null)
            {
                return NotFound();
            }

            return View(registroAsistencia);
        }

        // GET: RegistroAsistencias/Create
        public IActionResult Create()
        {
            ViewData["IdNino"] = new SelectList(_context.Ninos, "IdNino", "IdNino");
            return View();
        }

        // POST: RegistroAsistencias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRegistroAsistencia,IdNino,FechaRegistro,EstadoNinoRegistro")] RegistroAsistencia registroAsistencia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registroAsistencia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdNino"] = new SelectList(_context.Ninos, "IdNino", "IdNino", registroAsistencia.IdNino);
            return View(registroAsistencia);
        }

        // GET: RegistroAsistencias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registroAsistencia = await _context.RegistrosAsistencia.FindAsync(id);
            if (registroAsistencia == null)
            {
                return NotFound();
            }
            ViewData["IdNino"] = new SelectList(_context.Ninos, "IdNino", "IdNino", registroAsistencia.IdNino);
            return View(registroAsistencia);
        }

        // POST: RegistroAsistencias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRegistroAsistencia,IdNino,FechaRegistro,EstadoNinoRegistro")] RegistroAsistencia registroAsistencia)
        {
            if (id != registroAsistencia.IdRegistroAsistencia)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registroAsistencia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistroAsistenciaExists(registroAsistencia.IdRegistroAsistencia))
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
            ViewData["IdNino"] = new SelectList(_context.Ninos, "IdNino", "IdNino", registroAsistencia.IdNino);
            return View(registroAsistencia);
        }

        // GET: RegistroAsistencias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registroAsistencia = await _context.RegistrosAsistencia
                .Include(r => r.IdNinoNavigation)
                .FirstOrDefaultAsync(m => m.IdRegistroAsistencia == id);
            if (registroAsistencia == null)
            {
                return NotFound();
            }

            return View(registroAsistencia);
        }

        // POST: RegistroAsistencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var registroAsistencia = await _context.RegistrosAsistencia.FindAsync(id);
            if (registroAsistencia != null)
            {
                _context.RegistrosAsistencia.Remove(registroAsistencia);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistroAsistenciaExists(int id)
        {
            return _context.RegistrosAsistencia.Any(e => e.IdRegistroAsistencia == id);
        }
    }
}
