using FullStackDevExercise.Models;
using FullStackDevExercise.Responses.Owners;
using MediatR;

namespace FullStackDevExercise.Requests.Owners
{
  public class SaveOwnerRequest : SaveRequest<SaveOwnerResponse, OwnerModel>
  {
    public SaveOwnerRequest(OwnerModel model) : base(model)
    {
    }
  }
}
