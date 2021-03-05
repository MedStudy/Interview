using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FullStackDevExercise.Models;
using FullStackDevExercise.Requests.Owners;
using FullStackDevExercise.Responses.Owners;
using Microsoft.EntityFrameworkCore;

namespace FullStackDevExercise.Handlers.Owners
{
  public class GetOwnerRequestHandler : AbstractHandler<GetOwnerRequest, GetOwnerResponse>
  {
    private readonly IMapper _mapper;

    public GetOwnerRequestHandler(IMapper mapper)
    {
      _mapper = mapper;
    }

    public override async Task<GetOwnerResponse> Handle(GetOwnerRequest request, CancellationToken cancellationToken)
    {
      using (var cxt = GetContext())
      {
        var owner = await cxt.Owners.AsNoTracking().FirstOrDefaultAsync(x => x.Id == request.Id);
        return new GetOwnerResponse(_mapper.Map<OwnerModel>(owner));
      }
    }
  }
}
