using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace FullStackDevExercise.Model
{
  public class AppointmentsModel
  {
    [Key]
    public int appointment_id { get; set; }

    public String date { get; set; }
    [Required]

    public String time { get; set; }
    [Required]
    public String owner_name { get; set; }
    public String pet_name { get; set; }


  }
}
