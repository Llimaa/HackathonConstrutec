using PR.Shared.Commands;

namespace PR.Domain.Commands.Inputs
{
    public class InsertResponsibleCommandInput:ICommandInput
    {
        public string Name { get; set; }
        public string CREA { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
