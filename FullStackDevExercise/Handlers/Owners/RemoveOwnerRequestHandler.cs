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
        var item = await cxt.Owners.FindAsync(request.Id);
        if (item != null)
        {
          cxt.Owners.Remove(item);
        }
        await cxt.SaveChangesAsync();
        return new RemoveOwnerResponse { Success = true };
      }
    }
  }
}
