using PR.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace PR.Domain.Repositories
{
    public interface IOwnerRepository
    {
        void Insert(Owner proprietario);
        void Update(Owner proprietario);
        Task<Owner> GetById(Guid Id);
    }
}
