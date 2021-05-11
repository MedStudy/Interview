using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FullStackDevExercise.Data.Entities
{
  [Table("owners")]
  public class OwnerEntity : EntityBase
  {
    [Column("first_name")]
    public string FirstName { get; set; }
    [Column("last_name")]
    public string LastName { get; set; }

    public List<PetEntity> Pets { get; set; }
    
  }
}
