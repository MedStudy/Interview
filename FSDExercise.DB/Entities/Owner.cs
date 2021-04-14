using System.Collections.Generic;

namespace FSDExercise.DB.Entities
{
  public class Owner //: BaseEntity
  {
    public int id { get; set; }
    public string first_name{get;set;}
    public string last_name { get; set; }
    public virtual ICollection<Pet> Pets { get; set; }
    public virtual ICollection<Appointment> Appointments { get; set; }
  }
}
