using Microsoft.AspNetCore.Mvc;
using PR.Domain.Commands.Handlers;
using PR.Domain.Commands.Inputs;
using PR.Domain.Entities;
using PR.Shared.Commands;
using System;
using System.Threading.Tasks;

namespace PR.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        OwnerHandler OwnerHandler;
        public OwnerController(OwnerHandler constructionHandler)
        {
            OwnerHandler = constructionHandler;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        // GET: api/Owner/Id
        [HttpGet("{Id}")]
        public async Task<Owner> Get(Guid Id)
        {
            var ListOwner = await OwnerHandler.ListOwner(Id);
            return ListOwner;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        // POST: api/Owner/InsertOwnerCommandInput
        [HttpPost]
        public async Task<ICommandResult> Post([FromBody] InsertOwnerCommandInput value)
        {
            var result  = await OwnerHandler.Handler(value);
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        // PUT: api/Owner/UpdateOwnerCommandInput
        [HttpPut]
        public async Task<ICommandResult> Put([FromBody] UpdateOwnerCommandInput value)
        {
            var result = await OwnerHandler.Handler(value);
            return result;
        }
    }
}
