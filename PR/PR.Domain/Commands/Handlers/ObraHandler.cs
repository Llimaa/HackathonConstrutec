using PR.Domain.Commands.Inputs;
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
    public class ObraHandler : ICommandHandler<InsertObraCommandInput>
    {
        private readonly IProprietarioRepository _PPREP;
        private readonly IResponsavelRepository _RREP;
        private readonly IObraRepository _OREP;

        public ObraHandler(IProprietarioRepository PPREP, IResponsavelRepository RREP, IObraRepository OREP)
        {
            _PPREP = PPREP;
            _RREP = RREP;
            _OREP = OREP;
        }

        public async Task<ICommandResult> Handler(InsertObraCommandInput command)
        {
            var proprietario = await _PPREP.BuscarPorId(command.ProprietarioId);
            var residente = await _RREP.BuscarPorCREA(command.ResidenteCrea);
            var fiscal1 = await _RREP.BuscarPorCREA(command.Fiscal1Crea);
            var fiscal2 = await _RREP.BuscarPorCREA(command.Fiscal2Crea);
            var endereco = new Endereco(command.Rua, command.Bairro, command.Numero);
            var obra = new Obra(command.Nome, endereco, proprietario, command.DataInicio, command.DataEncerramento);
            var responsavel = new Responsavel();
            foreach (var item in command.creas)
            {
                responsavel = await _RREP.BuscarPorCREA(item);

                obra.AdicionarResponsavel(responsavel);
            }

            obra.InfomacaoOpcional(command.Imagem, residente, fiscal1, fiscal2);

            throw new NotImplementedException();
        }
    }
}
