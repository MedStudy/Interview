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
        cxt.Appointments.Remove(await cxt.Appointments.FindAsync(request.Id));
        await cxt.SaveChangesAsync();
        return new DeleteScheduleResponse();
      }
    }
  }
}
