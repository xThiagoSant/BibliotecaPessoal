using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BibliotecaPessoal.Models;
using BibliotecaPessoal.Services;
//using BibliotecaPessoal.Data;

namespace BibliotecaPessoal.Controllers
{
    public class LivrosController : Controller
    {
        private readonly LivroService _livroService;
        private readonly EditoraService _editoraService;
        //private readonly BibliotecaPessoalContext _context;

        public LivrosController(LivroService livroService, EditoraService editoraService)
        {
            _livroService = livroService;
            _editoraService = editoraService;
        }

        // GET: Livros
        public async Task<IActionResult> Index()
        {
            return View(await _livroService.GetLivrosAsync());
        }

        // GET: Livros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livro = await _livroService.GetLivroAsync(id.Value);
            if (livro == null)
            {
                return NotFound();
            }

            return View(livro);
        }

        // GET: Livros/Create
        public IActionResult Create()
        {
            ViewData["EditoraId"] = new SelectList(_editoraService.Editoras(), "Id", "Id");
            return View();
        }

        // POST: Livros/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Paginas,Isbn10,Isbn30,EditoraId")] Livro livro)
        {
            if (ModelState.IsValid)
            {
                await _livroService.PostLivro(livro);
                return RedirectToAction(nameof(Index));
            }
            ViewData["EditoraId"] = new SelectList(_editoraService.Editoras(), "Id", "Id", livro.EditoraId);
            return View(livro);
        }

        // GET: Livros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livro = await _livroService.GetLivroAsync(id.Value);
            if (livro == null)
            {
                return NotFound();
            }
            ViewData["EditoraId"] = new SelectList(_editoraService.Editoras(), "Id", "Id", livro.EditoraId);
            return View(livro);
        }

        // POST: Livros/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Paginas,Isbn10,Isbn30,EditoraId")] Livro livro)
        {
            if (id != livro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _livroService.PutLivro(livro);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (! await _livroService.LivroExists(livro.Id))
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
            ViewData["EditoraId"] = new SelectList(_editoraService.Editoras(), "Id", "Id", livro.EditoraId);
            return View(livro);
        }

        // GET: Livros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livro = await _livroService.GetLivroAsync(id.Value);
            if (livro == null)
            {
                return NotFound();
            }

            return View(livro);
        }

        // POST: Livros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _livroService.DelLivro(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
