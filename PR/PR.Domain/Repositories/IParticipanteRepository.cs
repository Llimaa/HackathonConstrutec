using PR.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PR.Domain.Repositories
{
    public interface IParticipanteRepository
    {
        void Inserir(Guid responsavelId, Guid obraId);
        Task<IEnumerable<Responsavel>> BuscarPorObraId(Guid obraId); 
    }
}
