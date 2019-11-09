using PR.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PR.Domain.Repositories
{
    public interface IRelatorioRepository
    {
        void Inserir(Relatorio relatorio);
        void Atualizar(Relatorio relatorio);
        Task<Relatorio> BuscarPorId(Guid id);
        Task<IEnumerable<Relatorio>> ListarPorResponsavelId(Guid responsavelId);
        Task<IEnumerable<Relatorio>> ListarPorObraId(Guid obraId);
    }
}
