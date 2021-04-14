using FSDExercise.Common.Models;
using FSDExercise.Core.Contracts;
using FSDExercise.DB.Entities;
using FSDExercise.Infra.Services.Contracts;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FSDExercise.Infra.Services.Implementations
{
  public class PetService : IPetService
  {
      private readonly IPetRepository _petRepository;
      private readonly ILogger<PetService> _logger;
      public PetService(IPetRepository petRepository,
        ILogger<PetService> logger)
      {
        _petRepository = petRepository;
        _logger = logger;
      }

      public async Task<Result> AddPet(int ownerId,PetRequest petRequest)
      {
        Result result = null;
        try
        {
          await _petRepository.Add(new Pet
          {             
             owner_id = ownerId,
             name = petRequest.Name,
             age = petRequest.Age,
             type = petRequest.Type
          });
          result = new Result(true);
        }
        catch (Exception ex)
        {
          result = new Result(false, "Error occured while adding pet");
          _logger.LogError(ex.Message, petRequest);
        }
        return result;
      }

      public async Task<Pet> GetPet(int id)
      {
        try
        {
          return await _petRepository.Get(id);
        }
        catch(Exception ex)
        {
          _logger.LogError(ex.Message, id);
        }
        return null;
      }

      public async Task<IEnumerable<Pet>> GetAllPets()
      {
        try
        {
          return await _petRepository.GetAll();
        }
        catch(Exception ex)
        {
          _logger.LogError(ex.Message);
        }
        return null;
      }

      public async Task<(Result,Pet)> UpdatePet(int petId,PetUpdateRequest updateRequest)
      {
        Result result = null;
        Pet pet = null;
        try
        {
          pet = await GetPet(petId);
          if (pet is null)
            return (new Result(false, $"Pet with {petId} doesn't exists"), pet);

          pet.name = updateRequest.Name;
          pet.age = updateRequest.Age;
          await _petRepository.Update(pet);
          result = new Result(true);
        }
        catch(Exception ex)
        {
          result = new Result(false,"Error occured while updating pet");
          _logger.LogError(ex.Message);
        }
        return (result, pet);
      }

      public async Task<Result> DeletePet(int id)
      {
        Result result = null;        
        try
        {
          var pet = await GetPet(id);
          if (pet is null)
            return new Result(false, $"Pet with Id : {id}, doesn't exists");

          await _petRepository.Delete(pet);
          result = new Result(true);
        }
        catch (Exception ex)
        {
          result = new Result(false, "Error occured while deleting pet");
          _logger.LogError(ex.Message, id);
        }

        return result;
      }

    }
}
