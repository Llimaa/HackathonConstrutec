using PR.Domain.Commands.Inputs;
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
        public Task<ICommandResult> Handler(InsertResponsavelCommandInput command)
        {
            throw new NotImplementedException();
        }
        public Task<ICommandResult> Handler(UpdateResponsavelCommandInput command)
        {
            throw new NotImplementedException();
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
