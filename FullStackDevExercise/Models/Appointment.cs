using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackDevExercise.Models
{
  /// <summary>
  /// Represents Appointments table.
  /// </summary>
  [Display(Name = "'Appointments'")]
  [Table("appointments")]
  public class Appointment
  {
    public Appointment()
    {
    }

    [Key]
    public int Id { get; set; }

    [Required]
    public string Client_Name { get; set; }

    [Required]
    public string Pet_Type { get; set; }

    [Required]
    public int Age { get; set; }

    [Required]
    public DateTime Appointment_Date { get; set; }
  }
}
