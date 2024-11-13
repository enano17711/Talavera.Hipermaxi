using MediatR;
using Talavera.Hipermaxi.Domain.Abstraction;

namespace Talavera.Hipermaxi.Application.Abstraction.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}