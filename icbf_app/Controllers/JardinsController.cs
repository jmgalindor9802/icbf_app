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
    public class JardinsController : Controller
    {
        private readonly IcbfAppContext _context;

        public JardinsController(IcbfAppContext context)
        {
            _context = context;
        }

        // GET: Jardins
        public async Task<IActionResult> Index()
        {
            return View(await _context.Jardines.ToListAsync());
        }

        // GET: Jardins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jardin = await _context.Jardines
                .FirstOrDefaultAsync(m => m.IdJardin == id);
            if (jardin == null)
            {
                return NotFound();
            }

            return View(jardin);
        }

        // GET: Jardins/Create
        public IActionResult Create()
        {
            var estados = new List<SelectListItem>
    {
        new SelectListItem { Value = "Aprobado", Text = "Aprobado" },
        new SelectListItem { Value = "En trámite", Text = "En trámite" },
        new SelectListItem { Value = "Negado", Text = "Negado" }
    };

            ViewBag.Estados = estados;
            return View();
        }

        // POST: Jardins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdJardin,NombreJardin,DireccionJardin,EstadoJardin")] Jardin jardin)
        {

            if (_context.Jardines.Any(j => j.NombreJardin == jardin.NombreJardin))
            {
                ModelState.AddModelError("NombreJardin", "Ya existe un jardín con este nombre.");
            }

            if (ModelState.IsValid)
            {
                _context.Add(jardin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            var estados = new List<SelectListItem>
    {
        new SelectListItem { Value = "Aprobado", Text = "Aprobado" },
        new SelectListItem { Value = "En trámite", Text = "En trámite" },
        new SelectListItem { Value = "Negado", Text = "Negado" }
    };
            ViewBag.Estados = estados;
            return View(jardin);
        }

        // GET: Jardins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jardin = await _context.Jardines.FindAsync(id);
            if (jardin == null)
            {
                return NotFound();
            }

            var estados = new List<SelectListItem>
    {
        new SelectListItem { Value = "Aprobado", Text = "Aprobado" },
        new SelectListItem { Value = "En trámite", Text = "En trámite" },
        new SelectListItem { Value = "Negado", Text = "Negado" }
    };

            ViewBag.Estados = estados;
            return View(jardin);
        }

        // POST: Jardins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdJardin,NombreJardin,DireccionJardin,EstadoJardin")] Jardin jardin)
        {
            if (id != jardin.IdJardin)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jardin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JardinExists(jardin.IdJardin))
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

            var estados = new List<SelectListItem>
    {
        new SelectListItem { Value = "Aprobado", Text = "Aprobado" },
        new SelectListItem { Value = "En trámite", Text = "En trámite" },
        new SelectListItem { Value = "Negado", Text = "Negado" }
    };
            ViewBag.Estados = estados;
            return View(jardin);
        }

        // GET: Jardins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jardin = await _context.Jardines
                .FirstOrDefaultAsync(m => m.IdJardin == id);
            if (jardin == null)
            {
                return NotFound();
            }

            return View(jardin);
        }

        // POST: Jardins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jardin = await _context.Jardines.FindAsync(id);
            if (jardin != null)
            {
                _context.Jardines.Remove(jardin);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JardinExists(int id)
        {
            return _context.Jardines.Any(e => e.IdJardin == id);
        }
    }
}
