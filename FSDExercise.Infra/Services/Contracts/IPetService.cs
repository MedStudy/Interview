using FSDExercise.Common.Models;
using FSDExercise.DB.Entities;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FSDExercise.Infra.Services.Contracts
{
  public interface IPetService
    {
      Task<Result> AddPet(int ownerId,PetRequest petRequest);
      Task<IEnumerable<Pet>> GetAllPets();
      Task<Pet> GetPet(int id);
      Task<(Result, Pet)> UpdatePet(int petId, PetUpdateRequest updateRequest);
      Task<Result> DeletePet(int id);
    }
}
