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
    public class ReportHandler : ICommandHandler<InsertReportCommandInput>,
                                    ICommandHandler<UpdateReportCommandInput>
    {
        private readonly IResponsibleRepository _RREP;
        private readonly IConstructionRepository _OREP;
        private readonly IReportRepository _RLREP;

        public ReportHandler(IResponsibleRepository RREP, IConstructionRepository OREP, IReportRepository RLREP)
        {
            _RREP = RREP;
            _OREP = OREP;
            _RLREP = RLREP;
        }

        public async Task<ICommandResult> Handler(InsertReportCommandInput command)
        {
            var construction = _OREP.GetById(command.ConstructionId);
            var responsavel = _RREP.GetById(command.ResponsibleId);
            await Task.WhenAll(construction, responsavel);
            var report = new Report(command.Title, command.Image, command.Description, responsavel.Result, construction.Result);

            if (report.Invalid)
                return new CommandResult(_BuildResult.BuildResult(report.Notifications).Result);

            _RLREP.Insert(report);

            return new CommandResult(new string[] { "Relatório inserido com Sucesso!" });
        }

        public async Task<ICommandResult> Handler(UpdateReportCommandInput command)
        {
            var report = await _RLREP.GetById(command.ReportId);

            report.Update(command.Title, command.Image, command.Description);

            if (report.Invalid)
                return new CommandResult(_BuildResult.BuildResult(report.Notifications).Result);

            _RLREP.Update(report);
            
            return new CommandResult(new string[] { "Relatório editado com Sucesso !!" });
        }

        public async Task<Report> GetById(Guid id)
        {
            var report = await _RLREP.GetById(id);
            return report;
        }
        public async Task<IEnumerable<Report>> ListByResponsibleId(Guid responsibleId)
        {
            var reports = await _RLREP.ListByResponsibleId(responsibleId);
            return reports;
        }

        public async Task<IEnumerable<Report>> ListByConstructionId(Guid constructionId)
        {
            var reports = await _RLREP.ListByConstructionId(constructionId);
            return reports;
        }
    }
}
