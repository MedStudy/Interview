using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackDevExercise.models
{
  public interface Iappointment
  {
    public int id { get; set; }
    public int owner_id { get; set; }
    public int pet_id { get; set; }

    public string date { get; set; }
    public string owner_name { get; set; }

    public string pet_name { get; set; }


    public int fromtime { get; set; }
    public int totime { get; set; }

    public IEnumerable<Iappointment> getAllappointments();
    public Iappointment getappointment(string id);
    public Iappointment updateappointment(Iappointment data);
    public string deleteappointment(string id);

    public Iappointment createappointment(Iappointment data);
  }
}
