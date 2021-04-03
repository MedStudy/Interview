using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackDevExercise.models
{
  public class appointments
  {
    public int id { get; set; }
    public int owner_id { get; set; }
    public int pet_id { get; set; }
    public string date { get; set; }
    public int fromtime { get; set; }
    public int totime { get; set; }   

  }
  public class appointmentsextend : appointments
  {
    public string owner_name { get; set; }

    public string pet_name { get; set; }
  }
}
