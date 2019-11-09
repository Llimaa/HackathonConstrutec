using PR.Shared.Commands;
using System;

namespace PR.Domain.Commands.Inputs
{
    public class InsertCommentCommandInput:ICommandInput
    {
        public Guid ConstructionId { get; set; }
        public Guid ResponsibleId { get; set; }
        public Guid OwnerId { get; set; }
        public Guid ReportId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
