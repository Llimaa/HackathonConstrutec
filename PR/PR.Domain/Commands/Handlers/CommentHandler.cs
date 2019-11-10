using PR.Domain.Commands.Inputs;
using PR.Domain.Commands.Result;
using PR.Domain.Entities;
using PR.Domain.Helper;
using PR.Domain.Repositories;
using PR.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PR.Domain.Commands.Handlers
{
    public class CommentHandler : ICommandHandler<InsertCommentCommandInput>,
                                   ICommandHandler<UpdateCommentCommandInput>
    {
        private readonly IReportRepository _RELREP;
        private readonly ICommentRepository _COREP;
        private readonly IResponsibleRepository _RREP;

        public CommentHandler(IReportRepository RELREP, ICommentRepository COREP, IResponsibleRepository RREP)
        {
            _RELREP = RELREP;
            _COREP = COREP;
            _RREP = RREP;
        }

        public async Task<ICommandResult> Handler(InsertCommentCommandInput command)
        {

            var report = _RELREP.GetById(command.ReportId);
            var responsavel = _RREP.GetById(command.ResponsibleId);
            await Task.WhenAll(report, responsavel);
            var comment = new Comment(report.Result, responsavel.Result, command.Title, command.Description);

            var result =  _BuildResult.BuildResult(comment.Notifications);

            if (comment.Invalid)
                return new CommandResult(result);

            _COREP.Insert(comment);

            return new CommandResult(new string[] { "Comentário incluído com sucesso!" });
        }

        public async Task<ICommandResult> Handler(UpdateCommentCommandInput command)
        {
            var comment = await _COREP.GetById(command.CommentId);

            comment.Update(command.Title, command.Description);

            if (comment.Invalid)
                return new CommandResult(_BuildResult.BuildResult(comment.Notifications));

            _COREP.Update(comment);

            return new CommandResult(new string[] { "Comentário atualizado com sucesso!" });

        }

        public async Task<Comment> GetById(Guid Id)
        {
            var comment = await _COREP.GetById(Id);
            comment.Responsible = await _RREP.GetById(comment.ResponsibleId);
            comment.Report = await _RELREP.GetById(comment.ReportId);
            return comment;
        }
        public async Task<IEnumerable<Comment>> ListCommentsByReportId(Guid reportId)
        {
            var comments = await _COREP.ListCommentsByReportId(reportId);
            foreach (var comment in comments)
            {
                comment.Responsible = await _RREP.GetById(comment.ResponsibleId);
                comment.Report = await _RELREP.GetById(comment.ReportId);
            }
            return comments;
        }
    }
}
