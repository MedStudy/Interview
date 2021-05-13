using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FullStackDevExercise.Data
{
  public class EntityBase
  {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Required]
    [Column("id")]
    public long Id { get; set; }
  }
}
