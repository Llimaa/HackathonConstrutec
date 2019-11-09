using PR.Shared.Entidades;
using System.Collections.Generic;

namespace PR.Domain.Entidades
{
    public class Responsavel : Entidade
    {
        public Responsavel()
        {
            Obras = new List<Obra>();
        }
        public Responsavel(string nome, string crea,string email, string telefone)
        {
            Nome = nome;
            CREA = crea;
            Email = email;
            Telefone = telefone;
        }

        public List<Obra> Obras { get; set; }
        public string Nome { get; set; }
        public string CREA { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        public void Update(string nome, string email, string telefone)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
        }
    }
}
