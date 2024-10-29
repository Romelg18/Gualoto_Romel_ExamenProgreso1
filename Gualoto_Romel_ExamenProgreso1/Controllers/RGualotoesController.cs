using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gualoto_Romel_ExamenProgreso1.Models;

namespace Gualoto_Romel_ExamenProgreso1.Controllers
{
    public class RGualotoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RGualotoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RGualotoes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Apellidos.Include(r => r.Celular);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: RGualotoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rGualoto = await _context.Apellidos
                .Include(r => r.Celular)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rGualoto == null)
            {
                return NotFound();
            }

            return View(rGualoto);
        }

        // GET: RGualotoes/Create
        public IActionResult Create()
        {
            ViewData["CelularId"] = new SelectList(_context.Celulares, "Id", "Modelo");
            return View();
        }

        // POST: RGualotoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Edad,IngresoMensual,Activo,FechaNacimiento,CelularId")] RGualoto rGualoto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rGualoto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CelularId"] = new SelectList(_context.Celulares, "Id", "Modelo", rGualoto.CelularId);
            return View(rGualoto);
        }

        // GET: RGualotoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rGualoto = await _context.Apellidos.FindAsync(id);
            if (rGualoto == null)
            {
                return NotFound();
            }
            ViewData["CelularId"] = new SelectList(_context.Celulares, "Id", "Modelo", rGualoto.CelularId);
            return View(rGualoto);
        }

        // POST: RGualotoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Edad,IngresoMensual,Activo,FechaNacimiento,CelularId")] RGualoto rGualoto)
        {
            if (id != rGualoto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rGualoto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RGualotoExists(rGualoto.Id))
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
            ViewData["CelularId"] = new SelectList(_context.Celulares, "Id", "Modelo", rGualoto.CelularId);
            return View(rGualoto);
        }

        // GET: RGualotoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rGualoto = await _context.Apellidos
                .Include(r => r.Celular)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rGualoto == null)
            {
                return NotFound();
            }

            return View(rGualoto);
        }

        // POST: RGualotoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rGualoto = await _context.Apellidos.FindAsync(id);
            if (rGualoto != null)
            {
                _context.Apellidos.Remove(rGualoto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RGualotoExists(int id)
        {
            return _context.Apellidos.Any(e => e.Id == id);
        }
    }
}
