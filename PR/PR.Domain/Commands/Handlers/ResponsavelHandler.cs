using PR.Domain.Commands.Inputs;
using PR.Domain.Commands.Result;
using PR.Domain.Entidades;
using PR.Domain.Repositories;
using PR.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PR.Domain.Commands.Handlers
{
    public class ResponsavelHandler : ICommandHandler<InsertResponsavelCommandInput>,
                                    ICommandHandler<UpdateResponsavelCommandInput>
    {
        private readonly IResponsavelRepository _RREP;
        public async Task<ICommandResult> Handler(InsertResponsavelCommandInput command)
        {
            var resul = _RREP.BuscarPorCREA(command.CREA);
            var responsavel = new Responsavel(command.Nome, command.CREA, command.Email, command.Telefone);

            if (!resul.Result.CREA.Contains(responsavel.CREA))
                _RREP.Inserir(responsavel);

            return new CommandResult("Responsavel cadastrado com sucesso!");


        }
        public Task<ICommandResult> Handler(UpdateResponsavelCommandInput command)
        {
            var responsavel = _RREP.BuscarPorId(command.Id);
            

        }

        public async Task<Responsavel> ListarPorId(Guid Id)
        {
            return await _RREP.BuscarPorId(Id);
        }

        public async Task<Responsavel> ListarPorCREA(string crea)
        {
            return await _RREP.BuscarPorCREA(crea);
        }
    }
}
