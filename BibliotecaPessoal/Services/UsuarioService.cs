using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BibliotecaPessoal.Data;
using BibliotecaPessoal.Models;

namespace BibliotecaPessoal.Services
{
    public class UsuarioService
    {
        private readonly BibliotecaPessoalContext _context;

        public UsuarioService(BibliotecaPessoalContext context)
        {
            _context = context;
        }

        public async Task<List<Usuario>> GetUsuariosAsync()
        {
            return await _context.Usuario.ToListAsync();
        }

        public async Task<Usuario> GetUsuarioAsync(int id)
        {
            return await _context.Usuario.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task PostUsuario(Usuario usuario)
        {
            _context.Add(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task PutUsuario(Usuario usuario)
        {
            _context.Update(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task DelUsuario(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            _context.Remove(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UsuarioExists(int id)
        {
            return await _context.Usuario.AnyAsync(u => u.Id == id);
        }
    }
}
