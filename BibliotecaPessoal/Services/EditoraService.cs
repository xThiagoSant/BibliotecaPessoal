using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BibliotecaPessoal.Data;
using BibliotecaPessoal.Models;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaPessoal.Services
{
    public class EditoraService
    {
        private readonly BibliotecaPessoalContext _context;

        public EditoraService(BibliotecaPessoalContext context)
        {
            _context = context;
        }

        public DbSet<Editora> Editoras()
        {
            return _context.Editora;
        }

        public async Task<List<Editora>> GetEditorasAsync()
        {
            return await _context.Editora.ToListAsync();
        }

        public async Task<Editora> GetEditoraAsync(int id)
        {
            return await _context.Editora.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task PostEditora(Editora editora)
        {
            _context.Add(editora);
            await _context.SaveChangesAsync();
        }

        public async Task PutEditora(Editora editora)
        {
            _context.Update(editora);
            await _context.SaveChangesAsync();
        }

        public async Task DelEditora(int id)
        {
            var editora = await _context.Editora.FindAsync(id);
            _context.Editora.Remove(editora);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> EditoraExists(int id)
        {
            return await _context.Editora.AnyAsync(e => e.Id == id);
        }
    }
}
