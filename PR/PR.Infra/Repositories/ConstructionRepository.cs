using Dapper;
using PR.Domain.Entities;
using PR.Domain.Repositories;
using PR.Infra.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PR.Infra.Repositories
{
    public class ConstructionRepository : IConstructionRepository
    {
        private readonly IDB _DB;

        public ConstructionRepository(IDB DB)
        {
            _DB = DB;
        }

        public async Task<Construction> GetById(Guid Id)
        {
            var sql = "SELECT * FROM Construction WHERE Id = @Id";
            using (var db = _DB.GetCon())
            {
                var construction = await db.QueryAsync(sql, new { Id });
                return construction.FirstOrDefault();
            }
        }

        public void Insert(Construction construction)
        {
            var sql = "INSERT INTO Construction " +
                "(Id,OwnerId,ResidentId,Fiscal1Id,Fiscal2Id,Name,Image,EStatusConstruction,Street,District,Number,StartDate,FinalDate) " +
                "VALUES " +
                "(@Id,@OwnerId,@ResidentId,@Fiscal1Id,@Fiscal2Id,@Name,@Image,@EStatusConstruction,@Street,@District,@Number,@StartDate,@FinalDate) ";
            using (var db = _DB.GetCon())
            {
                db.Execute(sql, new
                {
                    construction.Id,
                    construction.Name,
                    construction.Image,
                    construction.EStatusConstruction,
                    OwnerId = construction.Owner.Id,
                    ResidentId = construction.Resident.Id,
                    Fiscal1Id = construction.Fiscal1.Id,
                    Fiscal2Id = construction.Fiscal2.Id,
                    construction.Address.Street,
                    construction.Address.District,
                    construction.Address.Number,
                    construction.StartDate,
                    construction.FinalDate
                });
            }
        }

        public async Task<IEnumerable<Construction>> ListByOwnerId(Guid ownerId)
        {
            var sql = "SELECT * FROM Construction WHERE Owner = @ownerId";
            using (var db = _DB.GetCon())
            {
                var construction = await db.QueryAsync<Construction>(sql, new { ownerId });
                return construction;
            }
        }

        public void Update(Construction construction)
        {
            var sql = "UPDATE Construction SET " +
                "Name = @Name " +
               ",Image = @Image " +
               ",EStatusConstruction = @EStatusConstruction" +
               ",ResidentId = @ResidentId" +
               ",Fiscal1Id = @Fiscal1Id" +
               ",Fiscal2Id = @Fiscal2Id" +
               ",Street = @Street" +
               ",District = @District" +
               ",Number = @Number" +
               ",FinalDate = @FinalDate" +
               " WHERE Id = @Id";
            using (var db = _DB.GetCon())
            {
                db.Execute(sql, new
                {
                    construction.Id,
                    construction.Name,
                    construction.Image,
                    construction.EStatusConstruction,
                    OwnerId = construction.Owner.Id,
                    ResidentId = construction.Resident.Id,
                    Fiscal1Id = construction.Fiscal1.Id,
                    Fiscal2Id = construction.Fiscal2.Id,
                    construction.Address.Street,
                    construction.Address.District,
                    construction.Address.Number,
                    construction.FinalDate
                });
            }
        }
    }
}
