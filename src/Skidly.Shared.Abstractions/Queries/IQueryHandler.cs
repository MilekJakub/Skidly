using MediatR;

namespace Skidly.Shared.Abstractions.Queries;

public interface IQueryHandler<TQuery, TResponse>
    : IRequestHandler<TQuery, TResponse> where TQuery : IQuery<TResponse>
{
    
}