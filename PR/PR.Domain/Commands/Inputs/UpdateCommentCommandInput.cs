using PR.Shared.Commands;
using System;

namespace PR.Domain.Commands.Inputs
{
    public class UpdateCommentCommandInput:ICommandInput
    {
        public Guid CommentId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
