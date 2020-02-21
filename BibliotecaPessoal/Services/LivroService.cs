using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BibliotecaPessoal.Data;
using BibliotecaPessoal.Models;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaPessoal.Services
{
    public class LivroService
    {
        private readonly BibliotecaPessoalContext _context;
        public LivroService(BibliotecaPessoalContext context)
        {
            _context = context;
        }

        public async Task<List<Livro>> GetLivrosAsync()
        {
            return await _context.Livro.Include(l => l.Editora).ToListAsync();
        }

        public async Task<Livro> GetLivroAsync(int id)
        {
            return await _context.Livro.Include(l => l.Editora).FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task PostLivro(Livro livro)
        {
            _context.Add(livro);
            await _context.SaveChangesAsync();
        }

        public async Task PutLivro(Livro livro)
        {
            _context.Update(livro);
            await _context.SaveChangesAsync();
        }

        public async Task DelLivro(int id)
        {
            var livro = await _context.Livro.FindAsync(id);
            _context.Livro.Remove(livro);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> LivroExists(int id)
        {
            return await _context.Livro.AnyAsync(e => e.Id == id);
        }
    }
}
