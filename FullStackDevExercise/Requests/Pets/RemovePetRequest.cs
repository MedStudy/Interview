using FullStackDevExercise.Responses.Pets;
using MediatR;

namespace FullStackDevExercise.Requests.Pets
{
  public class RemovePetRequest : RemoveRequest<RemovePetResponse>
  {
    public RemovePetRequest(long id): base(id)
    {
    }
  }
}
