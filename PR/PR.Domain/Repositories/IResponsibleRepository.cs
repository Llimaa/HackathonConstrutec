using PR.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace PR.Domain.Repositories
{
    public interface IResponsibleRepository
    {
        void Insert(Responsible responsavel);
        void Update(Responsible responsavel);
        Task<Responsible> GetCREA(string crea);
        Task<Responsible> GetId(Guid Id);
    }
}
