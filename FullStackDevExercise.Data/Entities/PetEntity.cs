using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FullStackDevExercise.Data.Entities
{
    [Table("pets")]
    public class PetEntity : EntityBase
    {
         [Column("owner_id")]
         public long OwnerId { get; set; }
         [Column("type")]
         public string Type { get; set; }
         [Column("name")]
         public string Name { get; set; }
         [Column("age")]
         public int Age { get; set; }

         [ForeignKey("OwnerId")]
         public OwnerEntity Owner { get; set; }
    }
}
