using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackDevExercise.Models
{
  public class PetModel
  {
    public long Id { get; set; }
    
    public string Type { get; set; }
 
    public string Name { get; set; }
   
    public long Age { get; set; }

    public OwnerModel Owner { get; set; }

    public virtual List<AppointmentModel> Appointments { get; set; }
  }
}
