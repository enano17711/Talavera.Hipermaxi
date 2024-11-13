using MediatR;
using Talavera.Hipermaxi.Domain.Abstractions;

namespace Talavera.Hipermaxi.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}