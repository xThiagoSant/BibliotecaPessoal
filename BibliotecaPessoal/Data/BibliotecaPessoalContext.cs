using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BibliotecaPessoal.Models;

namespace BibliotecaPessoal.Data
{
    public class BibliotecaPessoalContext : DbContext
    {
        public BibliotecaPessoalContext (DbContextOptions<BibliotecaPessoalContext> options)
            : base(options)
        {
        }

        public DbSet<Editora> Editora { get; set; }

        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<Livro> Livro { get; set; }
    }
}
