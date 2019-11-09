using Microsoft.AspNetCore.Mvc;
using PR.Domain.Commands.Handlers;
using PR.Domain.Commands.Inputs;
using PR.Shared.Commands;
using System.Threading.Tasks;

namespace PR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        ReportHandler ReportHandler;
        public ReportController(ReportHandler constructionHandler)
        {
            ReportHandler = constructionHandler;

        }

        // POST: api/Report/InsertReportCommandInput
        [HttpPost]
        public async Task<ICommandResult> Post([FromBody] InsertReportCommandInput value)
        {
            var result  = await ReportHandler.Handler(value);
            return result;
        }

        // PUT: api/Report/UpdateReportCommandInput
        [HttpPut]
        public async Task<ICommandResult> Put([FromBody] UpdateReportCommandInput value)
        {
            var result = await ReportHandler.Handler(value);
            return result;
        }
    }
}
