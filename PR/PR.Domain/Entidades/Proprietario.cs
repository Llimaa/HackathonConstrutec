using PR.Domain.ObjetosValor;
using PR.Shared.Entidades;
using System;

namespace PR.Domain.Entidades
{
    public class Proprietario : Entidade
    {
        public Proprietario(string nome, string telefone, string email, Endereco endereco)
        {
            Nome = nome;
            Telefone = telefone;
            Email = email;
            Endereco = endereco;
        }

        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public Endereco Endereco { get; set; }

        public void Update(string nome, string telefone, string email)
        {
            Nome = nome;
            Telefone = telefone;
            Email = email;
        }
    }
}
