using PR.Domain.Entities;
using PR.Domain.Repositories;
using PR.Infra.Infra;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PR.Infra.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly IDB _DB;

        public ReportRepository(IDB DB)
        {
            _DB = DB;
        }

        public async Task<Report> GetById(Guid id)
        {
            var sql = "";
            using (var db = _DB.GetCon())
            {

            }
            throw new NotImplementedException();
        }

        public void Insert(Report relatorio)
        {
            var sql = "";
            using (var db = _DB.GetCon())
            {

            }
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Report>> ListByConstructionId(Guid constructionId)
        {
            var sql = "";
            using (var db = _DB.GetCon())
            {

            }
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Report>> ListByResponsibleId(Guid responsabileId)
        {
            var sql = "";
            using (var db = _DB.GetCon())
            {

            }
            throw new NotImplementedException();
        }

        public void Update(Report relatorio)
        {
            var sql = "";
            using (var db = _DB.GetCon())
            {

            }
            throw new NotImplementedException();
        }
    }
}
