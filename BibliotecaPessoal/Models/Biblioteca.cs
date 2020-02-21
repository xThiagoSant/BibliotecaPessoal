using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BibliotecaPessoal.Models.Enums;

namespace BibliotecaPessoal.Models
{
    public class Biblioteca
    {
        public int Id { get; set; }
        public Situacao Situacao { get; set; }
        public Avaliacao Avaliacao { get; set; }
        public string Comentario { get; set; }
        public DateTime InicioLeitura { get; set; }
        public DateTime FinalLeitura { get; set; }

        public ICollection<Usuario> Usuarios = new List<Usuario>();
        public ICollection<Livro> Livros = new List<Livro>();

        public Biblioteca()
        {

        }

        public Biblioteca(int id, Situacao situacao, Avaliacao avaliacao, string comentario, DateTime inicioLeitura, DateTime finalLeitura)
        {
            Id = id;
            Situacao = situacao;
            Avaliacao = avaliacao;
            Comentario = comentario;
            InicioLeitura = inicioLeitura;
            FinalLeitura = finalLeitura;
        }

        public void AddLivro(Livro livro)
        {
            Livros.Add(livro);
        }

        public void RemLivro(Livro livro)
        {
            Livros.Remove(livro);
        }

        public void AddUsuario(Usuario usuario)
        {
            Usuarios.Add(usuario);
        }

        public void RemUsuario(Usuario usuario)
        {
            Usuarios.Remove(usuario);
        }
    }
}
