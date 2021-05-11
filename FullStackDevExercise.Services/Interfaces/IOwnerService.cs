using FullStackDevExercise.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FullStackDevExercise.Services.Interfaces
{
    public interface IOwnerService
    {
        Task<IEnumerable<OwnerModel>> GetOwnerListAsync();
        Task<bool> UpdateOwnerAsync(long id, OwnerModel ownerModel);
        Task<OwnerModel> GetOwnerById(long ownerId);
        Task<bool> CreateOwnerAsync(OwnerModel ownerModel);
        Task<bool> DeleteOwnerAsync(long ownerId);
    }
}
