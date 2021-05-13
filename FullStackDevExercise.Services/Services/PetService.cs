using FullStackDevExercise.Common.Models;
using FullStackDevExercise.Data.Interfaces;
using FullStackDevExercise.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FullStackDevExercise.Services.Services
{
  public class PetService : IPetService
  {
      private readonly IPetRepository _petRepository;

      public PetService(IPetRepository petRepository)
      {
         _petRepository = petRepository;
      }
      public async Task<bool> CreatePetAsync(PetModel petModel)
      {
         return await _petRepository.CreateAsync(petModel);
      }

      public async Task<bool> DeletePetAsync(long petId)
      {
         return await _petRepository.Delete(petId);
      }

      public async Task<PetModel> GetPetById(long petId)
      {
         return await _petRepository.GetByIdAsync(petId);
      }

      public async Task<IEnumerable<PetModel>> GetPetListAsync()
      {
          return await _petRepository.GetList();
      }

      public async Task<bool> UpdatePetAsync(long id, PetModel petModel)
      {
          return await _petRepository.Update(petModel, id);
      }
  }
}
