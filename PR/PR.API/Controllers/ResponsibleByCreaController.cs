using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PR.Domain.Commands.Handlers;
using PR.Domain.Entities;

namespace PR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResponsibleByCreaController : ControllerBase
    {
        ResponsibleHandler ResponsibleHandler;

        public ResponsibleByCreaController(ResponsibleHandler responsibleHandler)
        {
            ResponsibleHandler = responsibleHandler;
        }


        // GET: api/Responsible/crea
        [HttpGet("{crea}")]
        public async Task<Responsible> Get(string crea)
        {
            var ListResponsible = await ResponsibleHandler.ListCREA(crea);
            return ListResponsible;
        }
    }
}