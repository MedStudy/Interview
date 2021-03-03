using FullStackDevExercise.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FullStackDevExercise.Data
{
  public interface IAppointmentRepository
  {
    Appointment GetById(int id);
    IQueryable<Appointment> GetAll();
    IQueryable<Appointment> GetByDate(DateTime date);
    int Save(Appointment record);
    int Delete(int id);
  }
}
