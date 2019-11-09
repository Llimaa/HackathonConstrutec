using PR.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PR.Domain.Repositories
{
    public interface IConstructionRepository
    {
        void Insert(Construction construction);
        void Update(Construction construction);
        Task<Construction> GetById(Guid Id);
        Task<IEnumerable<Construction>> ListByOwnerId(Guid owerId);
    }
}
