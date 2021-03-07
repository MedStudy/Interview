using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackDevExercise.ViewModels
{
  public class PetViewModel
  {

    public long? Id { get; set; }
    [Required, MaxLength(50)]
    public string Type { get; set; }
    [Required, MaxLength(50)]
    public string Name { get; set; }
    [Required, Range(0, 100)]
    public long Age { get; set; }

    [Required, Range(1, Int64.MaxValue)]
    public long OwnerId { get; set; }
  }
}
