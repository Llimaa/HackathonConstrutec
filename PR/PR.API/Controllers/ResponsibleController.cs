using Microsoft.AspNetCore.Mvc;
using PR.Domain.Commands.Handlers;
using PR.Domain.Commands.Inputs;
using PR.Domain.Entities;
using PR.Shared.Commands;
using System;
using System.Threading.Tasks;

namespace PR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResponsibleController : ControllerBase
    {
        ResponsibleHandler ResponsibleHandler;
        public ResponsibleController(ResponsibleHandler constructionHandler)
        {
            ResponsibleHandler = constructionHandler;

        }

        // GET: api/Responsible/Id
        [HttpGet("{Id}")]
        public async Task<Responsible> Get(Guid Id)
        {
            var ListResponsible = await ResponsibleHandler.ListId(Id);
            return ListResponsible;
        }

        // GET: api/Responsible/crea
        [HttpGet("{crea}")]
        public async Task<Responsible> Get(string crea)
        {
            var ListResponsible = await ResponsibleHandler.ListCREA(crea);
            return ListResponsible;
        }

        // POST: api/Responsible/InsertResponsibleCommandInput
        [HttpPost]
        public async Task<ICommandResult> Post([FromBody] InsertResponsibleCommandInput value)
        {
            var result  = await ResponsibleHandler.Handler(value);
            return result;
        }

        // PUT: api/Responsible/UpdateResponsibleCommandInput
        [HttpPut]
        public async Task<ICommandResult> Put([FromBody] UpdateResponsibleCommandInput value)
        {
            var result = await ResponsibleHandler.Handler(value);
            return result;
        }
    }
}
