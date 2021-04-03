using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackDevExercise.models
{
  public interface Iappointment
  {
    public IEnumerable<appointmentsextend> getAllappointments();
    public appointmentsextend getappointment(string id);
    public appointments updateappointment(appointments data);
    public string deleteappointment(string id);

    public appointments createappointment(appointments data);
  }
}
