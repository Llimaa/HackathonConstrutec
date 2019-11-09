using PR.Domain.Commands.Inputs;
using PR.Domain.Commands.Result;
using PR.Domain.Entities;
using PR.Domain.ValueObjects;
using PR.Domain.Repositories;
using PR.Shared.Commands;
using System;
using System.Threading.Tasks;

namespace PR.Domain.Commands.Handlers
{
    public class OwnerHandler : ICommandHandler<InsertOwnerCommandInput>,
                                       ICommandHandler<UpdateOwnerCommandInput>

    {
        private readonly IOwnerRepository _PREP;
        public async Task<ICommandResult> Handler(InsertOwnerCommandInput command)
        {
            var address = new Address(command.Street, command.District, command.Number);
            var proprietario = new Owner(command.Name, command.Phone, command.Email, address);

            _PREP.Insert(proprietario);

            return new CommandResult("Proprietário cadastrado com Sucesso!");
        }
        public async Task<ICommandResult> Handler(UpdateOwnerCommandInput command)
        {
            var proprietario = await _PREP.GetId(command.OwnerId);

            proprietario.Update(command.Name, command.Phone, command.Email);

            _PREP.Update(proprietario);

            return new CommandResult("Proprietário atualizado com Sucesso!");
        }

        public async Task<Owner> ListOwner(Guid Id)
        {
            return await _PREP.GetId(Id);
        }
    }
}
