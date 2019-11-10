using PR.Domain.Commands.Inputs;
using PR.Domain.Commands.Result;
using PR.Domain.Entities;
using PR.Domain.ValueObjects;
using PR.Domain.Repositories;
using PR.Shared.Commands;
using System;
using System.Threading.Tasks;
using PR.Domain.Helper;

namespace PR.Domain.Commands.Handlers
{
    public class OwnerHandler : ICommandHandler<InsertOwnerCommandInput>,
                                       ICommandHandler<UpdateOwnerCommandInput>

    {
        private readonly IOwnerRepository _PREP;

        public OwnerHandler(IOwnerRepository PREP)
        {
            _PREP = PREP;
        }

        public async Task<ICommandResult> Handler(InsertOwnerCommandInput command)
        {
            var address = new Address(command.Street, command.District, command.Number);
            var proprietario = new Owner(command.Name, command.Phone, command.Email, address);

            var result = _BuildResult.BuildResult(proprietario.Notifications);
            if (proprietario.Invalid)
                return new CommandResult(result);

            _PREP.Insert(proprietario);

            return new CommandResult(new string[] { "Proprietário cadastrado com Sucesso!" });
        }
        public async Task<ICommandResult> Handler(UpdateOwnerCommandInput command)
        {
            var proprietario = await _PREP.GetById(command.OwnerId);

            proprietario.Update(command.Name, command.Phone, command.Email);

            if (proprietario.Invalid)
                return new CommandResult(_BuildResult.BuildResult(proprietario.Notifications));

            _PREP.Update(proprietario);

            return new CommandResult(new string[] { "Proprietário atualizado com Sucesso!" });
        }

        public async Task<Owner> ListOwner(Guid Id)
        {
            return await _PREP.GetById(Id);
        }
    }
}
