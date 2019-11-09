using PR.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PR.Domain.Repositories
{
    public interface ICommentRepository
    {
        void Insert(Comment comment);
        void Update(Comment comment);
        Task<Comment> GetById(Guid Id);
        Task<IEnumerable<Comment>> ListCommentsByReportId(Guid reportId);
    }
}
