using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaPessoal.Models
{
    public class Livro
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Nome { get; set; }
        public int Paginas { get; set; }
        [StringLength(20)]
        public string Isbn10 { get; set; }
        [StringLength(20)]
        public string Isbn30 { get; set; }
        public Editora Editora { get; set; }
        public int EditoraId { get; set; }

        public Livro()
        {

        }

        public Livro(int id, string nome, int paginas, string isbn10, string isbn30, Editora editora)
        {
            Id = id;
            Nome = nome;
            Paginas = paginas;
            Isbn10 = isbn10;
            Isbn30 = isbn30;
            Editora = editora;
        }
    }
}
