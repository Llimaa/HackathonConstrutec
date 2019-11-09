using PR.Shared.Commands;

namespace PR.Domain.Commands.Inputs
{
    public class InsertResponsavelCommandInput:ICommandInput
    {
        public string Nome { get; set; }
        public string CREA { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
    }
}
