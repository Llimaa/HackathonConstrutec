﻿using Microsoft.AspNetCore.Mvc;
using PR.Domain.Commands.Handlers;
using PR.Domain.Commands.Inputs;
using PR.Domain.Entities;
using PR.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConstructionController : ControllerBase
    {
        ConstructionHandler ConstructionHandler;
        public ConstructionController(ConstructionHandler constructionHandler)
        {
            ConstructionHandler = constructionHandler;

        }

        // POST: api/ConstructionAPI
        [HttpPost]
        public async Task<ICommandResult> Post([FromBody] InsertConstructionCommandInput value)
        {
            var result  = await ConstructionHandler.Handler(value);
            return result;
        }

        // PUT: api/ConstructionAPI/5
        [HttpPut]
        public async Task<ICommandResult> Put([FromBody] UpdateConstructionCommandInput value)
        {
            var result = await ConstructionHandler.Handler(value);
            return result;
        }
    }
}
