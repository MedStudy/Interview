using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackDevExercise.models
{
  public class appointmentRepository : Iappointment
  {
    private readonly MedDbContext _context;

    public appointmentRepository(MedDbContext context)
    {
      this._context = context;
    }
    public appointments createappointment(appointments data)
    {
      try
      {
        _context.Appointments.Add(data);
        _context.SaveChanges();
        return data;
      }
      catch
      {
        throw new Exception("Something went wrong");
      }
    }

    public string deleteappointment(string id)
    {
      try
      {
        var owner = _context.Appointments.Where(x => x.id == Convert.ToInt32(id)).First();
        _context.Appointments.Remove(owner);
        _context.SaveChanges();
        return id;
      }
      catch
      {
        throw new Exception("Something went wrong");
      }
    }

    public IEnumerable<appointmentsextend> getAllappointments()
    {
      try
      {
        var result = from a in _context.Owners
                     join c in _context.Pets on a.id equals c.owner_id
                     join d in _context.Appointments on
                     new { pet_id = c.id, owner_id = a.id } equals new { pet_id = d.pet_id, owner_id = d.owner_id }
                     select new appointmentsextend()
                     {
                       id = d.id,
                       date = d.date,
                       fromtime = d.fromtime,
                       owner_id = d.owner_id,
                       pet_id = d.pet_id,
                       owner_name = a.first_name + " " + a.last_name,
                       pet_name = c.name,
                       totime = d.totime
                     };
        return result;
      }
      catch
      {
        throw new Exception("Something went wrong");
      }
    }

    public appointmentsextend getappointment(string id)
    {
      try
      {
        var result = from a in _context.Owners
                     join c in _context.Pets on a.id equals c.owner_id
                     join d in _context.Appointments on
                     new { pet_id = c.id, owner_id = a.id } equals new { pet_id = d.pet_id, owner_id = d.owner_id }
                     where d.id == Convert.ToInt32(id)
                     select new appointmentsextend()
                     {
                       id = d.id,
                       date = d.date,
                       fromtime = d.fromtime,
                       owner_id = d.owner_id,
                       pet_id = d.pet_id,
                       owner_name = a.first_name + " " + a.last_name,
                       pet_name = c.name,
                       totime = d.totime
                     };
        return result.First();
      }
      catch
      {
        throw new Exception("Something went wrong");
      }
    }

    public appointments updateappointment(appointments data)
    {
      try
      {
        _context.Appointments.Update(data);
        _context.SaveChanges();
        return data;
      }
      catch
      {
        throw new Exception("Something went wrong");
      }
    }
  }
}
