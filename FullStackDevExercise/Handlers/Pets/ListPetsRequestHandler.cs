using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FullStackDevExercise.Models;
using FullStackDevExercise.Requests.Pets;
using FullStackDevExercise.Responses.Pets;
using Microsoft.EntityFrameworkCore;

namespace FullStackDevExercise.Handlers.Pets
{
  public class ListPetRequestHandler : AbstractHandler<ListPetRequest, ListPetsResponse>
  {
    private readonly IMapper _mapper;

    public ListPetRequestHandler(IMapper mapper)
    {
      _mapper = mapper;
    }

    public override async Task<ListPetsResponse> Handle(ListPetRequest request, CancellationToken cancellationToken)
    {
      using (var cxt = GetContext())
      {
        var entities = await cxt.Pets
          .AsNoTracking()
          .Include(x => x.Appointments)
          .Include(x => x.Owner)
          .ToListAsync();
        return new ListPetsResponse(_mapper.MapList<PetModel>(entities));
      }
    }
  }
}
