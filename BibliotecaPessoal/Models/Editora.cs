using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaPessoal.Models
{
    public class Editora
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Nome { get; set; }

        public ICollection<Livro> Livros = new List<Livro>();

        public Editora()
        {

        }

        public Editora(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public void AddLivro(Livro livro)
        {
            Livros.Add(livro);
        }

        public void RemLivro(Livro livro)
        {
            Livros.Remove(livro);
        }
    }
}
