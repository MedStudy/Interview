using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackDevExercise.Models
{
  public class VetModel
  {
    public long Id { get; set; }
    public string Name { get; set; }

    public virtual List<AppointmentModel> Appointments { get; set; }
  }
}
