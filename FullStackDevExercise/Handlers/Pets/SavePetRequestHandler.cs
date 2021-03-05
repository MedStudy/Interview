using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FullStackDevExercise.Models;
using FullStackDevExercise.Requests.Pets;
using FullStackDevExercise.Responses.Pets;
using System.Linq;
using FullStackDevExercise.Contracts;

namespace FullStackDevExercise.Handlers.Pets
{
  public class SavePetRequestHandler : AbstractHandler<SavePetRequest, SavePetResponse>
  {
    private static object _syncroot = new object();
    private readonly IMapper _mapper;
    private readonly IIdentityValueGenerator _identityValueGenerator;

    public SavePetRequestHandler(IMapper mapper, IIdentityValueGenerator identityValueGenerator)
    {
      _mapper = mapper;
      _identityValueGenerator = identityValueGenerator;
    }

    public override async  Task<SavePetResponse> Handle(SavePetRequest request, CancellationToken cancellationToken)
    {
      using (var cxt = GetContext())
      {
        if (request.Model.Id > 0)
        {
          var entity = await cxt.Pets.FindAsync(request.Model.Id);
          if (entity != null)
          {
            entity.Age = request.Model.Age;
            entity.Name = request.Model.Name;
            entity.Type = request.Model.Type;
            return new SavePetResponse(_mapper.Map<PetModel>(entity), 200);
          }
          else
          {
            return new SavePetResponse(null, 500, $"No owner found.{request?.Model?.Id} ");
          }
        }
        else
        {
        
          var entity = _mapper.Map<DataAccess.Pets>(request.Model);
          entity.Id = entity.Id = await _identityValueGenerator.WithContext(cxt, (c) => (from o in c.Pets select o.Id).Max());
          entity.OwnerId = entity.Owner.Id;
          entity.Owner = null;

          cxt.Pets.Add(entity);
          await cxt.SaveChangesAsync();
          return new SavePetResponse(_mapper.Map<PetModel>(entity), 200);
        }
      }
    }
  }
}
