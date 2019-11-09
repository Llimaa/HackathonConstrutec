using PR.Shared.Commands;

namespace PR.Domain.Commands.Result
{
    public class CommandResult : ICommandResult
    {
        public CommandResult(object _object)
        {
            Object = _object;
        }

        public object Object { get; set; }
        public object Menssage => Object;
    }
}
