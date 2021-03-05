using FullStackDevExercise.Responses.Pets;
using MediatR;

namespace FullStackDevExercise.Requests.Pets
{
  public class ListPetRequest : SearchRequest<ListPetsResponse> { }
}
