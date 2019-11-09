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
        Task<Report> GetById(Guid id);
        Task<IEnumerable<Report>> ListByResponsibleId(Guid responsabileId);
        Task<IEnumerable<Report>> ListByConstructionId(Guid constructionId);
    }
}
