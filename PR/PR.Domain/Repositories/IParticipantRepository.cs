using PR.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PR.Domain.Repositories
{
    public interface IParticipantRepository
    {
        void Insert(Guid responsavelId, Guid obraId);
        Task<IEnumerable<Responsible>> GetConstructionId(Guid obraId); 
        Task<IEnumerable<Construction>> GetResponsibleId(Guid responsavelId);

    }
}
