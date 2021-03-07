using System.Threading;
using System.Threading.Tasks;
using FullStackDevExercise.Requests.Pets;
using FullStackDevExercise.Responses.Pets;

namespace FullStackDevExercise.Handlers.Pets
{
  public class RemovePetRequestHandler : AbstractHandler<RemovePetRequest, RemovePetResponse>
  {
    public RemovePetRequestHandler()
    {
    }

    public override async Task<RemovePetResponse> Handle(RemovePetRequest request, CancellationToken cancellationToken)
    {
      using (var cxt = GetContext())
      {
        var item = await cxt.Pets.FindAsync(request.Id);
        if (item != null)
        {
          cxt.Pets.Remove(item);
        }
        await cxt.SaveChangesAsync();
        return new RemovePetResponse { Success = true };
      }
    }
  }
}
