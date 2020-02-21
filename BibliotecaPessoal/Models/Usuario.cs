using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaPessoal.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} O tamanho deve estar entre {2} e {1}")]
        public string Nome { get; set; }

        [StringLength(10, MinimumLength = 3, ErrorMessage = "{0} O tamanho deve estar entre {2} e {1}")]
        public string Login { get; set; }

        [StringLength(8, ErrorMessage = "{0} Senha deve conter apenas {1} caracteres")]
        public string Senha { get; set; }

        public DateTime DataCadastro { get; set; }

        public Usuario()
        {

        }

        public Usuario(int id, string nome, string login, string senha, DateTime dataCadastro)
        {
            Id = id;
            Nome = nome;
            Login = login;
            Senha = senha;
            DataCadastro = dataCadastro;
        }
    }
}
