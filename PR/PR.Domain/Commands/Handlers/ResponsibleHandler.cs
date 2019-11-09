using PR.Domain.Commands.Inputs;
using PR.Domain.Commands.Result;
using PR.Domain.Entities;
using PR.Domain.Repositories;
using PR.Shared.Commands;
using System;
using System.Threading.Tasks;

namespace PR.Domain.Commands.Handlers
{
    public class ResponsibleHandler : ICommandHandler<InsertResponsibleCommandInput>,
                                    ICommandHandler<UpdateResponsibleCommandInput>
    {
        private readonly IResponsibleRepository _RREP;
        public ResponsibleHandler(IResponsibleRepository RREP)
        {
            _RREP = RREP;          
        }
        public async Task<ICommandResult> Handler(InsertResponsibleCommandInput command)
        {
            var resul = _RREP.GetCREA(command.CREA);
            var responsavel = new Responsible(command.Name, command.CREA, command.Email, command.Phone);

            if (!resul.Result.CREA.Contains(responsavel.CREA))
                _RREP.Insert(responsavel);

            return new CommandResult("Responsible cadastrado com sucesso!");


        }
        public async Task<ICommandResult> Handler(UpdateResponsibleCommandInput command)
        {
            var responsavel = await _RREP.GetId(command.Id);
            responsavel.Update(command.Name, command.Email, command.Phone);

            _RREP.Update(responsavel);

            return new CommandResult("Responsável atualizado com sucesso !");
        }

        public async Task<Responsible> ListId(Guid Id)
        {
            return await _RREP.GetId(Id);
        }

        public async Task<Responsible> ListCREA(string crea)
        {
            return await _RREP.GetCREA(crea);
        }
    }
}
