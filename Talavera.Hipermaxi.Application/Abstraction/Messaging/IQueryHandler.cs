using MediatR;
using Talavera.Hipermaxi.Domain.Abstraction;

namespace Talavera.Hipermaxi.Application.Abstraction.Messaging;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{
}