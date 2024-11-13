using MediatR;
using Talavera.Hipermaxi.Domain.Abstraction;

namespace Talavera.Hipermaxi.Application.Abstraction.Messaging;

public interface ICommand : IRequest<Result>, IBaseCommand
{
}

public interface ICommand<TReponse> : IRequest<Result<TReponse>>, IBaseCommand
{
}

public interface IBaseCommand
{
}