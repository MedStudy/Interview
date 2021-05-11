using FullStackDevExercise.Common.Models;
using FullStackDevExercise.Data.Interfaces;
using FullStackDevExercise.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FullStackDevExercise.Services.Services
{
    public class OwnerService : IOwnerService
    {
        private readonly IOwnerRepository _ownerRepository;
        public OwnerService(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        public async Task<bool> CreateOwnerAsync(OwnerModel ownerModel)
        {
            return await _ownerRepository.CreateAsync(ownerModel);
        }

        public async Task<bool> DeleteOwnerAsync(long ownerId)
        {
            return await _ownerRepository.Delete(ownerId);
        }

        public async Task<OwnerModel> GetOwnerById(long ownerId)

        {
            return await _ownerRepository.GetByIdAsync(ownerId);
        }

        public async Task<IEnumerable<OwnerModel>> GetOwnerListAsync()
        {
            return await _ownerRepository.GetList();
        }

        public async Task<bool> UpdateOwnerAsync(long id, OwnerModel ownerModel)
        {
             return await _ownerRepository.Update(ownerModel,id);
        }
  }
}
