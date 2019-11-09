using PR.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PR.Domain.Repositories
{
    public interface IObraRepository
    {
        void Inserir(Obra obra);
        void Atualizar(Obra obra);
        Task<Obra> BuscarPorId(Guid Id);
        Task<IEnumerable<Obra>> ListarPorProprietarioId(Guid proprietarioId);
    }
}
