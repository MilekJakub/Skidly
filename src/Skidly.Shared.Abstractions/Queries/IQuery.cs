using MediatR;

namespace Skidly.Shared.Abstractions.Queries;

public interface IQuery<TResponse> : IRequest<TResponse>
{
    
}