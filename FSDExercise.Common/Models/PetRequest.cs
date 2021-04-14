using System.ComponentModel.DataAnnotations;

namespace FSDExercise.Common.Models
{  
  public class PetRequest
  {
      [Required(ErrorMessage ="Pet Name is required")]
      public string Name { get; set; }

      [Required(ErrorMessage = "Pet Type is required")]
      public string Type { get; set; }

      [Required(ErrorMessage = "Pet Age is required")]
      public int Age { get; set; }
  }
}
