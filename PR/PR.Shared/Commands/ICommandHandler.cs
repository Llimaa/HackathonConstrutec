using System.Threading.Tasks;

namespace PR.Shared.Commands
{
    public interface ICommandHandler<T> where T : ICommandInput
    {
        Task<ICommandResult> Handler(T command);
    }
}
