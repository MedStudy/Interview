using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FullStackDevExercise.Models;

namespace FullStackDevExercise.Responses.Pets
{
  public class ListPetsResponse : SearchResponse<PetModel>
  {
    public ListPetsResponse(IEnumerable<PetModel> models) : base(models)
    {
    }
  }
}
