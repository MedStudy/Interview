using FSDExercise.Core.Contracts;
using FSDExercise.DB;
using FSDExercise.DB.Actions;
using FSDExercise.DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSDExercise.Core.Implementations
{
    public class OwnerRepository : BaseRepository<Owner>,IOwnerRepository 
    {
        private readonly FSDExerciseDBContext _dbContext;
        private readonly IDBOperations _dBOperations;
        public OwnerRepository(FSDExerciseDBContext dbContext,
          IDBOperations dBOperations) : base(dbContext)
        {
          _dbContext = dbContext;
          _dBOperations = dBOperations;
        }

        public new async Task Delete(Owner owner)
        {
          await _dBOperations.DeleteOwner(owner);
        }

    }
}
