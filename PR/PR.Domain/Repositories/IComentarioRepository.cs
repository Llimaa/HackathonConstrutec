using PR.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PR.Domain.Repositories
{
    public interface IComentarioRepository
    {
        void Inserir(Comentario comentario);
        void Atualizar(Comentario comentario);
        Task<Comentario> BuscarPorId(Guid Id);
        Task<IEnumerable<Comentario>> ListarComentariosPorRelatorioId(Guid relatorioId);
       // IEnumerable<Comentario> TodosOsComentarios();
    }
}
