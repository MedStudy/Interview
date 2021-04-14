using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSDExercise.Common.Models
{
    [ExcludeFromCodeCoverage]
    public class AppointmentRequest
    {
       [Required(ErrorMessage ="Appointment Date is required")]
       public DateTime AppointmentDate { get; set; }

       //[Required(ErrorMessage = "Pet is required")]
       //public int PetId { get; set; }

       [Required(ErrorMessage = "Start time is required")]
       public string StartTime { get; set; }

       [Required(ErrorMessage = "End time is required")]
       public string EndTime { get; set; }
        
    }
}
