using FullStackDevExercise.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FullStackDevExercise.DAL.Repository
{
  public interface IAppointmentRepository: IRepository<AppointmentEntity>
  {
    IEnumerable<AppointmentEntity> GetByDate(int year, int month, int date);
    Dictionary<DateTime, int> GetMonthlySummary(int year, int month);
  }
}
