using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FullStackDevExercise.DataAccess;
using FullStackDevExercise.Models;
using FullStackDevExercise.Requests.Owners;
using FullStackDevExercise.Responses.Owners;
using Microsoft.EntityFrameworkCore;

namespace FullStackDevExercise.Handlers.Owners
{
  public class ListOwnersRequestHandler : AbstractHandler<ListOwnersRequest, ListOwnersResponse>
  {
    private readonly IMapper _mapper;

    public ListOwnersRequestHandler(IMapper mapper)
    {
      _mapper = mapper;
    }

    public override async Task<ListOwnersResponse> Handle(ListOwnersRequest request, CancellationToken cancellationToken)
    {
      using (var cxt = new DolittleContext())
      {
        var owners = await cxt.Owners.AsNoTracking()
          .Include(x=>x.Pets)
          .Include(x=>x.Appointments)
          .ToListAsync();
        return new ListOwnersResponse(_mapper.MapList<OwnerModel>(owners));
      }
    }
  }
}
