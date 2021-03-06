﻿using Microsoft.AspNetCore.Mvc;
using PR.Domain.Commands.Handlers;
using PR.Domain.Commands.Inputs;
using PR.Shared.Commands;
using System.Threading.Tasks;

namespace PR.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ConstructionController : ControllerBase
    {
        ConstructionHandler ConstructionHandler;
        public ConstructionController(ConstructionHandler constructionHandler)
        {
            ConstructionHandler = constructionHandler;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        // POST: api/Construction/InsertConstructionCommandInput
        [HttpPost]
        public async Task<ICommandResult> Post([FromBody] InsertConstructionCommandInput value)
        {
            var result  = await ConstructionHandler.Handler(value);
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        // PUT: api/Construction/UpdateConstructionCommandInput
        [HttpPut]
        public async Task<ICommandResult> Put([FromBody] UpdateConstructionCommandInput value)
        {
            var result = await ConstructionHandler.Handler(value);
            return result;
        }
    }
}
