using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FullStackDevExercise.Models;

namespace FullStackDevExercise.Responses.Schdules
{
  public class UpdateScheduleResponse : SaveResponse<AppointmentModel>
  {
    public UpdateScheduleResponse(AppointmentModel model, int status, string message = null) : base(model, status, message)
    {
    }
  }
}
