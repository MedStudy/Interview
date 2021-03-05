using FullStackDevExercise.Models;

namespace FullStackDevExercise.Responses.Owners
{
  public class SaveOwnerResponse : SaveResponse<OwnerModel>
  {
    public SaveOwnerResponse(OwnerModel model, int status, string message = null) : base(model, status, message)
    {
    }
  }
}
