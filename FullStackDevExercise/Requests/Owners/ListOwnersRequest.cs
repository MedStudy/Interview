using FullStackDevExercise.Responses.Owners;
using MediatR;

namespace FullStackDevExercise.Requests.Owners
{
  public class ListOwnersRequest : SearchRequest<ListOwnersResponse>
  {
    public ListOwnersRequest()
    {
    }
  }
}
