using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaPessoal.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
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
