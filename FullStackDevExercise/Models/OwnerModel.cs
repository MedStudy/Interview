using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackDevExercise.Models
{
  public class OwnerModel
  {
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public List<PetModel> Pets { get; set; }

    public List<AppointmentModel> Appointments { get; set; }
  }
}
