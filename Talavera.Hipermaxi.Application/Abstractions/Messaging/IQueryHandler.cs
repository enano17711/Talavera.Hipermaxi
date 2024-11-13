using MediatR;
using Talavera.Hipermaxi.Domain.Abstractions;

namespace Talavera.Hipermaxi.Application.Abstractions.Messaging;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{
}