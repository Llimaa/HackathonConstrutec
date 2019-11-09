using PR.Shared.Commands;
using System;

namespace PR.Domain.Commands.Inputs
{
    public class InsertReportCommandInput : ICommandInput
    {
        public Guid ResponsibleId { get; set; }
        public Guid ConstructionId { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
    }
}
