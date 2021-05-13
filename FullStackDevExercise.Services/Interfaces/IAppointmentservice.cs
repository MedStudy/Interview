using FullStackDevExercise.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FullStackDevExercise.Services.Interfaces
{
    public interface IAppointmentservice
    {
        Task<bool> CreateAppointmentAsync(AppointmentModel appointmentModel);
        Task<AppointmentModel> GetAppointmentById(long id);
        Task<bool> DeleteAsync(long id);
        List<AppointmentModel> GetByDate(int year, int month, int date);
    }
}
