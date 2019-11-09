using PR.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PR.Domain.Repositories
{
    public interface IResponsavelRepository
    {
        void Inserir(Responsavel responsavel);
        void Atualizar(Responsavel responsavel);
        Task<Responsavel> BuscarPorCREA(string crea);
        Task<Responsavel> BuscarPorId(Guid Id);
    }
}
