using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackDevExercise.Models
{
  /// <summary>
  /// Represents Pets table.
  /// </summary>
  [Display(Name = "'Pets'")]
  [Table("pets")]
  public class Pet
  {
    public Pet()
    {
    }

    public int Id { get; set; }

    [Required]
    public int Owner_Id { get; set; }

    [Required]
    public string Type { get; set; }

    [Required]
    public string Name { get; set; }
    [Required]
    public int Age { get; set; }
  }
}
