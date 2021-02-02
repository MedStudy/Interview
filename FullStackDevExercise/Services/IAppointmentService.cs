using FullStackDevExercise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackDevExercise.Services
{
  public interface IAppointmentService
  {
    Task<Appointment> Add(Appointment Appointment);

    Task<Appointment> Update(int id, Appointment Appointment);
    Task Delete(int id);
    Task<Appointment> GetById(int id);
    Task<IEnumerable<Appointment>> GetAll();
  }
}
