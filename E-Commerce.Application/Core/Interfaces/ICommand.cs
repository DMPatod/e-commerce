using MediatR;

namespace E_Commerce.Application.Core.Interfaces
{
    public interface ICommand : ICommand<bool>
    {
    }

    public interface ICommand<out T> : IRequest<T>
    {
    }

    public interface ICommandHandler<in TCommand> : ICommandHandler<TCommand, bool>
        where TCommand : ICommand
    {
    }

    public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
        where TCommand : ICommand<TResponse>
    {
    }
}
