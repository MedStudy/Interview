namespace FullStackDevExercise.Responses
{
  public class GetResponse<T>
  {
    public GetResponse(T model)
    {
      Model = model;
    }

    public T Model { get; }
  }
}
