using FullStackDevExercise.DAL.Repository;
using FullStackDevExercise.ViewModels;
using FullStackDevExercise.ViewModels.Mapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackDevExercise.Services
{
  public class AppointmentService : IAppointmentService
  {
    private readonly IAppointmentMapper _appointmentMapper;
    private readonly IAppointmentRepository _appointmentsRepository;

    public AppointmentService(
    IAppointmentMapper appointmentMapper,
    IAppointmentRepository appointmentsRepository
    )
    {
      _appointmentMapper = appointmentMapper;
      _appointmentsRepository = appointmentsRepository;
    }

    public async Task<AppointmentViewModel> GetById(int id) => _appointmentMapper.Encode(await _appointmentsRepository.GetAsync(id));

    public IEnumerable<AppointmentViewModel> GetByDate(int year, int month, int date)
    {
      var result = _appointmentsRepository.GetByDate(year, month, date);

      if (result?.Count() == 0) return null;

      return _appointmentMapper.Encode(result.ToList());
    }

    public IEnumerable<MonthlyAppointmentSummaryViewModel> GetMonthSummary(int year, int month)
    {
      var result = _appointmentsRepository.GetMonthlySummary(year, month);

      return result?.Select(r => new MonthlyAppointmentSummaryViewModel() { Date = r.Key, Count = r.Value });
    }

    public async Task<AppointmentViewModel> Save(AppointmentViewModel appointment)
    {
      if (appointment.Id > 0)
      {
        var result = await _appointmentsRepository.UpdateAsync(_appointmentMapper.Decode(appointment));
        return result ? appointment : null;
      }
      else
      {
        var result = await _appointmentsRepository.InsertAsync(_appointmentMapper.Decode(appointment));
        appointment.Id = result;

        return appointment.Id > 0 ? appointment : null;
      }
    }

    public async Task<bool> DeleteAsync(long id)
    {
      var result = await _appointmentsRepository.DeleteAsync(id);

      return result == 1;
    }
  }
}
