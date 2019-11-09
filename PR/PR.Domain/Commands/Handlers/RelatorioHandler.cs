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
    public class RelatorioHandler : ICommandHandler<InsertRelatoriosCommandInput>,
                                    ICommandHandler<UpdateRelatorioCommandInput>
    {
        private readonly IResponsavelRepository _RREP;
        private readonly IObraRepository _OREP;
        private readonly IRelatorioRepository _RLREP;

        public RelatorioHandler(IResponsavelRepository RREP, IObraRepository OREP, IRelatorioRepository RLREP)
        {
            _RREP = RREP;
            _OREP = OREP;
            _RLREP = RLREP;
        }

        public async Task<ICommandResult> Handler(InsertRelatoriosCommandInput command)
        {
            var obra = await _OREP.BuscarPorId(command.ObraId);
            var responsavel = await _RREP.BuscarPorId(command.ResponsavelId);
            var relatorio = new Relatorio(command.Titulo, command.Imagem, command.Descricao, responsavel, obra);


            _RLREP.Inserir(relatorio);

            return new CommandResult("Relatorio inserido com Sucesso !!");
        }

        public async Task<ICommandResult> Handler(UpdateRelatorioCommandInput command)
        {
            var relatorio = await _RLREP.BuscarPorId(command.RelarorioId);

            relatorio.Update(command.Titulo, command.Imagem, command.Descricao);

            _RLREP.Atualizar(relatorio);


            return new CommandResult("Relatorio editado com Sucesso !!");
        }
    }
}
