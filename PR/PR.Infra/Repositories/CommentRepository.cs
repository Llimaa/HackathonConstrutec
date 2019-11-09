using Dapper;
using PR.Domain.Entities;
using PR.Domain.Repositories;
using PR.Infra.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PR.Infra.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly IDB _DB;

        public CommentRepository(IDB DB)
        {
            _DB = DB;
        }

        public async Task<Comment> GetById(Guid Id)
        {
            var sql = "SELECT * FROM Comment WHERE Id = @Id";
            using (var db = _DB.GetCon())
            {
                var comment = await db.QueryAsync<Comment>(sql, new { Id });
                return comment.FirstOrDefault();
            }
        }

        public void Insert(Comment comment)
        {
            var sql = "INSERT INTO Comment " +
                "(Id,Title,Description,ResponsibleId,ReportId,DateComment)" +
                "VALUES " +
                "(@Id,@Title,@Description,@ResponsibleId,@ReportId,DateComment)";
            using (var db = _DB.GetCon())
            {
                db.Execute(sql, new
                {
                    comment.Id,
                    comment.Title,
                    comment.Description,
                    ResponsibleId = comment.Responsible.Id,
                    ReportId = comment.Report.Id,
                    DateComment = DateTime.Now
                });
            }
        }

        public async Task<IEnumerable<Comment>> ListCommentsByReportId(Guid reportId)
        {
            var sql = "SELECT * FROM Comment WHERE ReportId = @reportId";
            using (var db = _DB.GetCon())
            {
                var comment = await db.QueryAsync<Comment>(sql, new { reportId });
                return comment;
            }
        }

        public void Update(Comment comment)
        {
            var sql = "UPDATE Comment SET " +
                "Title = @Title " +
               ",Description = @Description " +
               "WHERE Id = @Id";
            using (var db = _DB.GetCon())
            {
                db.Execute(sql, new
                {
                    comment.Title,
                    comment.Description,
                    comment.Id
                });
            }
        }
    }
}
