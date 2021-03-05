using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FullStackDevExercise.Models;

namespace FullStackDevExercise.Responses.Schdules
{
  public class SearchSchedulesResponse : SearchResponse<AppointmentModel>
  {
    public SearchSchedulesResponse(IEnumerable<AppointmentModel> models) : base(models)
    {
    }
  }
}
