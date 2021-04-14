using FSDExercise.Common.Models;
using FSDExercise.DB.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FSDExercise.Infra.Services.Contracts
{
  public interface IAppointmentService
    {
    Task<Result> RequestAppointment(int ownerId, int petId, AppointmentRequest request);
      Task<Appointment> GetAppointmentDetails(int id);
      Task<IEnumerable<Appointment>> GetAllAppointments();
      Task<(Result, Appointment)> UpdateAppointment(int id, AppointmentUpdateRequest request);
      Task<Result> DeleteAppointment(int id);
      Task<Result> CancelAppointment(int id);
    }
}
