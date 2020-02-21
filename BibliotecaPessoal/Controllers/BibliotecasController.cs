using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BibliotecaPessoal.Data;
using BibliotecaPessoal.Models;

namespace BibliotecaPessoal.Controllers
{
    public class BibliotecasController : Controller
    {
        private readonly BibliotecaPessoalContext _context;

        public BibliotecasController(BibliotecaPessoalContext context)
        {
            _context = context;
        }

        // GET: Bibliotecas
        public async Task<IActionResult> Index()
        {
            var bibliotecaPessoalContext = _context.Biblioteca.Include(b => b.Livro).Include(b => b.Usuario);
            return View(await bibliotecaPessoalContext.ToListAsync());
        }

        // GET: Bibliotecas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var biblioteca = await _context.Biblioteca
                .Include(b => b.Livro)
                .Include(b => b.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (biblioteca == null)
            {
                return NotFound();
            }

            return View(biblioteca);
        }

        // GET: Bibliotecas/Create
        public IActionResult Create()
        {
            ViewData["LivroID"] = new SelectList(_context.Livro, "Id", "Id");
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Id");
            return View();
        }

        // POST: Bibliotecas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Situacao,Avaliacao,InicioLeitura,FinalLeitura,Comentario,UsuarioId,LivroID")] Biblioteca biblioteca)
        {
            if (ModelState.IsValid)
            {
                _context.Add(biblioteca);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LivroID"] = new SelectList(_context.Livro, "Id", "Id", biblioteca.LivroID);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Id", biblioteca.UsuarioId);
            return View(biblioteca);
        }

        // GET: Bibliotecas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var biblioteca = await _context.Biblioteca.FindAsync(id);
            if (biblioteca == null)
            {
                return NotFound();
            }
            ViewData["LivroID"] = new SelectList(_context.Livro, "Id", "Id", biblioteca.LivroID);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Id", biblioteca.UsuarioId);
            return View(biblioteca);
        }

        // POST: Bibliotecas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Situacao,Avaliacao,InicioLeitura,FinalLeitura,Comentario,UsuarioId,LivroID")] Biblioteca biblioteca)
        {
            if (id != biblioteca.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(biblioteca);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BibliotecaExists(biblioteca.Id))
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
            ViewData["LivroID"] = new SelectList(_context.Livro, "Id", "Id", biblioteca.LivroID);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Id", biblioteca.UsuarioId);
            return View(biblioteca);
        }

        // GET: Bibliotecas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var biblioteca = await _context.Biblioteca
                .Include(b => b.Livro)
                .Include(b => b.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (biblioteca == null)
            {
                return NotFound();
            }

            return View(biblioteca);
        }

        // POST: Bibliotecas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var biblioteca = await _context.Biblioteca.FindAsync(id);
            _context.Biblioteca.Remove(biblioteca);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BibliotecaExists(int id)
        {
            return _context.Biblioteca.Any(e => e.Id == id);
        }
    }
}
