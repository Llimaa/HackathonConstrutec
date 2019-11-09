using PR.Shared.Commands;

namespace PR.Domain.Commands.Result
{
    public class CommandResult : ICommandResult
    {
        public CommandResult(string[] menssage)
        {
            Menssage = menssage;
        }

        public string[] Menssage { get; set; }
    }
}
