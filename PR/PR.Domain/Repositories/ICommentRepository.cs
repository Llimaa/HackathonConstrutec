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
        Task<Comment> GetId(Guid Id);
        Task<IEnumerable<Comment>> ListCommentsPorReportId(Guid relatorioId);
       // IEnumerable<Comentario> TodosOsComments();
    }
}
