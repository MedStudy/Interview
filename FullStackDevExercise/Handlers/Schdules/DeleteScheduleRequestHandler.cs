using System.Threading;
using System.Threading.Tasks;
using FullStackDevExercise.Requests.Schdules;
using FullStackDevExercise.Responses.Schdules;

namespace FullStackDevExercise.Handlers.Schdules
{
  public class DeleteScheduledRequestHandler : AbstractHandler<DeleteScheduleRequest, DeleteScheduleResponse>
  {
    public override async Task<DeleteScheduleResponse> Handle(DeleteScheduleRequest request, CancellationToken cancellationToken)
    {
      using (var cxt = GetContext())
      {
        var item = await cxt.Appointments.FindAsync(request.Id);
        if (item != null)
        {
          cxt.Appointments.Remove(item);
          await cxt.SaveChangesAsync();
        }
        return new DeleteScheduleResponse { Success = true };
      }
    }
  }
}
