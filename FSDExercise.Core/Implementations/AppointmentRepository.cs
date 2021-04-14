using FSDExercise.Core.Contracts;
using FSDExercise.DB;
using FSDExercise.DB.Actions;
using FSDExercise.DB.Entities;
using System.Threading.Tasks;

namespace FSDExercise.Core.Implementations
{
  public class AppointmentRepository : BaseRepository<Appointment>, IAppointmentRepository
    {
      private readonly FSDExerciseDBContext _dbContext;
      private readonly IDBOperations _dBOperations;
      public AppointmentRepository(FSDExerciseDBContext dbContext,
        IDBOperations dBOperations) : base(dbContext)
      {
        _dbContext = dbContext;
        _dBOperations = dBOperations;
      }

      public new async Task Add(Appointment entity)
      {
        await _dBOperations.AddAppointmentAsync(entity);
      }

      public new async Task Update(Appointment entity)
      {
        await _dBOperations.UpdateAppointmentAsync(entity);
      }

      public new async Task<Appointment> Get(int appointmentId)
      {
        return await _dBOperations.GetAppointmentAsync(appointmentId);
      }

      public async Task CancelAppointment(Appointment entity)
      {
        await _dBOperations.CancelAppointmentAsync(entity.id);
      }

      public new async Task Delete(Appointment entity)
      {
        await _dBOperations.DeleteAppointment(entity);
      }
  }
}
