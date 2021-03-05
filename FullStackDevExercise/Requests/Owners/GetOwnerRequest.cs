using FullStackDevExercise.Responses.Owners;
using MediatR;

namespace FullStackDevExercise.Requests.Owners
{
  public class GetOwnerRequest : GetRequest<GetOwnerResponse>
  {
    public GetOwnerRequest(long id) : base(id)
    {
    }
  }
}
