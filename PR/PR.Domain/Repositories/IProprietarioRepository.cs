using PR.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PR.Domain.Repositories
{
    public interface IProprietarioRepository
    {
        void Inserir(Proprietario proprietario);
        void Atualizar(Proprietario proprietario);
        Task<Proprietario> BuscarPorId(Guid Id);
    }
}
