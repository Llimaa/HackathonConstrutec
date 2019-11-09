using PR.Domain.Commands.Inputs;
using PR.Domain.Commands.Result;
using PR.Domain.Entidades;
using PR.Domain.ObjetosValor;
using PR.Domain.Repositories;
using PR.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PR.Domain.Commands.Handlers
{
    public class ProprietarioHandler : ICommandHandler<InsertProprietarioCommandInput>,
                                       ICommandHandler<UpdateProprietarioCommandInput>

    {
        private readonly IProprietarioRepository _PREP;
        public async Task<ICommandResult> Handler(InsertProprietarioCommandInput command)
        {
            var endereco = new Endereco(command.Rua, command.Bairro, command.Numero);
            var proprietario = new Proprietario(command.Nome, command.Telefone, command.Email, endereco);

            _PREP.Inserir(proprietario);

            return new CommandResult("Proprietário cadastrado com Sucesso!");
        }
        public async Task<ICommandResult> Handler(UpdateProprietarioCommandInput command)
        {
            var proprietario = await _PREP.BuscarPorId(command.ProprietarioId);

            proprietario.Update(command.Nome, command.Telefone, command.Email);

            _PREP.Atualizar(proprietario);

            return new CommandResult("Proprietário atualizado com Sucesso!");
        }

        public async Task<Proprietario> ListarProprietario(Guid Id)
        {
            return await _PREP.BuscarPorId(Id);
        }
    }
}
