using Dapper;
using PR.Domain.Entities;
using PR.Domain.Repositories;
using PR.Infra.Infra;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PR.Infra.Repositories
{
    public class ParticipantRepository : IParticipantRepository
    {
        private readonly IDB _DB;

        public ParticipantRepository(IDB DB)
        {
            _DB = DB;
        }

        public void Insert(Guid responsavelId, Guid obraId)
        {
            var sql = "INSERT INTO Participant" +
                "(ResponsibleId,ConstructionId)" +
                "VALUES" +
                "(@responsavelId,@obraId)";
            using (var db = _DB.GetCon())
            {
                db.Execute(sql, new
                {
                    responsavelId,
                    obraId
                });
            }
        }

        public async Task<IEnumerable<Construction>> ListConstructionByResponsibleId(Guid responsableId)
        {
            var sql = "SELECT * FROM Construction " +
                " INNER JOIN Participant ON Construction.Id = Participant.ConstructionId" +
                " WHERE Participant.ResponsibleId = @responsableId";
            using (var db = _DB.GetCon())
            {
                var constructions = await db.QueryAsync<Construction>(sql,new { responsableId});
                return constructions;
            }
        }

        public async Task<IEnumerable<Responsible>> ListResponsibleByConstructionId(Guid constructionId)
        {
            var sql = "SELECT * FROM Responsible " +
               " INNER JOIN Participant ON Responsible.Id = Participant.ResponsibleId" +
               " WHERE Participant.ConstructionId = @constructionId";
            using (var db = _DB.GetCon())
            {
                var constructions = await db.QueryAsync<Responsible>(sql, new { constructionId });
                return constructions;
            }
        }
    }
}
