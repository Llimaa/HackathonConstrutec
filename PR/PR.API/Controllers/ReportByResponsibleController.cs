using Microsoft.AspNetCore.Mvc;
using PR.Domain.Commands.Handlers;
using PR.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PR.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ReportByResponsibleController : ControllerBase
    {
        private readonly ReportHandler _handler;

        public ReportByResponsibleController(ReportHandler handler)
        {
            _handler = handler;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="responsibleId"></param>
        /// <returns></returns>
        // GET: api/ReportByResponsible/responsibleId
        [HttpGet("{responsibleId}")]
        public async Task<IEnumerable<Report>> Get(Guid responsibleId)
        {
            var report = await _handler.ListByResponsibleId(responsibleId);

            return report;
        }
    }
}
