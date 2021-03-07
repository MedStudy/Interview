using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FullStackDevExercise.Contracts;
using FullStackDevExercise.DataAccess;
using FullStackDevExercise.Models;
using FullStackDevExercise.Requests.Schdules;
using FullStackDevExercise.Responses.Schdules;
using Microsoft.Extensions.Logging;

namespace FullStackDevExercise.Handlers.Schdules
{
  public class CreateScheduledRequestHandler : AbstractHandler<CreateScheduleRequest, CreateScheduleResponse>
  {
    private readonly IMapper _mapper;
    private readonly IIdentityValueGenerator _identityValueGenerator;
    private readonly ILogger<CreateScheduledRequestHandler> _logger;
    private readonly IDistributedLock _distributedLock;

    public CreateScheduledRequestHandler(IMapper mapper, IIdentityValueGenerator identityValueGenerator, ILogger<CreateScheduledRequestHandler> logger, IDistributedLock distributedLock)
    {
      _mapper = mapper;
      _identityValueGenerator = identityValueGenerator;
      _logger = logger;
      _distributedLock = distributedLock;
    }

    public override async Task<CreateScheduleResponse> Handle(CreateScheduleRequest request, CancellationToken cancellationToken)
    {
      var key = $"{request.AppointmentTime}{request.VetId}";
      try
      {
        //use the appointment time and the vet Id to generate a unqiue key for the lock.  any other thread attempting to
        //write  a similar record must wait till the lock is released.  Upon release we must check the state of the db again to make sure a write did not occur.

        await _distributedLock.AcquireAsync(key);
      }
      catch (Exception ex)
      {
        _logger.LogError($"{ex.Message}");
        return new CreateScheduleResponse(null, 500, $"Your request could not be completed.  Error code: 500");
      }
      using (var cxt = GetContext())
      {
        using (var transaction = await cxt.Database.BeginTransactionAsync())
        {
          try
          {
            var existing = cxt.Appointments.FirstOrDefault(x => x.ScheduledDate == request.AppointmentTime && x.VetId == request.VetId);
            if (existing == null)
            {
              var entity = new Appointments
              {
                Id = await _identityValueGenerator.WithContext(cxt, (c) => (from o in c.Appointments select o.Id).Max()),
                OwnerId = request.OwnerId,
                PetId = request.PetId,
                ScheduledDate = request.AppointmentTime.ToString(),
                VetId = request.VetId
              };
              cxt.Appointments.Add(entity);
              await cxt.SaveChangesAsync();
              await transaction.CommitAsync();
              return new CreateScheduleResponse(_mapper.Map<AppointmentModel>(await cxt.Appointments.FindAsync(entity.Id)), 200);
            }
            else
            {
              return new CreateScheduleResponse(null, 400, $"Your selected date/time is no longer available.");
            }
          }
          catch (Exception ex)
          {
            await transaction.RollbackAsync();
            _logger.LogError($"{ex.Message}");
            return new CreateScheduleResponse(null, 500, $"Your request could not be completed.  Error code: 500");
          }
          finally
          {
            try
            {
              await _distributedLock.ReleaseAsync(key);
            }
            catch (Exception ex)
            {
              //swallow exception but log it.
              _logger.LogError($"{ex.Message}");
            }
          }
        }
      }
    }
  }
}
