using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackDevExercise.Models
{
  /// <summary>
  /// Represents Owners table.
  /// </summary>
  [Display(Name = "'Owners'")]
  [Table("owners")]
  public class Owner
  {
    public Owner()
    {
    }

    [Key]
    public int Id { get; set; }

    [Required]
    public string First_Name { get; set; }

    [Required]
    public string Last_Name { get; set; }
  }
}
