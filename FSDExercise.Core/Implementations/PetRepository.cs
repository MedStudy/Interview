using FSDExercise.Core.Contracts;
using FSDExercise.DB;
using FSDExercise.DB.Actions;
using FSDExercise.DB.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FSDExercise.Core.Implementations
{
  public class PetRepository : BaseRepository<Pet>, IPetRepository
    {
      private readonly FSDExerciseDBContext _dbContext;
      private readonly IDBOperations _dBOperations;
      public PetRepository(FSDExerciseDBContext dbContext,
        IDBOperations dBOperations) : base(dbContext)
      {
        _dbContext = dbContext;
        _dBOperations = dBOperations;
      }

      public new async Task<Pet> Get(int id)
      {
        return await _dBOperations.GetPetAsync(id);
      }

      public new async Task<IEnumerable<Pet>> GetAll()
      { 
        return await _dBOperations.GetAllPetsAsync();
      }

      public new async Task Add(Pet entity)
      {
        await _dBOperations.AddPetAsync(entity);
      }

      public new async Task Update(Pet entity)
      {
        await _dBOperations.UpdatePetAsync(entity);
      }

      public new async Task Delete(Pet pet)
      {
        await _dBOperations.DeletePet(pet);
      }

    


  }
}
