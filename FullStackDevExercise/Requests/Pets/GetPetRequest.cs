using FullStackDevExercise.Responses.Pets;
using MediatR;

namespace FullStackDevExercise.Requests.Pets
{
  public class GetPetRequest : GetRequest<GetPetResponse>
  {
    public GetPetRequest(long id): base(id)
    {
    }
  }
}
