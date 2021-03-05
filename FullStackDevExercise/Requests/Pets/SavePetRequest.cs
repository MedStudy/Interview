using FullStackDevExercise.Models;
using FullStackDevExercise.Responses.Pets;
using MediatR;

namespace FullStackDevExercise.Requests.Pets
{
  public class SavePetRequest : SaveRequest<SavePetResponse, PetModel>
  {
    public SavePetRequest(PetModel model) : base(model)
    {
    }
  }
}
