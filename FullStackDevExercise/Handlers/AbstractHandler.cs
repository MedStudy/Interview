using System.Threading;
using System.Threading.Tasks;
using FullStackDevExercise.DataAccess;
using MediatR;

namespace FullStackDevExercise.Handlers
{
  public abstract class AbstractHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
  {
    public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);

    protected dolittleContext GetContext()
    {
      return new dolittleContext();
    }
  }
}
