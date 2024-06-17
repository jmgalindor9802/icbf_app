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
    public class MadreComunitariasController : Controller
    {
        private readonly IcbfAppContext _context;

        public MadreComunitariasController(IcbfAppContext context)
        {
            _context = context;
        }

        // GET: MadreComunitarias
        public async Task<IActionResult> Index()
        {
            var icbfAppContext = _context.MadresComunitarias.Include(m => m.IdJardinNavigation).Include(m => m.IdUsuarioNavigation);
            return View(await icbfAppContext.ToListAsync());
        }

        // GET: MadreComunitarias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var madreComunitaria = await _context.MadresComunitarias
                .Include(m => m.IdJardinNavigation)
                .Include(m => m.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.IdMadreComunitaria == id);
            if (madreComunitaria == null)
            {
                return NotFound();
            }

            return View(madreComunitaria);
        }

        // GET: MadreComunitarias/Create
        public IActionResult Create()
        {
            ViewData["IdJardin"] = new SelectList(_context.Jardines, "IdJardin", "IdJardin");
            ViewData["IdUsuario"] = new SelectList(_context.AspNetUsers, "Id", "Id");
            return View();
        }

        // POST: MadreComunitarias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMadreComunitaria,FechaNacimientoMadre,IdJardin,IdUsuario")] MadreComunitaria madreComunitaria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(madreComunitaria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdJardin"] = new SelectList(_context.Jardines, "IdJardin", "IdJardin", madreComunitaria.IdJardin);
            ViewData["IdUsuario"] = new SelectList(_context.AspNetUsers, "Id", "Id", madreComunitaria.IdUsuario);
            return View(madreComunitaria);
        }

        // GET: MadreComunitarias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var madreComunitaria = await _context.MadresComunitarias.FindAsync(id);
            if (madreComunitaria == null)
            {
                return NotFound();
            }
            ViewData["IdJardin"] = new SelectList(_context.Jardines, "IdJardin", "IdJardin", madreComunitaria.IdJardin);
            ViewData["IdUsuario"] = new SelectList(_context.AspNetUsers, "Id", "Id", madreComunitaria.IdUsuario);
            return View(madreComunitaria);
        }

        // POST: MadreComunitarias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMadreComunitaria,FechaNacimientoMadre,IdJardin,IdUsuario")] MadreComunitaria madreComunitaria)
        {
            if (id != madreComunitaria.IdMadreComunitaria)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(madreComunitaria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MadreComunitariaExists(madreComunitaria.IdMadreComunitaria))
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
            ViewData["IdJardin"] = new SelectList(_context.Jardines, "IdJardin", "IdJardin", madreComunitaria.IdJardin);
            ViewData["IdUsuario"] = new SelectList(_context.AspNetUsers, "Id", "Id", madreComunitaria.IdUsuario);
            return View(madreComunitaria);
        }

        // GET: MadreComunitarias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var madreComunitaria = await _context.MadresComunitarias
                .Include(m => m.IdJardinNavigation)
                .Include(m => m.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.IdMadreComunitaria == id);
            if (madreComunitaria == null)
            {
                return NotFound();
            }

            return View(madreComunitaria);
        }

        // POST: MadreComunitarias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var madreComunitaria = await _context.MadresComunitarias.FindAsync(id);
            if (madreComunitaria != null)
            {
                _context.MadresComunitarias.Remove(madreComunitaria);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MadreComunitariaExists(int id)
        {
            return _context.MadresComunitarias.Any(e => e.IdMadreComunitaria == id);
        }
    }
}
