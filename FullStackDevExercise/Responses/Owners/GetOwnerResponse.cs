using FullStackDevExercise.Models;

namespace FullStackDevExercise.Responses.Owners
{
  public class GetOwnerResponse : GetResponse<OwnerModel>
  {
    public GetOwnerResponse(OwnerModel model) : base(model)
    {
    }
  }
}
