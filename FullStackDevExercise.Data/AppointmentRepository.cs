using FullStackDevExercise.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FullStackDevExercise.Data
{
  public class AppointmentRepository : IAppointmentRepository
  {
    private readonly DataContext context;
    public AppointmentRepository(DataContext Context)
    {
      context = Context;
    }

    public Appointment GetById(int id)
    {
      return context.Appointments.Find(id);
    }

    public IQueryable<Appointment> GetByDate(DateTime date)
    {
      return context.Appointments.Include(c => c.Pet).ThenInclude(pet => pet.Owner)
        .Where(q => q.appointment_date.Date == date.Date);
    }

    public IQueryable<Appointment> GetAll()
    {
      return context.Appointments.AsQueryable();
    }

    public int Save(Appointment record)
    {
      //to do check whether actual id is needed in UI after this operatation.
      //Ideally all these methods should be async.
      context.Appointments.Attach(record);
      return context.SaveChanges();
    }

    public int Delete(int id)
    {
      var record = new Appointment()
      {
        id = id
      };
      context.Remove(record);
      return context.SaveChanges();
    }
  }
}
