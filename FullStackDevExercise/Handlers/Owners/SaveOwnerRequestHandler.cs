using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FullStackDevExercise.Contracts;
using FullStackDevExercise.Models;
using FullStackDevExercise.Requests.Owners;
using FullStackDevExercise.Responses.Owners;

namespace FullStackDevExercise.Handlers.Owners
{
  public class SaveOwnerRequestHandler : AbstractHandler<SaveOwnerRequest, SaveOwnerResponse>
  {
    private readonly IMapper _mapper;
    private readonly IIdentityValueGenerator _identityValueGenerator;
    private static object _syncroot = new object();

    public SaveOwnerRequestHandler(IMapper mapper, IIdentityValueGenerator identityValueGenerator)
    {
      _mapper = mapper;
      _identityValueGenerator = identityValueGenerator;
    }

    public override async Task<SaveOwnerResponse> Handle(SaveOwnerRequest request, CancellationToken cancellationToken)
    {
      using (var cxt = GetContext())
      {
        if (request.Model.Id > 0)
        {
          var entity = await cxt.Owners.FindAsync(request.Model.Id);
          if (entity != null)
          {
            entity.FirstName = request.Model.FirstName;
            entity.LastName = request.Model.LastName;
            return new SaveOwnerResponse(_mapper.Map<OwnerModel>(entity), 200);
          }
          else
          {
            return new SaveOwnerResponse(null, 500, $"No owner found.{request?.Model?.Id} ");
          }
        }
        else
        {
          
          var entity = _mapper.Map<DataAccess.Owners>(request.Model);
          entity.Id = await _identityValueGenerator.WithContext(cxt, (c)=>(from o in c.Owners select o.Id).Max());
          cxt.Owners.Add(entity);
          await cxt.SaveChangesAsync();
          return new SaveOwnerResponse(_mapper.Map<OwnerModel>(entity), 200);
        }
      }
    }
  }
}
