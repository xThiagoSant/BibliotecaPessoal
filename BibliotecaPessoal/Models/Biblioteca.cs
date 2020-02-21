using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using BibliotecaPessoal.Models.Enums;

namespace BibliotecaPessoal.Models
{
    public class Biblioteca
    {
        public int Id { get; set; }

        public Situacao Situacao { get; set; }
        public Avaliacao Avaliacao { get; set; }  
        
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        public DateTime InicioLeitura { get; set; }

        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        public DateTime FinalLeitura { get; set; }

        [StringLength(200)]
        public string Comentario { get; set; }

        public Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }

        public Livro Livro { get; set; }
        public int LivroID { get; set; }

        public Biblioteca()
        {

        }

        public Biblioteca(int id, Situacao situacao, Avaliacao avaliacao, string comentario, DateTime inicioLeitura, 
            DateTime finalLeitura, Usuario usuario, Livro livro)
        {
            Id = id;
            Situacao = situacao;
            Avaliacao = avaliacao;
            Comentario = comentario;
            InicioLeitura = inicioLeitura;
            FinalLeitura = finalLeitura;
            Usuario = usuario;
            Livro = livro;
        }
    }
}
