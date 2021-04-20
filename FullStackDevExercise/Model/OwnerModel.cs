using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackDevExercise.Model
{
  public class OwnerModel
  {
    [Key]
    public int id { get; set; }
    [Required]
    [MaxLength(128)]
    public string first_name { get; set; }
    [Required]
    [MaxLength(256)]
    public string last_name { get; set; }
  }
}
