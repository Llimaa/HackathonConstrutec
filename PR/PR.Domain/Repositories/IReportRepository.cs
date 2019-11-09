using PR.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PR.Domain.Repositories
{
    public interface IReportRepository
    {
        void Insert(Report relatorio);
        void Update(Report relatorio);
        Task<Report> GetId(Guid id);
        Task<IEnumerable<Report>> ListResponsibleId(Guid responsavelId);
        Task<IEnumerable<Report>> ListConstructionId(Guid obraId);
    }
}
