using FSDExercise.Common.Models;
using FSDExercise.DB.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FSDExercise.Infra.Services.Contracts
{
  public interface IOwnerService
    {
       Task<Result> AddOwner(OwnerRequest ownerRequest);
       Task<IEnumerable<Owner>> GetAllOwners();
       Task<Owner> GetOwner(int id);
       Task<(Result result, Owner owner)> UpdateOwner(int ownerId, OwnerRequest ownerRequest);
       Task<Result> DeleteOwner(int id);
    }
}
