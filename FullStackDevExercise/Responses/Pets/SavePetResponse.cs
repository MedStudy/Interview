using FullStackDevExercise.Models;

namespace FullStackDevExercise.Responses.Pets
{
  public class SavePetResponse : SaveResponse<PetModel>
  {
    public SavePetResponse(PetModel model, int status, string message = null) : base(model, status, message)
    {
    }
  }
}
