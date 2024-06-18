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
    public class NinosController : Controller
    {
        private readonly IcbfAppContext _context;

        public NinosController(IcbfAppContext context)
        {
            _context = context;
        }

        // GET: Ninos
        public async Task<IActionResult> Index()
        {
            var icbfAppContext = _context.Ninos.Include(n => n.IdAcudienteNavigation).Include(n => n.IdJardinNavigation);
            return View(await icbfAppContext.ToListAsync());
        }

        // GET: Ninos/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nino = await _context.Ninos
                .Include(n => n.IdAcudienteNavigation)
                .Include(n => n.IdJardinNavigation)
                .FirstOrDefaultAsync(m => m.IdNino == id);
            if (nino == null)
            {
                return NotFound();
            }

            return View(nino);
        }

        // GET: Ninos/Create
        public IActionResult Create()
        {
            ViewData["IdAcudiente"] = new SelectList(_context.AspNetUsers, "Id", "UserName");
            ViewData["IdJardin"] = new SelectList(_context.Jardines, "IdJardin", "NombreJardin");
            ViewBag.TipoSangreNino = new List<SelectListItem>
            {
                new SelectListItem { Text = "A+", Value = "A+" },
                new SelectListItem { Text = "A-", Value = "A-" },
                new SelectListItem { Text = "B+", Value = "B+" },
                new SelectListItem { Text = "B-", Value = "B-" },
                new SelectListItem { Text = "AB+", Value = "AB+" },
                new SelectListItem { Text = "AB-", Value = "AB-" },
                new SelectListItem { Text = "O+", Value = "O+" },
                new SelectListItem { Text = "O-", Value = "O-" }
            };
            return View();
        }

        // POST: Ninos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdNino,NombreNino,FechaNacimientoNino,TipoSangreNino,CiudadNacimientoNino,IdAcudiente,TelefonoNino,DireccionNino,EpsNino,IdJardin")] Nino nino)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nino);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAcudiente"] = new SelectList(_context.AspNetUsers, "Id", "UserName", nino.IdAcudiente);
            ViewData["IdJardin"] = new SelectList(_context.Jardines, "IdJardin", "NombreJardin", nino.IdJardin);
            ViewBag.TipoSangreNino = new List<SelectListItem>
            {
                new SelectListItem { Text = "A+", Value = "A+" },
                new SelectListItem { Text = "A-", Value = "A-" },
                new SelectListItem { Text = "B+", Value = "B+" },
                new SelectListItem { Text = "B-", Value = "B-" },
                new SelectListItem { Text = "AB+", Value = "AB+" },
                new SelectListItem { Text = "AB-", Value = "AB-" },
                new SelectListItem { Text = "O+", Value = "O+" },
                new SelectListItem { Text = "O-", Value = "O-" }
            };
            return View(nino);
        }

        // GET: Ninos/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nino = await _context.Ninos.FindAsync(id);
            if (nino == null)
            {
                return NotFound();
            }
            ViewData["IdAcudiente"] = new SelectList(_context.AspNetUsers, "Id", "UserName", nino.IdAcudiente);
            ViewData["IdJardin"] = new SelectList(_context.Jardines, "IdJardin", "NombreJardin", nino.IdJardin);
            ViewBag.TipoSangreNino = new List<SelectListItem>
            {
                new SelectListItem { Text = "A+", Value = "A+" },
                new SelectListItem { Text = "A-", Value = "A-" },
                new SelectListItem { Text = "B+", Value = "B+" },
                new SelectListItem { Text = "B-", Value = "B-" },
                new SelectListItem { Text = "AB+", Value = "AB+" },
                new SelectListItem { Text = "AB-", Value = "AB-" },
                new SelectListItem { Text = "O+", Value = "O+" },
                new SelectListItem { Text = "O-", Value = "O-" }
            };
            return View(nino);
        }

        // POST: Ninos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("IdNino,NombreNino,FechaNacimientoNino,TipoSangreNino,CiudadNacimientoNino,IdAcudiente,TelefonoNino,DireccionNino,EpsNino,IdJardin")] Nino nino)
        {
            if (id != nino.IdNino)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nino);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NinoExists(nino.IdNino))
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
            ViewData["IdAcudiente"] = new SelectList(_context.AspNetUsers, "Id", "UserName", nino.IdAcudiente);
            ViewData["IdJardin"] = new SelectList(_context.Jardines, "IdJardin", "NombreJardin", nino.IdJardin);
            ViewBag.TipoSangreNino = new List<SelectListItem>
            {
                new SelectListItem { Text = "A+", Value = "A+" },
                new SelectListItem { Text = "A-", Value = "A-" },
                new SelectListItem { Text = "B+", Value = "B+" },
                new SelectListItem { Text = "B-", Value = "B-" },
                new SelectListItem { Text = "AB+", Value = "AB+" },
                new SelectListItem { Text = "AB-", Value = "AB-" },
                new SelectListItem { Text = "O+", Value = "O+" },
                new SelectListItem { Text = "O-", Value = "O-" }
            };
            return View(nino);
        }

        // GET: Ninos/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nino = await _context.Ninos
                .Include(n => n.IdAcudienteNavigation)
                .Include(n => n.IdJardinNavigation)
                .FirstOrDefaultAsync(m => m.IdNino == id);
            if (nino == null)
            {
                return NotFound();
            }

            return View(nino);
        }

        // POST: Ninos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var nino = await _context.Ninos.FindAsync(id);
            if (nino != null)
            {
                _context.Ninos.Remove(nino);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NinoExists(long id)
        {
            return _context.Ninos.Any(e => e.IdNino == id);
        }
    }
}
