using System.Collections.Generic;
using FullStackDevExercise.Models;

namespace FullStackDevExercise.Responses.Owners
{
  public class ListOwnersResponse : SearchResponse<OwnerModel>
  {
    public ListOwnersResponse(IEnumerable<OwnerModel> models) : base(models)
    {
    }
  }
}
