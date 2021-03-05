using System.Threading;
using System.Threading.Tasks;
using FullStackDevExercise.Requests.Owners;
using FullStackDevExercise.Responses.Owners;

namespace FullStackDevExercise.Handlers.Owners
{
  public class RemoveOwnerRequestHandler : AbstractHandler<RemoveOwnerRequest, RemoveOwnerResponse>
  {
    public RemoveOwnerRequestHandler()
    {
    }

    public override async Task<RemoveOwnerResponse> Handle(RemoveOwnerRequest request, CancellationToken cancellationToken)
    {
      using (var cxt = GetContext())
      {
        cxt.Owners.Remove(await cxt.Owners.FindAsync(request.Id));
        await cxt.SaveChangesAsync();
        return new RemoveOwnerResponse();
      }
    }
  }
}
