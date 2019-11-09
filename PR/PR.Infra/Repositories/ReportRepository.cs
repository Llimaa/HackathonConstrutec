using Dapper;
using PR.Domain.Entities;
using PR.Domain.Repositories;
using PR.Infra.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var sql = "SELECT * FROM Report WHERE Id = @id";
            using (var db = _DB.GetCon())
            {
                var report = await db.QueryAsync<Report>(sql, new { id });
                return report.FirstOrDefault();
            }
        }

        public void Insert(Report relatorio)
        {
            var sql = "INSERT INTO Report " +
                "(Id,ConstructionId,ResponsibleId,Title,Description,Image,DateReport) " +
                "VALUES" +
                "(@Id,@ConstructionId,@ResponsibleId,@Title,@Description,@Image,@DateReport)";
            using (var db = _DB.GetCon())
            {
                db.Execute(sql, new
                {
                    ResponsibleId = relatorio.Responsible.Id,
                    ConstructionId = relatorio.Construction.Id,
                    relatorio.Title,
                    relatorio.Description,
                    relatorio.Image,
                    relatorio.Id,
                    relatorio.DateReport
                });
            }
        }

        public async Task<IEnumerable<Report>> ListByConstructionId(Guid constructionId)
        {
            var sql = "SELECT * FROM Report WHERE ConstructionId = @constructionId";
            using (var db = _DB.GetCon())
            {
                var report = await db.QueryAsync<Report>(sql, new { constructionId });
                return report;
            }
        }

        public async Task<IEnumerable<Report>> ListByResponsibleId(Guid responsabileId)
        {
            var sql = "SELECT * FROM Report WHERE Responsible = @responsabileId";
            using (var db = _DB.GetCon())
            {
                var report = await db.QueryAsync<Report>(sql, new { responsabileId });
                return report;
            }
        }

        public void Update(Report relatorio)
        {
            var sql = "UPDATE Report SET" +
                "Title = @Title" +
                ",Image = @Image" +
                ",Description = @Description" +
                " WHERE Id = @Id";
            using (var db = _DB.GetCon())
            {
                db.Execute(sql, new
                {
                    relatorio.Title,
                    relatorio.Description,
                    relatorio.Image,
                    relatorio.Id
                });
            }
        }
    }
}
