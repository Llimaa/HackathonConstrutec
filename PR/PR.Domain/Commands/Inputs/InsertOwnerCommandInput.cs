using PR.Shared.Commands;

namespace PR.Domain.Commands.Inputs
{
    public class InsertOwnerCommandInput:ICommandInput
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public string District { get; set; }
        public string Number { get; set; }

    }
}
