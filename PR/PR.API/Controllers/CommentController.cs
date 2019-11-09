using Microsoft.AspNetCore.Mvc;
using PR.Domain.Commands.Handlers;
using PR.Domain.Commands.Inputs;

namespace PR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        ConstructionHandler ConstructionHandler;
        public CommentController( ConstructionHandler constructionHandler)
        {
            ConstructionHandler = constructionHandler;

        }
        [HttpPost]
        public void Post([FromBody] InsertCommentCommandInput value)
        {
            ConstructionHandler.Handler(value);
        }

        // PUT: api/CommentAPI/5
        [HttpPut("{id}")]
        public void Put([FromBody] UpdateCommentCommandInput value)
        {
            ConstructionHandler.Handler(value);
        }
    }
}
