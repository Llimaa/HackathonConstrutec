using Microsoft.AspNetCore.Mvc;
using PR.Domain.Commands.Handlers;
using PR.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PR.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ReportByConstructionController : ControllerBase
    {
        private readonly ReportHandler ReportHandler;

        public ReportByConstructionController(ReportHandler reportHandler)
        {
            ReportHandler = reportHandler;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="constructionId"></param>
        /// <returns></returns>
        // GET: api/ReportByConstruction/constructionId
        [HttpGet("{constructionId}")]
        public async Task<IEnumerable<Report>> Get(Guid constructionId)
        {
            var report = await ReportHandler.ListByConstructionId(constructionId);

            return report;
        }
    }
}
