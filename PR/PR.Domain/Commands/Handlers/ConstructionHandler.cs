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
using Flunt.Notifications;
using PR.Domain.Helper;

namespace PR.Domain.Commands.Handlers
{
    public class ConstructionHandler : ICommandHandler<InsertConstructionCommandInput>,
                                ICommandHandler<UpdateConstructionCommandInput>


    {
        private readonly IOwnerRepository _PPREP;
        private readonly IResponsibleRepository _RREP;
        private readonly IConstructionRepository _OREP;
        private readonly IParticipantRepository _PAREP;


        public ConstructionHandler(IOwnerRepository PPREP, IResponsibleRepository RREP,
            IConstructionRepository OREP, IParticipantRepository PAREP)
        {
            _PPREP = PPREP;
            _RREP = RREP;
            _OREP = OREP;
            _PAREP = PAREP;
        }

        public async Task<ICommandResult> Handler(InsertConstructionCommandInput command)
        {
            var proprietario = _PPREP.GetById(command.OwnerId);
            var residente = _RREP.GetByCREA(command.ResidentCrea);
            var fiscal1 = _RREP.GetByCREA(command.Fiscal1Crea);
            var fiscal2 = _RREP.GetByCREA(command.Fiscal2Crea);
            var address = new Address(command.Street, command.District, command.Number);

            await Task.WhenAll(proprietario, residente, fiscal1, fiscal2);

            var construction = new Construction(command.Name, address, proprietario.Result, command.StartDate, command.FinalDate);
            var responsavel = new Responsible();

            construction.OptionalInformation(command.Image, residente.Result, fiscal1.Result, fiscal2.Result);

            foreach (var item in command.creas)
            {
                responsavel = await _RREP.GetByCREA(item);

                construction.AddResponsible(responsavel);
            }

            if (construction.Invalid)
            {
                return new CommandResult(_BuildResult.BuildResult(construction.Notifications).Result);
            }

            foreach (var item in construction.Responsibles)
                _PAREP.Insert(item.Id, construction.Id);

            _OREP.Insert(construction);

            return new CommandResult(new string[] { "Projeto de Construction Cadastrada com Sucesso !" });
        }

        public async Task<ICommandResult> Handler(UpdateConstructionCommandInput command)
        {
            var construction = _OREP.GetById(command.ConstructionId);
            var residente = _RREP.GetByCREA(command.ResidentCrea);
            var fiscal1 = _RREP.GetByCREA(command.Fiscal1Crea);
            var fiscal2 = _RREP.GetByCREA(command.Fiscal2Crea);
            await Task.WhenAll(construction, residente, fiscal1, fiscal2);
            construction.Result.OptionalInformation(command.Image, residente.Result, fiscal1.Result, fiscal2.Result);
            construction.Result.Update(command.Name, command.Image, command.FinalDate);

            if (construction.Result.Invalid)
                return new CommandResult(_BuildResult.BuildResult(construction.Result.Notifications).Result);

            await AddResponsaveis(command.creas, construction.Result);

            _OREP.Update(construction.Result);

            return new CommandResult(new string[] { "Projeto de Construction Editado com Sucesso !" });
        }

        public async Task AddResponsaveis(string[] creas, Construction construction)
        {
            List<Responsible> responsaveis = new List<Responsible>();
            var responsaveisBanco = await _PAREP.ListResponsibleByConstructionId(construction.Id);
            foreach (var item in creas)
            {
                var responsavel = await _RREP.GetByCREA(item);
                responsaveis.Add(responsavel);
            }

            foreach (var item in responsaveis)
                if (!responsaveisBanco.Contains(item))
                    construction.AddResponsible(item);

            foreach (var item in construction.Responsibles)
                _PAREP.Insert(item.Id, construction.Id);

        }

        public async Task<Construction> GetById(Guid Id)
        {
            var construction = await _OREP.GetById(Id);
            return construction;
        }
        public async Task<IEnumerable<Construction>> ListByOwnerId(Guid proprietarioId)
        {
            var constructions = await _OREP.ListByOwnerId(proprietarioId);

            return constructions;
        }
    }
}
