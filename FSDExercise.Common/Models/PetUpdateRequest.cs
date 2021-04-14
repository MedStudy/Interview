using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSDExercise.Common.Models
{
    public class PetUpdateRequest
    {
      [Required(ErrorMessage = "Pet Name is required")]
      public string Name { get; set; }

      [Required(ErrorMessage = "Pet Age is required")]
      public int Age { get; set; }
    }
}
