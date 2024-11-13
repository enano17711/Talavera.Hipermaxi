using MediatR;
using Talavera.Hipermaxi.Domain.Abstractions;

namespace Talavera.Hipermaxi.Application.Abstractions.Messaging;

public interface ICommand : IRequest<Result>, IBaseCommand
{
}

public interface ICommand<TReponse> : IRequest<Result<TReponse>>, IBaseCommand
{
}

public interface IBaseCommand
{
}