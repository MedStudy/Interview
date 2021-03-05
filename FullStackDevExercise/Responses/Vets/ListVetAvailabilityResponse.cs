using System.Collections.Generic;
using FullStackDevExercise.Models;

namespace FullStackDevExercise.Responses.Vets
{
  public class ListVetAvailabilityResponse : SearchResponse<VetModel>
  {
    public ListVetAvailabilityResponse(IEnumerable<VetModel> models) : base(models)
    {
    }
  }
}
