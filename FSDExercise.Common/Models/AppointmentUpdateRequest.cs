using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSDExercise.Common.Models
{
    public class AppointmentUpdateRequest
    {
      [Required(ErrorMessage = "Appointment Date is required")]
      public DateTime AppointmentDate { get; set; }

      [Required(ErrorMessage = "Start time is required")]
      public TimeSpan StartTime { get; set; }

      [Required(ErrorMessage = "End time is required")]
      public TimeSpan EndTime { get; set; }
    }
}
