using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FullStackDevExercise.DataAccess;
using FullStackDevExercise.Models;
using FullStackDevExercise.Requests.Schdules;
using FullStackDevExercise.Responses.Schdules;
using System.Linq;
using FullStackDevExercise.Contracts;

namespace FullStackDevExercise.Handlers.Schdules
{
  public class CreateScheduledRequestHandler : AbstractHandler<CreateScheduleRequest, CreateScheduleResponse>
  {
    private readonly IMapper _mapper;
    private readonly IIdentityValueGenerator _identityValueGenerator;
    private static object _syncroot = new object();

    public CreateScheduledRequestHandler(IMapper mapper, IIdentityValueGenerator identityValueGenerator)
    {
      _mapper = mapper;
      _identityValueGenerator = identityValueGenerator;
    }

    public override async Task<CreateScheduleResponse> Handle(CreateScheduleRequest request, CancellationToken cancellationToken)
    {
      using (var cxt = GetContext())
      {
        
        var entity = new Appointments
        {
          Id =  await _identityValueGenerator.WithContext(cxt, (c) => (from o in c.Appointments select o.Id).Max()),
          OwnerId = request.Owner.Id,
          PetId = request.Pet.Id,
          ScheduledDate = request.AppointmentTime.ToString(),
          VetId = request.Vet.Id
        };
        cxt.Appointments.Add(entity);
        await cxt.SaveChangesAsync();
        return new CreateScheduleResponse(_mapper.Map<AppointmentModel>(entity), 200);
      }
    }
  }
}
