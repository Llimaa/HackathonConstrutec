using PR.Shared.Commands;
using System;

namespace PR.Domain.Commands.Inputs
{
    public class UpdateResponsavelCommandInput : ICommandInput
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
    }
}
