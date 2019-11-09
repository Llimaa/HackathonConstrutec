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
    public class OwnerRepository : IOwnerRepository
    {
        private readonly IDB _DB;

        public OwnerRepository(IDB DB)
        {
            _DB = DB;
        }

        public async Task<Owner> GetById(Guid Id)
        {
            var sql = "SELECT * FROM WHERE Id = @Id";
            using (var db = _DB.GetCon())
            {
                var owner = await db.QueryAsync(sql, new { Id });
                return owner.FirstOrDefault();
            }
        }

        public void Insert(Owner proprietario)
        {
            var sql = "INSERT INTP Owner " +
                "(Id,Name,Phone,Email,Street,District,Number)" +
                "VALUES" +
                "(@Id,@Name,@Phone,@Email,@Street,@District,@Number)";
            using (var db = _DB.GetCon())
            {
                db.Execute(sql, new
                {
                    proprietario.Id,
                    proprietario.Name,
                    proprietario.Phone,
                    proprietario.Email,
                    proprietario.Address.Street,
                    proprietario.Address.District,
                    proprietario.Address.Number
                });
            }
        }

        public void Update(Owner proprietario)
        {
            var sql = "UPDATE Owner SET " +
                "Name = @Name " +
               ",Phone = @Phone" +
               ",Email = @Email" +
               ",Street = @Street" +
               ",District = @District" +
               ",Number = @Number";
            using (var db = _DB.GetCon())
            {
                db.Execute(sql, new
                {
                    proprietario.Id,
                    proprietario.Name,
                    proprietario.Phone,
                    proprietario.Email,
                    proprietario.Address.Street,
                    proprietario.Address.District,
                    proprietario.Address.Number
                });
            }
        }
    }
}
