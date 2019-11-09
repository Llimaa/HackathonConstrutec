using PR.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PR.Domain.Repositories
{
    public interface IParticipantRepository
    {
        void Insert(Guid responsavelId, Guid obraId);
        Task<IEnumerable<Responsible>> ListResponsibleByConstructionId(Guid constructionId); 
        Task<IEnumerable<Construction>> ListConstructionByResponsibleId(Guid responsableId);

    }
}
