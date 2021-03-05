using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FullStackDevExercise.Models;
using FullStackDevExercise.Requests.Vets;
using FullStackDevExercise.Responses.Vets;
using Microsoft.EntityFrameworkCore;

namespace FullStackDevExercise.Handlers.Schdules
{
  public class ListVetAvailabilityRequestHandler : AbstractHandler<ListVetAvailabilityRequest, ListVetAvailabilityResponse>
  {
    private readonly IMapper _mapper;

    public ListVetAvailabilityRequestHandler(IMapper mapper)
    {
      _mapper = mapper;
    }

    public override async Task<ListVetAvailabilityResponse> Handle(ListVetAvailabilityRequest request, CancellationToken cancellationToken)
    {
      using (var cxt = GetContext())
      {
        var entities = await cxt.Vets.ToListAsync();
        return new ListVetAvailabilityResponse(_mapper.MapList<VetModel>(entities));
      }
    }
  }
}
