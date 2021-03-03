using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FullStackDevExercise.Services.DTOs
{
  public class PetDTO : BaseDTO
  {
    public int OwnerId { get; set; }
    [Required]
    public string Type { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public int Age { get; set; }
  }

}
