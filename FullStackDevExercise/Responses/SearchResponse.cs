using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackDevExercise.Responses
{
  public class SearchResponse<T>
  {
    public SearchResponse(IEnumerable<T> models)
    {
      Models = models;
    }

    public IEnumerable<T> Models { get; }
  }
}
