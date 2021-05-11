using FullStackDevExercise.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FullStackDevExercise.Services.Interfaces
{
    public interface IPetService
    {
        Task<IEnumerable<PetModel>> GetPetListAsync();
        Task<bool> UpdatePetAsync(long id, PetModel petModel);
        Task<PetModel> GetPetById(long petId);
        Task<bool> CreatePetAsync(PetModel petModel);
        Task<bool> DeletePetAsync(long petId);
    }
}
