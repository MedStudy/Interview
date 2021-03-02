using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FullStackDevExercise.Data.Entities
{
  public class Appointment : BaseEntity
  {
    public DateTime appointment_date { get; set; }
    public int slot_from { get; set; }
    public int slot_to { get; set; }
    public string notes { get; set; }
    public int pet_id { get; set; }


    [ForeignKey("pet_id")]
    public virtual Pet Pet { get; set; }
  }
}
