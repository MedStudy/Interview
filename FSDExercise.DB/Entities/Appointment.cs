using System;

namespace FSDExercise.DB.Entities
{
  public class Appointment //: BaseEntity
  {
    public int id { get; set; }
    public TimeSpan start_time { get; set; }
    public TimeSpan end_time { get; set; }
    public int appointee_id { get; set; }
    public string Status { get; set; }
    public DateTime appointmentdate { get; set; }
    public int pet_id { get; set; }
    public virtual Owner appointee { get; set; }
    public virtual Pet Pet { get; set; }
    
  }
  
}
