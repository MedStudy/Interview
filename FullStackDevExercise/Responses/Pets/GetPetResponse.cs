using FullStackDevExercise.Models;

namespace FullStackDevExercise.Responses.Pets
{
  public class GetPetResponse : GetResponse<PetModel>
  {
    public GetPetResponse(PetModel model) : base(model)
    {
    }
  }
}
