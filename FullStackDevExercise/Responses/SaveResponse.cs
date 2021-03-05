namespace FullStackDevExercise.Responses
{
  public class SaveResponse<T>
  {
    public SaveResponse(T model, int status, string message = null)
    {
      Model = model;
      Status = status;
      Message = message;
    }

    public T Model { get; }
    public int Status { get; }
    public string Message { get; }
  }
}
