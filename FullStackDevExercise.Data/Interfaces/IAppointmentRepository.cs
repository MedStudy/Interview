using FullStackDevExercise.Common.Models;
using FullStackDevExercise.Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FullStackDevExercise.Data.Interfaces
{
  public interface IAppointmentRepository : IRepository<AppointmentEntity, AppointmentModel>
  {
    List<AppointmentModel> GetByDate(int year, int month, int date);
  }
}
