using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FullStackDevExercise.Services.DTOs
{
  public class OwnerDTO : BaseDTO
  {
    [Required]
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<PetDTO> Pets { get; set; }

  }
}
