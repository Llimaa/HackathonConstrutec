using PR.Shared.Commands;
using System;

namespace PR.Domain.Commands.Inputs
{
    public class UpdateResponsibleCommandInput : ICommandInput
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
