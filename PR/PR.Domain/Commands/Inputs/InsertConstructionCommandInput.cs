using PR.Shared.Commands;
using System;

namespace PR.Domain.Commands.Inputs
{
    public class InsertConstructionCommandInput:ICommandInput
    {
        public Guid OwnerId { get; set; }
        public string[] creas { get; set; }
        public string ResidentCrea { get; set; }
        public string Fiscal1Crea { get; set; }
        public string Fiscal2Crea { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Street { get; set; }
        public string District { get; set; }
        public string Number { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinalDate { get; set; }
    }
}
