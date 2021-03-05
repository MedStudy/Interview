using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FullStackDevExercise.Models;
using FullStackDevExercise.Requests.Schdules;
using FullStackDevExercise.Responses.Schdules;
using Microsoft.EntityFrameworkCore;

namespace FullStackDevExercise.Handlers.Schdules
{
  public class SearchSchedulesdRequestHandler : AbstractHandler<SearchScheduleRequest, SearchSchedulesResponse>
  {
    private readonly IMapper _mapper;

    public SearchSchedulesdRequestHandler(IMapper mapper)
    {
      _mapper = mapper;
    }

    public override async Task<SearchSchedulesResponse> Handle(SearchScheduleRequest request, CancellationToken cancellationToken)
    {
      using (var cxt = GetContext())
      {
        var entities = await cxt.Appointments
          .AsNoTracking()
          .Include(x=>x.Owner)
          .Include(x=>x.Pet)
          .ToListAsync();
        return new SearchSchedulesResponse(_mapper.MapList<AppointmentModel>(entities));
      }
    }
  }
}
