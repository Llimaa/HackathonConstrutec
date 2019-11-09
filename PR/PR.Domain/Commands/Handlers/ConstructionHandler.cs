using PR.Domain.Commands.Inputs;
using PR.Domain.Commands.Result;
using PR.Domain.Entities;
using PR.Domain.ValueObjects;
using PR.Domain.Repositories;
using PR.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PR.Domain.Commands.Handlers
{
    public class ConstructionHandler : ICommandHandler<InsertConstructionCommandInput>,
                                ICommandHandler<UpdateConstructionCommandInput>,
                                ICommandHandler<InsertCommentCommandInput>,
                                ICommandHandler<UpdateCommentCommandInput>

    {
        private readonly IOwnerRepository _PPREP;
        private readonly IResponsibleRepository _RREP;
        private readonly IConstructionRepository _OREP;
        private readonly IParticipantRepository _PAREP;
        private readonly IReportRepository _RELREP;
        private readonly ICommentRepository _COREP;

        public ConstructionHandler(IOwnerRepository PPREP, IResponsibleRepository RREP, IConstructionRepository OREP, IParticipantRepository PAREP,
            IReportRepository RELREP, ICommentRepository COREP)
        {
            _PPREP = PPREP;
            _RREP = RREP;
            _OREP = OREP;
            _PAREP = PAREP;
            _RELREP = RELREP;
            _COREP = COREP;
        }

        public async Task<ICommandResult> Handler(InsertConstructionCommandInput command)
        {
            var proprietario = _PPREP.GetId(command.OwnerId);
            var residente = _RREP.GetCREA(command.ResidentCrea);
            var fiscal1 = _RREP.GetCREA(command.Fiscal1Crea);
            var fiscal2 = _RREP.GetCREA(command.Fiscal2Crea);
            var address = new Address(command.Street, command.District, command.Number);

            await Task.WhenAll(proprietario, residente, fiscal1, fiscal2);

            var construction = new Construction(command.Name, address, proprietario.Result, command.StartDate, command.FinalDate);
            var responsavel = new Responsible();

            construction.OptionalInformation(command.Image, residente.Result, fiscal1.Result, fiscal2.Result);

            foreach (var item in command.creas)
            {
                responsavel = await _RREP.GetCREA(item);

                construction.AddResponsible(responsavel);
            }
            foreach (var item in construction.Responsibles)
                _PAREP.Insert(item.Id, construction.Id);

            if(construction.Invalid)
                return new CommandResult(construction.Notifications);

            _OREP.Insert(construction);

            return new CommandResult("Projeto de Construction Cadastrada com Sucesso !");
        }

        public async Task<ICommandResult> Handler(UpdateConstructionCommandInput command)
        {
            var construction = _OREP.GetId(command.ConstructionId);
            var residente = _RREP.GetCREA(command.ResidentCrea);
            var fiscal1 = _RREP.GetCREA(command.Fiscal1Crea);
            var fiscal2 = _RREP.GetCREA(command.Fiscal2Crea);
            await Task.WhenAll(construction, residente, fiscal1, fiscal2);
            construction.Result.OptionalInformation(command.Image, residente.Result, fiscal1.Result, fiscal2.Result);
            construction.Result.Update(command.Name, command.Image, command.FinalDate);

            if (construction.Result.Invalid)
                return new CommandResult(construction.Result.Notifications);

            await AddResponsaveis(command.creas, construction.Result);

            _OREP.Update(construction.Result);

            return new CommandResult("Projeto de Construction Editado com Sucesso !");
        }

        public async Task AddResponsaveis(string[] creas, Construction construction)
        {
            List<Responsible> responsaveis = new List<Responsible>();
            var responsaveisBanco = await _PAREP.GetConstructionId(construction.Id);
            foreach (var item in creas)
            {
                var responsavel = await _RREP.GetCREA(item);
                responsaveis.Add(responsavel);
            }

            foreach (var item in responsaveis)
                if (!responsaveisBanco.Contains(item))
                    construction.AddResponsible(item);

            foreach (var item in construction.Responsibles)
                _PAREP.Insert(item.Id, construction.Id);

        }

        public async Task<ICommandResult> Handler(InsertCommentCommandInput command)
        {

            var report = _RELREP.GetId(command.ReportId);
            var responsavel = _RREP.GetId(command.ResponsibleId);
            await Task.WhenAll(report, responsavel);
            var comment = new Comment(report.Result, responsavel.Result, command.Title, command.Description);

            if (comment.Invalid)
                return new CommandResult(comment.Notifications);

            _COREP.Insert(comment);

            return new CommandResult("Comentário incluído com sucesso!");
        }

        public async Task<ICommandResult> Handler(UpdateCommentCommandInput command)
        {
            var comment = await _COREP.GetId(command.CommentId);

            if (comment.Invalid)
                return new CommandResult(comment.Notifications);

            _COREP.Update(comment);

            return new CommandResult("Comentário atualizado com sucesso!");

        }


        public async Task<IEnumerable<Construction>> ListOwner(Guid proprietarioId)
        {
            var constructions = await _OREP.ListOwnerId(proprietarioId);

            return constructions;
        }

    }
}
