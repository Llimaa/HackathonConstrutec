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
    public class ReportHandler : ICommandHandler<InsertReportsCommandInput>,
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

        public async Task<ICommandResult> Handler(InsertReportsCommandInput command)
        {
            var construction = _OREP.GetId(command.ConstructionId);
            var responsavel = _RREP.GetId(command.ResponsibleId);
            await Task.WhenAll(construction, responsavel);
            var report = new Report(command.Title, command.Image, command.Description, responsavel.Result, construction.Result);

            if (report.Invalid)
                return new CommandResult(_BuildResult.BuildResult(report.Notifications).Result);

            _RLREP.Insert(report);

            return new CommandResult(new string[] { "Relatório inserido com Sucesso!" });
        }

        public async Task<ICommandResult> Handler(UpdateReportCommandInput command)
        {
            var report = await _RLREP.GetId(command.ReportId);

            report.Update(command.Title, command.Image, command.Description);

            if (report.Invalid)
                return new CommandResult(_BuildResult.BuildResult(report.Notifications).Result);

            _RLREP.Update(report);
            
            return new CommandResult(new string[] { "Relatório editado com Sucesso !!" });
        }

        public async Task<IEnumerable<Report>> ListResponsible(Guid Id)
        {
            return await _RLREP.ListResponsibleId(Id);
        }

        public async Task<IEnumerable<Report>> ListConstruction(Guid Id)
        {
            return await _RLREP.ListConstructionId(Id);
        }
    }
}
