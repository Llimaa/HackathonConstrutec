using Microsoft.AspNetCore.Mvc;
using PR.Domain.Commands.Handlers;
using PR.Domain.Commands.Inputs;
using PR.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConstructionAPIController : ControllerBase
    {
        ConstructionHandler ConstructionHandler;
        public ConstructionAPIController(ConstructionHandler constructionHandler)
        {
            ConstructionHandler = constructionHandler;

        }
        // GET: api/ConstructionAPI
        [HttpGet("{proprietarioId}")]
        public async Task<IEnumerable<Construction>> Get(Guid proprietarioId)
        {
            var ListConstruction = await ConstructionHandler.ListOwner(proprietarioId);
            return ListConstruction;
        }

        // POST: api/ConstructionAPI
        [HttpPost]
        public async Task<object> Post([FromBody] InsertConstructionCommandInput value)
        {
            return ConstructionHandler.Handler(value);
        }

        // PUT: api/ConstructionAPI/5
        [HttpPut]
        public async Task<object> Put([FromBody] UpdateConstructionCommandInput value)
        {
            return ConstructionHandler.Handler(value);
        }
    }
}
