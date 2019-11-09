using Microsoft.AspNetCore.Mvc;
using PR.Domain.Commands.Handlers;
using PR.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportByConstructionController : ControllerBase
    {
        private readonly ReportHandler _handler;

        public ReportByConstructionController(ReportHandler handler)
        {
            _handler = handler;
        }

        [HttpGet("{constructionId}")]
        public async Task<IEnumerable<Report>> Get(Guid constructionId)
        {
            var report = await _handler.ListConstruction(constructionId);

            return report;
        }
    }
}
