using FullStackDevExercise.Common.Models;
using FullStackDevExercise.Data.Interfaces;
using FullStackDevExercise.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FullStackDevExercise.Services.Services
{
  public class AppointmentService : IAppointmentservice
  {

      private readonly IAppointmentRepository _appointmentRepository;

      public AppointmentService(IAppointmentRepository appointmentRepository)
      {
         _appointmentRepository = appointmentRepository;
      }

      public async Task<bool> CreateAppointmentAsync(AppointmentModel appointmentModel) =>  await _appointmentRepository.CreateAsync(appointmentModel);

      public async Task<bool> DeleteAsync(long id) => await _appointmentRepository.Delete(id);

      public async Task<AppointmentModel> GetAppointmentById(long id) => await _appointmentRepository.GetByIdAsync(id);

      public List<AppointmentModel> GetByDate(int year, int month, int date) =>  _appointmentRepository.GetByDate(year, month, date);
  }
}
