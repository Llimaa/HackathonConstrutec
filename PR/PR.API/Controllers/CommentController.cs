using Microsoft.AspNetCore.Mvc;
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
    public class CommentController : ControllerBase
    {
        CommentHandler CommentHandler;
        public CommentController(CommentHandler commentHandler)
        {
            CommentHandler = commentHandler;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        // POST: api/Comment/InsertCommentCommandInput
        [HttpPost]
        public async Task<ICommandResult> Post([FromBody] InsertCommentCommandInput value)
        {
            var result  = await CommentHandler.Handler(value);
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        // PUT: api/Comment/UpdateCommentCommandInput
        [HttpPut("{id}")]
        public async Task<ICommandResult> Put([FromBody] UpdateCommentCommandInput value)
        {
            var result = await CommentHandler.Handler(value);
            return result;
        }
    }
}
