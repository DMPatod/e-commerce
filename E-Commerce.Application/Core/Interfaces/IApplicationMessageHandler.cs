namespace E_Commerce.Application.Core.Interfaces
{
    public interface IApplicationMessageHandler
    {
        Task PublishAsync<T>(T domainEvent, CancellationToken cancellationToken)
            where T : IDomainEvent;

        Task SendAsync(ICommand domainCommand, CancellationToken cancellationToken);

        Task<TResponse> SendAsync<TResponse>(ICommand<TResponse> domainCommand, CancellationToken cancellationToken);
    }
}
