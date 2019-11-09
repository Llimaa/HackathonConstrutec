using PR.Domain.Commands.Inputs;
using PR.Domain.Commands.Result;
using PR.Domain.Entidades;
using PR.Domain.ObjetosValor;
using PR.Domain.Repositories;
using PR.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR.Domain.Commands.Handlers
{
    public class ObraHandler : ICommandHandler<InsertObraCommandInput>,
                                ICommandHandler<UpdateObraCommandInput>,
                                ICommandHandler<InsertProprietarioCommandInput>,
                                ICommandHandler<UpdateProprietarioCommandInput>
    {
        private readonly IProprietarioRepository _PPREP;
        private readonly IResponsavelRepository _RREP;
        private readonly IObraRepository _OREP;
        private readonly IParticipanteRepository _PAREP;

        public ObraHandler(IProprietarioRepository PPREP, IResponsavelRepository RREP, IObraRepository OREP, IParticipanteRepository PAREP)
        {
            _PPREP = PPREP;
            _RREP = RREP;
            _OREP = OREP;
            _PAREP = PAREP;
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

            obra.InfomacaoOpcional(command.Imagem, residente, fiscal1, fiscal2);

            foreach (var item in command.creas)
            {
                responsavel = await _RREP.BuscarPorCREA(item);

                obra.AdicionarResponsavel(responsavel);
            }
            foreach (var item in obra.Responsaveis)
                _PAREP.Inserir(item.Id, obra.Id);


            _OREP.Inserir(obra);

            return new CommandResult("Projeto de Obra Cadastrada com Sucesso !");
        }

        public async Task<ICommandResult> Handler(UpdateObraCommandInput command)
        {
            var obra = await _OREP.BuscarPorId(command.ObraId);
            var residente = await _RREP.BuscarPorCREA(command.ResidenteCrea);
            var fiscal1 = await _RREP.BuscarPorCREA(command.Fiscal1Crea);
            var fiscal2 = await _RREP.BuscarPorCREA(command.Fiscal2Crea);

            obra.InfomacaoOpcional(command.Imagem, residente, fiscal1, fiscal2);
            obra.Update(command.Nome, command.Imagem, command.DataEncerramento);

            await AddResponsaveis(command.creas, obra);

            _OREP.Atualizar(obra);

            return new CommandResult("Projeto de Obra Editado com Sucesso !");
        }

        public async Task AddResponsaveis(string[] creas, Obra obra)
        {
            List<Responsavel> responsaveis = new List<Responsavel>();
            var responsaveisBanco = await _PAREP.BuscarPorObraId(obra.Id);
            foreach (var item in creas)
            {
                var responsavel = await _RREP.BuscarPorCREA(item);
                responsaveis.Add(responsavel);
            }

            foreach (var item in responsaveis)
                if (!responsaveisBanco.Contains(item))
                    obra.AdicionarResponsavel(item);

            foreach (var item in obra.Responsaveis)
                _PAREP.Inserir(item.Id, obra.Id);

        }

        public async Task<ICommandResult> Handler(InsertProprietarioCommandInput command)
        {
            var endereco = new Endereco(command.Rua, command.Bairro, command.Numero);
            var proprietario = new Proprietario(command.Nome, command.Telefone, command.Email, endereco);

            _PPREP.Inserir(proprietario);

           return new CommandResult("Proprietário cadastrado com Sucesso!");
        }

        public async Task<ICommandResult> Handler(UpdateProprietarioCommandInput command)
        {
            var proprietario = await _PPREP.BuscarPorId(command.ProprietarioId);

            proprietario.Update(command.Nome, command.Telefone, command.Email);

            _PPREP.Atualizar(proprietario);

            return new CommandResult("Proprietário atualizado com Sucesso!");
        }
    }
}
