using MediatR;

namespace FullStackDevExercise.Requests
{
  public class SaveRequest<TResponse, TModel> : IRequest<TResponse>
  {
    public SaveRequest(TModel model)
    {
      Model = model;
    }

    public TModel Model { get; }
  }
}
