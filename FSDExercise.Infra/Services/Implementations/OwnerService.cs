using FSDExercise.Common.Models;
using FSDExercise.Core.Contracts;
using FSDExercise.DB.Entities;
using FSDExercise.Infra.Services.Contracts;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSDExercise.Infra.Services.Implementations
{
    public class OwnerService : IOwnerService
    {
        private readonly IOwnerRepository _ownerRepository;
        private readonly ILogger<OwnerService> _logger;
        public OwnerService(IOwnerRepository ownerRepository,
          ILogger<OwnerService> logger)
        {
          _ownerRepository = ownerRepository;
          _logger = logger;
        }
        public async Task<Result> AddOwner(OwnerRequest ownerRequest)
        {
          Result result = null;
          try
          {
            await _ownerRepository.Add(new Owner
            {
              first_name = ownerRequest.FirstName,
              last_name = ownerRequest.LastName
            });
            result = new Result(true);
          }
          catch(Exception ex)
          {
              result = new Result(false,"Error occured while adding owner");
              _logger.LogError(ex.Message, ownerRequest);
          }
          return result;
        }

        public async Task<Owner> GetOwner(int id)
        {
          Owner owner = null;
          try
          {
            owner = await _ownerRepository.Get(id);
            return owner;
          }
          catch(Exception ex)
          {
            _logger.LogError(ex.Message);
          }
          return owner;
        }

        public async Task<IEnumerable<Owner>> GetAllOwners()
        {
          IEnumerable<Owner> owners = null;
          try
          {
            owners = await _ownerRepository.GetAll();
            return owners;
          }
          catch(Exception ex)
          {
            _logger.LogError(ex.Message);
          }
          return owners;
        }

        public async Task<(Result result,Owner owner)> UpdateOwner(int ownerId,OwnerRequest ownerRequest)
        {
          Result result = null;
          Owner owner = null;
          try
          {
            owner = await GetOwner(ownerId);
            if (owner is null)
              return (new Result(false, $"Owner with {ownerId} doesn't exists"), owner);

            owner.first_name = ownerRequest.FirstName;
            owner.last_name = ownerRequest.LastName;

            await _ownerRepository.Update(owner);
            result = new Result(true);
          }
          catch(Exception ex)
          {
            result = new Result(false, "Error occured while updating owner");
            _logger.LogError(ex.Message, ownerRequest);
          }
          return (result, owner);
        }

        public async Task<Result> DeleteOwner(int id)
        {
          Result result = null;
          try
          {
            var owner = await GetOwner(id);
            if (owner is null)
              return new Result(false, $"Owner with Id : {id}, doesn't exists");

            await _ownerRepository.Delete(owner);
            result = new Result(true);
          }
          catch(Exception ex)
          {
             result = new Result(false, "Error occured while deleting owner");
            _logger.LogError(ex.Message, id);
          }

          return result;
        }
    }
}
