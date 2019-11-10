using Dapper;
using PR.Domain.Entities;
using PR.Domain.Repositories;
using PR.Infra.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var sql = "SELECT * FROM Responsible WHERE CREA = @crea";
            using (var db = _DB.GetCon())
            {
                var responsible = await db.QueryAsync<Responsible>(sql, new { crea });
                return responsible.FirstOrDefault();
            }
        }

        public async Task<Responsible> GetById(Guid Id)
        {
            var sql = "SELECT * FROM Responsible WHERE Id = @Id";
            using (var db = _DB.GetCon())
            {
                var responsible = await db.QueryAsync(sql, new { Id });
                return responsible.FirstOrDefault();
            }
        }

        public void Insert(Responsible responsavel)
        {
            var sql = "INSERT INTO Responsible" +
                " (Id,Name,CREA,Email,Phone)" +
                " VALUES" +
                " (@Id,@Name,@CREA,@Email,@Phone)";
            using (var db = _DB.GetCon())
            {
                db.Execute(sql,responsavel);
            }
        }

        public void Update(Responsible responsavel)
        {
            var sql = "UPDATE Responsible SET " +
                "Name = @Name" +
               ",Email = @Email" +
               ",Phone = @Phone" +
               " WHERE Id = @Id";
            using (var db = _DB.GetCon())
            {
                db.Execute(sql, responsavel);
            }
        }
    }
}
