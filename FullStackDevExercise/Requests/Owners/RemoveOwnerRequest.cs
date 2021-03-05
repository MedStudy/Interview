using FullStackDevExercise.Responses.Owners;

namespace FullStackDevExercise.Requests.Owners
{
  public class RemoveOwnerRequest : RemoveRequest<RemoveOwnerResponse>
  {
    public RemoveOwnerRequest(long id) : base(id)
    {
    }
  }
}
