using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FullStackDevExercise.Models;
using FullStackDevExercise.Requests.Schdules;
using FullStackDevExercise.Responses.Schdules;

namespace FullStackDevExercise.Handlers.Schdules
{
  public class UpdateScheduledRequestHandler : AbstractHandler<UpdateScheduleRequest, UpdateScheduleResponse>
  {
    private readonly IMapper _mapper;

    public UpdateScheduledRequestHandler(IMapper mapper)
    {
      _mapper = mapper;
    }

    public override async Task<UpdateScheduleResponse> Handle(UpdateScheduleRequest request, CancellationToken cancellationToken)
    {
      using (var cxt = GetContext())
      {
        var entity = await cxt.Appointments.FindAsync(request.Id);
        entity.ScheduledDate = request.NewAppointmentTime;

        await cxt.SaveChangesAsync();
        return new UpdateScheduleResponse(_mapper.Map<AppointmentModel>(entity), 200);
      }
    }
  }
}
