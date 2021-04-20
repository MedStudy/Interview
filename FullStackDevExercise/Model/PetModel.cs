using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace FullStackDevExercise.Model
{
  public class PetModel
  {
    [Key]
    public int id { get; set; }
    public int owner_id { get; set; }
    public string type { get; set; }
    [Required]
    [MaxLength(256)]
    public string name { get; set; }
    [Required]
    public int age { get; set; }

  }
}
