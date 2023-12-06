using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASPNET_TP3.Data;
using ASPNET_TP3.Models;

namespace ASPNET_TP3.Controllers
{
    public class LivroesController : Controller
    {
        private readonly BooksContext _context;

        public LivroesController(BooksContext context)
        {
            _context = context;
        }

        // GET: Livroes
        public async Task<IActionResult> Index()
        {
            var booksContext = _context.Livro.Include(l => l.Autor).Include(l => l.Genero);
            return View(await booksContext.ToListAsync());
        }

        // GET: Livroes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Livro == null)
            {
                return NotFound();
            }

            var livro = await _context.Livro
                .Include(l => l.Autor)
                .Include(l => l.Genero)
                .FirstOrDefaultAsync(m => m.ISBN == id);
            if (livro == null)
            {
                return NotFound();
            }

            return View(livro);
        }

        // GET: Livroes/Create
        public IActionResult Create()
        {
            ViewData["AutorId"] = new SelectList(_context.Autor, "Id", "LastName");
            ViewData["GeneroId"] = new SelectList(_context.Genero, "Id", "Description");
            return View();
        }

        // POST: Livroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ISBN,Name,Sinopse,DataDePublicacao,AutorId,GeneroId")] Livro livro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(livro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AutorId"] = new SelectList(_context.Autor, "Id", "LastName", livro.AutorId);
            ViewData["GeneroId"] = new SelectList(_context.Genero, "Id", "Description", livro.GeneroId);
            return View(livro);
        }

        // GET: Livroes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Livro == null)
            {
                return NotFound();
            }

            var livro = await _context.Livro.FindAsync(id);
            if (livro == null)
            {
                return NotFound();
            }
            ViewData["AutorId"] = new SelectList(_context.Autor, "Id", "LastName", livro.AutorId);
            ViewData["GeneroId"] = new SelectList(_context.Genero, "Id", "Description", livro.GeneroId);
            return View(livro);
        }

        // POST: Livroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ISBN,Name,Sinopse,DataDePublicacao,AutorId,GeneroId")] Livro livro)
        {
            if (id != livro.ISBN)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(livro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LivroExists(livro.ISBN))
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
            ViewData["AutorId"] = new SelectList(_context.Autor, "Id", "LastName", livro.AutorId);
            ViewData["GeneroId"] = new SelectList(_context.Genero, "Id", "Description", livro.GeneroId);
            return View(livro);
        }

        // GET: Livroes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Livro == null)
            {
                return NotFound();
            }

            var livro = await _context.Livro
                .Include(l => l.Autor)
                .Include(l => l.Genero)
                .FirstOrDefaultAsync(m => m.ISBN == id);
            if (livro == null)
            {
                return NotFound();
            }

            return View(livro);
        }

        // POST: Livroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Livro == null)
            {
                return Problem("Entity set 'BooksContext.Livro'  is null.");
            }
            var livro = await _context.Livro.FindAsync(id);
            if (livro != null)
            {
                _context.Livro.Remove(livro);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LivroExists(string id)
        {
          return (_context.Livro?.Any(e => e.ISBN == id)).GetValueOrDefault();
        }
    }
}
