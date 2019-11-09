using Microsoft.AspNetCore.Mvc;
using PR.Domain.Commands.Handlers;
using PR.Domain.Commands.Inputs;
using PR.Domain.Entities;
using System.Collections.Generic;

namespace PR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentAPIController : ControllerBase
    {
        InsertCommentCommandInput CommentInsertIput;
        UpdateCommentCommandInput CommentUpdateIput;
        ConstructionHandler ConstructionHandler;
        public CommentAPIController(InsertCommentCommandInput commentInsertIput, UpdateCommentCommandInput commentUpdateIput, ConstructionHandler constructionHandler)
        {
            CommentInsertIput = commentInsertIput;
            CommentUpdateIput = commentUpdateIput;
            ConstructionHandler = constructionHandler;

        }
        // GET: api/CommentAPI
        [HttpGet]
        public IEnumerable<Comment> Get()
        {
            return void;
        }

        // GET: api/CommentAPI/5
        [HttpGet("{id}", Name = "Get")]
        public Comment Get(int id)
        {
            return "value";
        }

        // POST: api/CommentAPI
        [HttpPost]
        public void Post([FromBody] Comment value)
        {
        }

        // PUT: api/CommentAPI/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Comment value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
