using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FullStackDevExercise.Models;
using FullStackDevExercise.Requests.Pets;
using FullStackDevExercise.Responses.Pets;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace FullStackDevExercise.Handlers.Pets
{
  public class GetPetRequestHandler : AbstractHandler<GetPetRequest, GetPetResponse>
  {
    private readonly IMapper _mapper;

    public GetPetRequestHandler(IMapper mapper)
    {
      _mapper = mapper;
    }

    public override async Task<GetPetResponse> Handle(GetPetRequest request, CancellationToken cancellationToken)
    {
      using (var cxt = GetContext())
      {
        var entity = await cxt.Pets.Include(x=>x.Owner).FirstOrDefaultAsync(x=>x.Id==request.Id);
        return new GetPetResponse(_mapper.Map<PetModel>(entity));
      }
    }
  }
}
