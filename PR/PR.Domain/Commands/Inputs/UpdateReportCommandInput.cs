using PR.Shared.Commands;
using System;

namespace PR.Domain.Commands.Inputs
{
    public class UpdateReportCommandInput : ICommandInput
    {
        public Guid ReportId { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
    }
}
