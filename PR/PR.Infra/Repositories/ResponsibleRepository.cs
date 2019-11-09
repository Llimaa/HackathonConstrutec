using PR.Domain.Entities;
using PR.Domain.Repositories;
using PR.Infra.Infra;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PR.Infra.Repositories
{
    public class ResponsibleRepository : IResponsibleRepository
    {
        private readonly IDB _DB;

        public ResponsibleRepository(IDB DB)
        {
            _DB = DB;
        }

        public async Task<Responsible> GetByCREA(string crea)
        {
            var sql = "";
            using (var db = _DB.GetCon())
            {

            }
            throw new NotImplementedException();
        }

        public async Task<Responsible> GetById(Guid Id)
        {
            var sql = "";
            using (var db = _DB.GetCon())
            {

            }
            throw new NotImplementedException();
        }

        public void Insert(Responsible responsavel)
        {
            var sql = "";
            using (var db = _DB.GetCon())
            {

            }
            throw new NotImplementedException();
        }

        public void Update(Responsible responsavel)
        {
            var sql = "";
            using (var db = _DB.GetCon())
            {

            }
            throw new NotImplementedException();
        }
    }
}
