using MediatR;

namespace Skidly.Shared.Abstractions.Commands;

public interface ICommandHandler<TCommand>
    : IRequestHandler<TCommand> where TCommand : ICommand
{
}