using FullStackDevExercise.Models;

namespace FullStackDevExercise.Responses.Schdules
{
  public class CreateScheduleResponse : SaveResponse<AppointmentModel>
  {
    public CreateScheduleResponse(AppointmentModel model, int status, string message = null) : base(model, status, message)
    {
    }
  }
}
