using PR.Shared.Commands;

namespace PR.Domain.Commands.Result
{
    public class CommandResult : ICommandResult
    {
        public CommandResult(object objeto)
        {
            Objeto = objeto;
        }

        public object Objeto { get; set; }
        public object Mensagem => Objeto;
    }
}
