using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication9.Models;

namespace WebApplication9.Controllers
{
    public class EstudiantesCursosController : Controller
    {
        private readonly EscuelitaTablas _context;

        public EstudiantesCursosController(EscuelitaTablas context)
        {
            _context = context;
        }

        // GET: EstudiantesCursos
        public async Task<IActionResult> Index()
        {
            var escuelitaTablas = _context.estudiantesCursos.Include(e => e.Alumno).Include(e => e.Cursos);
            return View(await escuelitaTablas.ToListAsync());
        }

        // GET: EstudiantesCursos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudiantesCursos = await _context.estudiantesCursos
                .Include(e => e.Alumno)
                .Include(e => e.Cursos)
                .FirstOrDefaultAsync(m => m.IdCursos == id);
            if (estudiantesCursos == null)
            {
                return NotFound();
            }

            return View(estudiantesCursos);
        }

        // GET: EstudiantesCursos/Create
        public IActionResult Create()
        {
            ViewData["idEstudiante"] = new SelectList(_context.Alumnos, "Id", "Id");
            ViewData["IdCursos"] = new SelectList(_context.Cursos, "idCursos", "idCursos");
            return View();
        }

        // POST: EstudiantesCursos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idEstudiante,IdCursos")] EstudiantesCursos estudiantesCursos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estudiantesCursos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["idEstudiante"] = new SelectList(_context.Alumnos, "Id", "Id", estudiantesCursos.idEstudiante);
            ViewData["IdCursos"] = new SelectList(_context.Cursos, "idCursos", "idCursos", estudiantesCursos.IdCursos);
            return View(estudiantesCursos);
        }

        // GET: EstudiantesCursos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudiantesCursos = await _context.estudiantesCursos.FindAsync(id);
            if (estudiantesCursos == null)
            {
                return NotFound();
            }
            ViewData["idEstudiante"] = new SelectList(_context.Alumnos, "Id", "Id", estudiantesCursos.idEstudiante);
            ViewData["IdCursos"] = new SelectList(_context.Cursos, "idCursos", "idCursos", estudiantesCursos.IdCursos);
            return View(estudiantesCursos);
        }

        // POST: EstudiantesCursos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idEstudiante,IdCursos")] EstudiantesCursos estudiantesCursos)
        {
            if (id != estudiantesCursos.IdCursos)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estudiantesCursos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstudiantesCursosExists(estudiantesCursos.IdCursos))
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
            ViewData["idEstudiante"] = new SelectList(_context.Alumnos, "Id", "Id", estudiantesCursos.idEstudiante);
            ViewData["IdCursos"] = new SelectList(_context.Cursos, "idCursos", "idCursos", estudiantesCursos.IdCursos);
            return View(estudiantesCursos);
        }

        // GET: EstudiantesCursos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudiantesCursos = await _context.estudiantesCursos
                .Include(e => e.Alumno)
                .Include(e => e.Cursos)
                .FirstOrDefaultAsync(m => m.IdCursos == id);
            if (estudiantesCursos == null)
            {
                return NotFound();
            }

            return View(estudiantesCursos);
        }

        // POST: EstudiantesCursos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estudiantesCursos = await _context.estudiantesCursos.FindAsync(id);
            _context.estudiantesCursos.Remove(estudiantesCursos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstudiantesCursosExists(int id)
        {
            return _context.estudiantesCursos.Any(e => e.IdCursos == id);
        }
    }
}
