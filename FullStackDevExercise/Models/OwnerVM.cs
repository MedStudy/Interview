using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackDevExercise.Models
{
  public class OwnerVM
  {
    public int Id { get; set; }
    [Required]
    public string FirstName { get; set; }
    public string LastName { get; set; }

  }

  public class PetVM
  {
    [Required]
    public string Type { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public int Age { get; set; }
  }
}
